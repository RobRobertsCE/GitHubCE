﻿using Atlassian.Jira.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atlassian.Jira
{
    /// <summary>
    /// The status of the issue as defined in JIRA
    /// </summary>
    public class IssueStatus : JiraNamedEntity
    {
        /// <summary>
        /// Creates an instance of the IssueStatus based on a remote entity.
        /// </summary>
        public IssueStatus(AbstractNamedRemoteEntity remoteEntity)
            : base(remoteEntity)
        {
        }

        internal IssueStatus(Jira jira, string id)
            : base(jira, id)
        {
        }

        internal IssueStatus(string name)
            : base(name)
        {
        }

        protected override IEnumerable<JiraNamedEntity> GetEntities(Jira jira, string projectKey = null)
        {
            return jira.GetIssueStatuses();
        }

        /// <summary>
        /// Allows assignation by name
        /// </summary>
        public static implicit operator IssueStatus(string name)
        {
            if (name != null)
            {
                int id;
                if (int.TryParse(name, out id))
                {
                    return new IssueStatus(null, name /*as id*/);
                }
                else
                {
                    return new IssueStatus(name);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Operator overload to simplify LINQ queries
        /// </summary>
        /// <remarks>
        /// Allows calls in the form of issue.Priority == "High"
        /// </remarks>
        public static bool operator ==(IssueStatus entity, string name)
        {
            if ((object)entity == null)
            {
                return name == null;
            }
            else if (name == null)
            {
                return false;
            }
            else
            {
                return entity._name == name;
            }
        }

        /// <summary>
        /// Operator overload to simplify LINQ queries
        /// </summary>
        /// <remarks>
        /// Allows calls in the form of issue.Priority != "High"
        /// </remarks>
        public static bool operator !=(IssueStatus entity, string name)
        {
            if ((object)entity == null)
            {
                return name != null;
            }
            else if (name == null)
            {
                return true;
            }
            else
            {
                return entity._name != name;
            }
        }
    }
}
