﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Atlassian.Jira.Test.Integration.Setup
{
    class SetupProgram
    {
        static void Main(string[] args)
        {
            var currentDir = Path.GetDirectoryName(typeof(SetupProgram).Assembly.Location);
            var arg = args.Length > 0 ? args[0].ToLowerInvariant() : null;
            Environment.CurrentDirectory = currentDir;

            if (arg != null && arg.Equals("start", StringComparison.OrdinalIgnoreCase))
            {
                StartJira(currentDir);
            }
            else if (arg != null && arg.Equals("setup", StringComparison.OrdinalIgnoreCase))
            {
                SetupJira(currentDir);
            }
            else
            {
                PrintInstructions();
            }

        }

        private static void PrintInstructions()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("To setup JIRA to run integration tests:");
            Console.WriteLine("  1. 'JiraSetup.exe start'");
            Console.WriteLine("  2. Wait until tomcat container is fully ready.");
            Console.WriteLine("  3. 'JiraSetup.exe setup'.");
            Console.WriteLine("  4. Wait until the back up restore is complete.");
            Console.WriteLine("-------------------------------------------------------");
        }

        private static void StartJira(string currentDir)
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Starting JIRA.");
            Console.WriteLine("Wait until the tomcat container is ready to accept requests.");
            Console.WriteLine("-------------------------------------------------------");

            var process = new Process();
            process.StartInfo.FileName = Path.Combine(currentDir, "StartJira.bat");
            process.Start();
        }

        private static void SetupJira(string currentDir)
        {
            var webDriver = new ChromeDriver();

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Restoring test data.");
            Console.WriteLine("-------------------------------------------------------");

            // Login
            LoginToJira(webDriver);

            // Restore TestData
            File.Copy(
                Path.Combine(currentDir, "TestData.zip"),
                Path.Combine(currentDir, @"amps-standalone\target\jira\home\import\TestData.zip"),
                true);

            webDriver.Url = "http://localhost:2990/jira/secure/admin/XmlRestore!default.jspa";
            WaitForElement(webDriver, By.Name("filename")).SendKeys("TestData.zip");
            WaitForElement(webDriver, By.Id("restore-xml-data-backup-submit")).Click();

            // Wait until restore is complete
            WaitForElement(
                webDriver,
                TimeSpan.FromMinutes(3),
                wd => wd.FindElements(By.TagName("p"))
                    .FirstOrDefault(we => we.Text.Trim().Equals("Your import has been successful.", StringComparison.OrdinalIgnoreCase)));

            // Login again
            LoginToJira(webDriver);

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("JIRA Setup Complete. You can now run the integration tests.");
            Console.WriteLine("-------------------------------------------------------");

            webDriver.Quit();
        }

        private static void LoginToJira(ChromeDriver webDriver)
        {
            webDriver.Url = "http://localhost:2990/jira/login.jsp";
            WaitForElement(webDriver, By.Id("login-form-username")).SendKeys("admin");
            WaitForElement(webDriver, By.Id("login-form-password")).SendKeys("admin");
            WaitForElement(webDriver, By.Id("login-form-submit")).Click();
            WaitForElement(webDriver, By.Id("header-details-user-fullname"), TimeSpan.FromSeconds(60));
        }

        private static IWebElement WaitForElement(IWebDriver webDriver, By locator)
        {
            return WaitForElement(webDriver, locator, TimeSpan.FromSeconds(10));
        }

        private static IWebElement WaitForElement(IWebDriver webDriver, By locator, TimeSpan timeout)
        {
            return WaitForElement(webDriver, timeout, wd => wd.FindElements(locator).FirstOrDefault());
        }

        private static IWebElement WaitForElement(IWebDriver webDriver, TimeSpan timeout, Func<IWebDriver, IWebElement> func)
        {
            var wait = new WebDriverWait(webDriver, timeout);
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            return wait.Until(func);
        }
    }
}
