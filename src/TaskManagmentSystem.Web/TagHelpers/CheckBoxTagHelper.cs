using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TaskManagmentSystem.Web.TagHelpers
{
    [HtmlTargetElement("checkbox")]
    public class CheckBoxTagHelper : TagHelper
    {
        public string Name { get; set; }
        public bool Checked { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";
            output.Attributes.SetAttribute("type", "checkbox");
            output.Attributes.SetAttribute("id", Name);
            output.Attributes.SetAttribute("name", Name);
            output.Attributes.SetAttribute("value", Checked);

            if (Checked)
            {
                output.Attributes.SetAttribute("checked", string.Empty);
            }
        }
    }
}
