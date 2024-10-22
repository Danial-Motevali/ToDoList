
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Security.Principal;

namespace TaskManager.Application.Utilities
{
    public static class IdentityHelper
    {
        public static int GetUserId(this HttpContext httpContext)
        {
            return Convert.ToInt32(httpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}
