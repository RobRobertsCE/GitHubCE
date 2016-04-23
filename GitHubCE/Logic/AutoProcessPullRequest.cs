using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubCE.Logic
{
    class AutoProcessPullRequest
    {
        public void AutoProcessRequest(PullRequestView request)
        {


            // get the steps to auto-process the pull request.
            //if db version update:
            //  checkout request branch
            //  update AdvUpgrade project (Process *.100 folder, validate embedded resource)
            //  run SetVersion
            //  build commit message
            //  commit changes
            //  push changes to GitHub
            // merge working branch into parent branch
            // if < develop:
            //  checkout branch
            //  pull changes
            //  build branch
            //  copy assemblies to patch folder
            //  if requires merge up:
            //      checkout next branch up
            //      pull changes
            //      merge previous branch up
            //      resolve conflicts
            //      build branch
            //      push changes to GitHub
            //      copy assemblies to patch folder
            //      repeat as required up to develop
            //      update JIRA issue


            /***** Functionality *****/
            /*
            [GitHub]                
                Merge Pull Request
                Close Pull Request
                Add Comment To Pull Request

            [Posh-Git]
                Checkout Branch
                Pull Branch Changes
                Commit Changes
                Push Changes To GitHub
                Change Branch
                Merge Branch Up
                Fixup Branch
                Amend Commit Message

            [JIRA]
                Update JIRA Issue - To QA: Fix Versions, Comment, Status
                Add Comment To JIRA Issue

            [Local]
                Run SetVersion
                Write Commit Message
                Process AdvUpgrade
                Build Branch
                Copy Assemblies To Patch Folder
                Update Patch File
                Resolve Conflicts
                


            */
        }
    }
}
