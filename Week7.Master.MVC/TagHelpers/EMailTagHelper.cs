using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week7.Master.MVC.TagHelpers
{
    public class EMailTagHelper : TagHelper
    {
        //gli attributi che vogliamo nel nostro tag diventano proprietà della classe

        public string ToUser { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetContent("Mandami e-mail");
            output.Attributes.SetAttribute("class", "btn btn-primary");
            output.Attributes.SetAttribute("href", $"mailto:{ToUser}");
        }
    }
}
