﻿using Atlassian.Jira.Remote;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Atlassian.Jira
{
    /// <summary>
    /// Collection of custom fields
    /// </summary>
    public class CustomFieldValueCollection : ReadOnlyCollection<CustomFieldValue>, IRemoteIssueFieldProvider
    {
        private readonly Issue _issue;
        private Func<string, string> _getFieldIdProvider;

        internal CustomFieldValueCollection(Issue issue)
            : this(issue, new List<CustomFieldValue>())
        {
        }

        internal CustomFieldValueCollection(Issue issue, IList<CustomFieldValue> list)
            : base(list)
        {
            _issue = issue;

            // By default collection operates for edit custom fields.
            ForEdit();
        }

        /// <summary>
        /// Add a custom field by name
        /// </summary>
        /// <param name="fieldName">The name of the custom field as defined in JIRA</param>
        /// <param name="fieldValue">The value of the field</param>
        public CustomFieldValueCollection Add(string fieldName, string fieldValue)
        {
            return this.Add(fieldName, new string[] { fieldValue });
        }

        /// <summary>
        /// Add a custom field by name with an array of values
        /// </summary>
        /// <param name="fieldName">The name of the custom field as defined in JIRA</param>
        /// <param name="fildValues">The values of the field</param>
        public CustomFieldValueCollection AddArray(string fieldName, params string[] fieldValues)
        {
            return this.Add(fieldName, fieldValues);
        }

        /// <summary>
        /// Add a cascading select field.
        /// </summary>
        /// <param name="cascadingSelectField">Cascading select field to add.</param>
        public CustomFieldValueCollection AddCascadingSelectField(CascadingSelectCustomField cascadingSelectField)
        {
            return AddCascadingSelectField(cascadingSelectField.Name, cascadingSelectField.ParentOption, cascadingSelectField.ChildOption);
        }

        /// <summary>
        /// Add a cascading select field.
        /// </summary>
        /// <param name="fieldName">The name of the custom field as defined in JIRA.</param>
        /// <param name="parentOption">The value of the parent option.</param>
        /// <param name="childOption">The value of the child option.</param>
        public CustomFieldValueCollection AddCascadingSelectField(string fieldName, string parentOption, string childOption = null)
        {
            var options = new List<string>() { parentOption };

            if (!string.IsNullOrEmpty(childOption))
            {
                options.Add(childOption);
            }

            return AddArray(fieldName, options.ToArray());
        }

        /// <summary>
        /// Add a custom field by name
        /// </summary>
        /// <param name="fieldName">The name of the custom field as defined in JIRA</param>
        /// <param name="fieldValues">The values of the field</param>
        public CustomFieldValueCollection Add(string fieldName, string[] fieldValues)
        {
            var fieldId = _getFieldIdProvider(fieldName);
            this.Items.Add(new CustomFieldValue(fieldId, fieldName, _issue) { Values = fieldValues });
            return this;
        }

        /// <summary>
        /// Gets a cascading select custom field by name.
        /// </summary>
        /// <param name="fieldName">Name of the custom field as defined in JIRA.</param>
        /// <returns>CascadingSelectCustomField instance if the field has been set on the issue, null otherwise</returns>
        public CascadingSelectCustomField GetCascadingSelectField(string fieldName)
        {
            CascadingSelectCustomField result = null;
            var fieldValue = this[fieldName];

            if (fieldValue != null && fieldValue.Values != null)
            {
                var parentOption = fieldValue.Values.Length > 0 ? fieldValue.Values[0] : null;
                var childOption = fieldValue.Values.Length > 1 ? fieldValue.Values[1] : null;

                result = new CascadingSelectCustomField(fieldName, parentOption, childOption);
            }

            return result;
        }

        /// <summary>
        /// Gets a custom field by name
        /// </summary>
        /// <param name="fieldName">Name of the custom field as defined in JIRA</param>
        /// <returns>CustomField instance if the field has been set on the issue, null otherwise</returns>
        public CustomFieldValue this[string fieldName]
        {
            get
            {
                var fieldId = _getFieldIdProvider(fieldName);
                return this.Items.FirstOrDefault(f => f.Id == fieldId);
            }
        }

        /// <summary>
        /// Changes context of collection to operate against fields for edit.
        /// </summary>
        /// <returns>Current collection with changed context/</returns>
        public CustomFieldValueCollection ForEdit()
        {
            _getFieldIdProvider = fieldName =>
            {
                var customField = _issue.Jira.GetFieldsForEdit(_issue)
                    .FirstOrDefault(f => f.Name.Equals(fieldName, StringComparison.OrdinalIgnoreCase));

                if (customField == null)
                {
                    throw new InvalidOperationException(String.Format("Could not find custom field with name '{0}' on the JIRA server. "
                        + "Make sure this field is available when editing this issue. For more information see JRA-6857", fieldName));
                }

                return customField.Id;
            };

            return this;
        }

        /// <summary>
        /// Changes context of collection to operate against fields for action.
        /// </summary>
        /// <param name="actionId">Id of action as defined in JIRA.</param>
        /// <returns>Current collection with changed context/</returns>
        public CustomFieldValueCollection ForAction(string actionId)
        {
            _getFieldIdProvider = name =>
            {
                var customField = _issue.Jira.GetFieldsForAction(_issue, actionId)
                    .FirstOrDefault(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (customField == null)
                {
                    throw new InvalidOperationException(
                        String.Format(
                        CultureInfo.InvariantCulture,
                        "Could not find custom field with name '{0}' and action with id '{1}' on the JIRA server. ",
                        name,
                        actionId));
                }

                return customField.Id;
            };

            return this;
        }

        RemoteFieldValue[] IRemoteIssueFieldProvider.GetRemoteFields()
        {
            return this.Items
                .Where(field => IsCustomFieldNewOrUpdated(field))
                .Select(field => new RemoteFieldValue()
                {
                    id = field.Id,
                    values = field.Values
                }).ToArray();
        }

        private bool IsCustomFieldNewOrUpdated(CustomFieldValue customField)
        {
            if (this._issue.OriginalRemoteIssue.customFieldValues == null)
            {
                // Original remote issue had no custom fields, this means that a new one has been added by user.
                return true;
            }

            var originalField = this._issue.OriginalRemoteIssue.customFieldValues.FirstOrDefault(field => field.customfieldId == customField.Id);

            if (originalField == null)
            {
                // A custom field with this id does not exist on the original remote issue, this means that it was
                //   added by the user
                return true;
            }
            else if (originalField.values == null)
            {
                // The remote custom field was not initialized, include it on the payload.
                return true;
            }
            else
            {
                return !originalField.values.SequenceEqual(customField.Values);
            }
        }

    }
}
