using System.Linq;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CodeCityCrew.TagHelpers.Authorization
{
    [HtmlTargetElement(Attributes = "asp-role")]
    public class AuthorizationRoleTagHelper : TagHelper
    {
        private readonly IActionContextAccessor _actionContextAccessor;

        public AuthorizationRoleTagHelper(IActionContextAccessor actionContextAccessor)
        {
            _actionContextAccessor = actionContextAccessor;
        }

        public string AspRole { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var user = _actionContextAccessor.ActionContext.HttpContext.User;

            var roles = AspRole.Trim().Split(';', ',').ToList();

            var hasAccess = roles.Any(role => user.IsInRole(role));

            if (!hasAccess)
            {
                output.SuppressOutput();
            }

            base.Process(context, output);
        }
    }
}
