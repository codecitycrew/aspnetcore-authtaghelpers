using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CodeCityCrew.TagHelpers.Authorization
{
    [HtmlTargetElement(Attributes = "asp-is-signed")]
    public class AspIsSignedTagHelper : TagHelperBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AspIsSignedTagHelper(IActionContextAccessor actionContextAccessor, SignInManager<IdentityUser> signInManager) : base(actionContextAccessor)
        {
            _signInManager = signInManager;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [ASP is signed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [ASP is signed]; otherwise, <c>false</c>.
        /// </value>
        public bool AspIsSigned { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (_signInManager.IsSignedIn(User) == AspIsSigned)
            {
                return;
            }

            output.SuppressOutput();
        }
    }
}