using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CodeCityCrew.TagHelpers.Authorization
{
    [HtmlTargetElement(Attributes = "asp-policy")]
    public class AuthorizationPolicyTagHelper : TagHelperBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationPolicyTagHelper(IAuthorizationService authorizationService, IActionContextAccessor actionContextAccessor) : base(actionContextAccessor)
        {
            _authorizationService = authorizationService;
        }

        public string AspPolicy { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var policies = AspPolicy.Trim().Split(';', ',').ToList();

            foreach (var policy in policies)
            {
                var authorizeAsync = await _authorizationService.AuthorizeAsync(User, policy);

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