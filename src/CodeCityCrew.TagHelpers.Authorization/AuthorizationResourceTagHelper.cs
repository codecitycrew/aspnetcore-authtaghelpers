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

        /// <summary>
        /// Gets or sets the ASP resource.
        /// </summary>
        /// <value>
        /// The ASP resource.
        /// </value>
        public object AspResource { get; set; }

        /// <summary>
        /// Gets or sets the ASP policy.
        /// </summary>
        /// <value>
        /// The ASP policy.
        /// </value>
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
}
