using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CodeCityCrew.TagHelpers.Authorization
{
    [HtmlTargetElement(Attributes = "asp-resource,asp-policy")]
    public class AuthorizationResourceTagHelper : TagHelper
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IActionContextAccessor _actionContextAccessor;

        public AuthorizationResourceTagHelper(IAuthorizationService authorizationService, IActionContextAccessor actionContextAccessor)
        {
            _authorizationService = authorizationService;
            _actionContextAccessor = actionContextAccessor;
        }

        public object AspResource { get; set; }
        public string AspPolicy { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = _actionContextAccessor.ActionContext.HttpContext.User;

            var authorizeAsync = await _authorizationService.AuthorizeAsync(user, AspResource, AspPolicy);

            if (!authorizeAsync.Succeeded)
            {
                output.SuppressOutput();
            }

            base.Process(context, output);
        }
    }
}
