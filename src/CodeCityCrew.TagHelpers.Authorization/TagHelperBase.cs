using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CodeCityCrew.TagHelpers.Authorization
{
    /// <summary>
    /// Tag helper base class.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Razor.TagHelpers.TagHelper" />
    public abstract class TagHelperBase : TagHelper
    {
        /// <summary>
        /// Gets the action context accessor.
        /// </summary>
        /// <value>
        /// The action context accessor.
        /// </value>
        protected IActionContextAccessor ActionContextAccessor { get; }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        protected ClaimsPrincipal User { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TagHelperBase"/> class.
        /// </summary>
        /// <param name="actionContextAccessor">The action context accessor.</param>
        protected TagHelperBase(IActionContextAccessor actionContextAccessor)
        {
            ActionContextAccessor = actionContextAccessor;
            User = ActionContextAccessor.ActionContext.HttpContext.User;
        }
    }
}
