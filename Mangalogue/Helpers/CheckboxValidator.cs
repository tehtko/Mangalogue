using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;

namespace Mangalogue.Helpers
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class CheckBoxRequiredAttribute : ValidationAttribute, IClientModelValidator
    {
        #region ValidationAttribute Support
        public override bool IsValid(object value) => value is bool thisValue && thisValue;
        #endregion

        #region IClientModelValidator Support
        public void AddValidation(ClientModelValidationContext context) => context.Attributes.Add("data-val-checkboxrequired", FormatErrorMessage(context.ModelMetadata.GetDisplayName()));
        #endregion    

    }

    [HtmlTargetElement(Attributes = "validator-unobtrusive-adapter")]
    public class ScriptValidatorUnobtrusiveAdapterTagHelper : TagHelper
    {

        [HtmlAttributeName(DictionaryAttributePrefix = "bool-validator-")]
        public Dictionary<string, string> BoolValidator { get; set; } = new Dictionary<string, string>();

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (output.TagName != "script")
            {
                throw new ArgumentException(output.TagName + " is not a valid element for " + nameof(ScriptValidatorUnobtrusiveAdapterTagHelper));
            }
            // remove the attributes used to configure tag helper so user cannot see them
            output.Attributes.RemoveAll("validator-unobtrusive-adapter");
            output.Attributes.RemoveAll("bool-validator-");

            // Add in ability for unobtrusive validation on client side
            output.PreContent.AppendHtml("(function ($) {");
            if (this.BoolValidator?.Count > 0)
            {
                foreach (KeyValuePair<string, string> kvp in this.BoolValidator)
                {
                    output.PreContent.AppendFormat("$.validator.unobtrusive.adapters.addBool(\"{0}\", \"{1}\");", kvp.Key, kvp.Value);
                }
            }
            output.PreContent.AppendHtml("}(jQuery));");
        }
    }
}