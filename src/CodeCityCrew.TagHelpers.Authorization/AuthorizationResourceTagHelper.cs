using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CodeCityCrew.TagHelpers.Authorization
{
    [HtmlTargetElement(Attributes = "asp-resource,asp-policy")]
    public class AuthorizationResourceTagHelper : TagHelperBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationResourceTagHelper(IAuthorizationService authorizationService, IActionContextAccessor actionContextAccessor) : base(actionContextAccessor)
        {
            _authorizationService = authorizationService;
        }

        public object AspResource { get; set; }
        public string AspPolicy { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var authorizeAsync = await _authorizationService.AuthorizeAsync(User, AspResource, AspPolicy);

            if (!authorizeAsync.Succeeded)
            {
                output.SuppressOutput();
            }

            base.Process(context, output);
        }
    }

    [HtmlTargetElement("bold")]
    [HtmlTargetElement(Attributes = "bold")]
    public class BoldTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.RemoveAll("bold");
            output.PreContent.SetHtmlContent("<strong>");
            output.PostContent.SetHtmlContent("</strong>");
        }
    }
}
