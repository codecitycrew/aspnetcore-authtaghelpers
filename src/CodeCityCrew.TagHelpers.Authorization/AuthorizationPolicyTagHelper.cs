using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CodeCityCrew.TagHelpers.Authorization
{
    [HtmlTargetElement(Attributes = "asp-policy")]
    public class AuthorizationPolicyTagHelper : TagHelper
    {
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationPolicyTagHelper(IAuthorizationService authorizationService,
            IActionContextAccessor actionContextAccessor)
        {
            _authorizationService = authorizationService;
            _actionContextAccessor = actionContextAccessor;
        }

        public string AspPolicy { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = _actionContextAccessor.ActionContext.HttpContext.User;

            var policies = AspPolicy.Trim().Split(';', ',').ToList();

            foreach (var policy in policies)
            {
                var authorizeAsync = await _authorizationService.AuthorizeAsync(user, policy);

                if (authorizeAsync.Succeeded)
                {
                    base.Process(context, output);
                    return;
                }
            }

            output.SuppressOutput();
        }
    }
}