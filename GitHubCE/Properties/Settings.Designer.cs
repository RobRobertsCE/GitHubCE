﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GitHubCE.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("6fe51e45b345263511071843b317d4ed3089b3ec")]
        public string GitHubToken {
            get {
                return ((string)(this["GitHubToken"]));
            }
            set {
                this["GitHubToken"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("RobRobertsCE")]
        public string GitHubUserName {
            get {
                return ((string)(this["GitHubUserName"]));
            }
            set {
                this["GitHubUserName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CenterEdge")]
        public string GitHubRepoOwner {
            get {
                return ((string)(this["GitHubRepoOwner"]));
            }
            set {
                this["GitHubRepoOwner"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://centeredge.atlassian.net")]
        public string JiraUrl {
            get {
                return ((string)(this["JiraUrl"]));
            }
            set {
                this["JiraUrl"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("rroberts")]
        public string JiraUserName {
            get {
                return ((string)(this["JiraUserName"]));
            }
            set {
                this["JiraUserName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("hel-j205")]
        public string JiraUserPassword {
            get {
                return ((string)(this["JiraUserPassword"]));
            }
            set {
                this["JiraUserPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"[""Advantage"",
""AdvantageCustomReports"",
""AdvantageWeb"",
""AdvantageCreditCards"",
""AdvantageShared"",
""AdvantageDiscountBase"",
""AdvantageRelay"",
""AdvantageWebAdmin"",
""AdvantageSales"",
""AdvantageTaxes"",
""CenterEdgeSiteInfo"",
""AdvantageWebAdmin"",
""advantageweb"",
""CECloud.Webstores"",
""CECloud.RevNu"",
""CECloud.Script"",
""CenterEdgeHelp"",
""advantagecorp"",
""CECloud.NodeJSRouter"",
""CECloud.Authentication"",
""CECloud.Clients"",
""CECloud.DataLayer"",
""CE.Log"",
""CenterEdgeUpgrades"",
""CECloud.MVC"",
""WPFMediaKit""]")]
        public string RepoList {
            get {
                return ((string)(this["RepoList"]));
            }
            set {
                this["RepoList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("[\"Advantage\",\"AdvantageCustomReports\",\"AdvantageWeb\",\"AdvantageCreditCards\",\"Adva" +
            "ntageShared\",\"AdvantageDiscountBase\",\"AdvantageRelay\",\"AdvantageWebAdmin\",\"Advan" +
            "tageSales\",\"AdvantageTaxes\", \"CenterEdgeSiteInfo\"]")]
        public string ActiveRepoList {
            get {
                return ((string)(this["ActiveRepoList"]));
            }
            set {
                this["ActiveRepoList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ShowOpenRequests {
            get {
                return ((bool)(this["ShowOpenRequests"]));
            }
            set {
                this["ShowOpenRequests"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ShowClosedRequests {
            get {
                return ((bool)(this["ShowClosedRequests"]));
            }
            set {
                this["ShowClosedRequests"] = value;
            }
        }
    }
}
