using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Mvc.Models.Fields;
using ToyBox.Feature.Controls.Models.Actions;
using ToyBox.Foundation.Common.Helpers;

namespace ToyBox.Feature.Controls.Actions
{
    public class TestFormAction : SubmitActionBase<string>
    {
        public TestFormAction(ISubmitActionData submitActionData) : base(submitActionData) 
        {
                
        }

        /// <summary>
        /// Tries to convert the specified <paramref name="value" /> to an instance of the specified target type.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="target">The target object.</param>
        /// <returns>
        /// true if <paramref name="value" /> was converted successfully; otherwise, false.
        /// </returns>
        protected override bool TryParse(string value, out string target)
        {
            target = string.Empty;
            return true;
        }

        protected override bool Execute(string data, FormSubmitContext formSubmitContext)
        {
            Assert.ArgumentNotNull(formSubmitContext, nameof(formSubmitContext));

            if (!formSubmitContext.HasErrors)
            {
                return SubmitForm(formSubmitContext);
            }

         
            return true;
        }

        private bool SubmitForm(FormSubmitContext fromSubmitContext)
        {
            var formFieldValues = new List<FormFieldValue>();
            foreach (IViewModel field in fromSubmitContext.Fields)
            {
                //Text field type
                if (field.TemplateId ==
                    Sitecore.Configuration.Settings.GetSetting("ToyBox.Feature.Controls.SitecoreForms.InputTemplateId") ||
                    field.TemplateId ==
                    Sitecore.Configuration.Settings.GetSetting("ToyBox.Feature.Controls.SitecoreForms.EmailTemplateId") ||
                    field.TemplateId ==
                    Sitecore.Configuration.Settings.GetSetting("ToyBox.Feature.Controls.SitecoreForms.MultilineTemplateId") ||
                    field.TemplateId ==
                    Sitecore.Configuration.Settings.GetSetting("ToyBox.Feature.Controls.SitecoreForms.CheckboxTemplateId")
                )
                {
                    string fieldValue = GetValue(field);

                    formFieldValues.Add(new FormFieldValue { Name = field.Name, Value = fieldValue });
                }


                //Dropdown field type
                if (field.TemplateId ==
                    Sitecore.Configuration.Settings.GetSetting("ToyBox.Feature.Controls.SitecoreForms.DropdownTemplateId"))
                {
                    string fieldValue = GetSelectedValue(field);

                    formFieldValues.Add(new FormFieldValue { Name = field.Name, Value = fieldValue });
                }
                // Multicheckbox field type
                if (field.TemplateId ==
                    Sitecore.Configuration.Settings.GetSetting("ToyBox.Feature.Controls.SitecoreForms.RadioButtonsTemplateId") ||
                    field.TemplateId == Sitecore.Configuration.Settings.GetSetting("ToyBox.Feature.Controls.SitecoreForms.MultiCheckboxesTemplateId"))
                {
                    string fieldValue = GetSelectedValues(field);

                    formFieldValues.Add(new FormFieldValue { Name = field.Name, Value = fieldValue });
                }

                //Hidden field type
                if (field.TemplateId == Sitecore.Configuration.Settings.GetSetting("ToyBox.Feature.Controls.SitecoreForms.HiddenTemplateId"))
                {
                    //if the field is called "submissionurl", send the page url to Eloqua
                    if (field.Name.ToLower().Equals("submissionurl"))
                    {
                        string pageUrl = System.Web.HttpContext.Current.Request.Headers.GetValues("Referer").FirstOrDefault();
                        formFieldValues.Add(new FormFieldValue { Name = field.Name, Value = pageUrl });
                    }
                    else
                    {
                        string fieldValue = GetValue(field);
                        formFieldValues.Add(new FormFieldValue { Name = field.Name, Value = fieldValue });
                    }
                }
            }

            //Generate Email

            string subject = "New Purcharse";

            StringBuilder strBuilder = new StringBuilder();
            foreach (var formField in formFieldValues)
            {
                strBuilder.Append($"{formField.Name}: {formField.Value}\n");
            }

            SendEmailHelper.SendEmail("toybox@nofearsnobugs.com", new[] { "example@sitecore.com" }, subject, strBuilder.ToString());



            return true;
        }

        private static string GetValue(object field)
        {
            return field?.GetType().GetProperty("Value")?.GetValue(field, null)?.ToString() ?? string.Empty;
        }

        private static string GetSelectedValue(object field)
        {
            string selectedValue = string.Empty;
            if (field is DropDownListViewModel)
            {
                DropDownListViewModel dropdownField = field as DropDownListViewModel;
                selectedValue = dropdownField.Items.FirstOrDefault(a => a.Selected)?.Value;
            }

            return selectedValue;
        }

        private static string GetSelectedValues(object field)
        {
            string selectedValue = string.Empty;
            if (field is Sitecore.ExperienceForms.Mvc.Models.Fields.ListViewModel)
            {
                ListViewModel listField = field as ListViewModel;
                selectedValue = string.Join("|", listField.Items.Where(a => a.Selected).Select(a => a.Value).ToList());
            }

            return selectedValue;
        }
    }
}