using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace RentCore.Application.Common.Helpers
{
    public static class UserHelper
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static string GetBearerToken()
        {
            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
                throw new UnauthorizedAccessException("Bearer token is not present or invalid");

            // Extract the token by removing the "Bearer " prefix
            var token = authorizationHeader.Substring("Bearer ".Length).Trim();

            return token;
        }

        public static string GetUserId()
        {
            if(_httpContextAccessor == null || _httpContextAccessor.HttpContext == null || !_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return null;
            }
            if(_httpContextAccessor.HttpContext.User.Identity == null || _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                throw new UnauthorizedAccessException("User is not authenticated");
            }

            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var id = claims.Where(x => x.Type == ClaimTypes.NameIdentifier)?.FirstOrDefault()?.Value;

            return id;
        }

        public static string GetUserEmail()
        {
            if (_httpContextAccessor == null || _httpContextAccessor.HttpContext == null || !_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return null;
            }
            if (_httpContextAccessor.HttpContext.User.Identity == null || _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                throw new UnauthorizedAccessException("User is not authenticated");
            }
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var email = claims.Where(x => x.Type == ClaimTypes.Email)?.FirstOrDefault()?.Value;

            return email;
        }

        public static string GetFullName()
        {
            if (_httpContextAccessor == null || _httpContextAccessor.HttpContext == null || !_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return null;
            }
            if (_httpContextAccessor.HttpContext.User.Identity == null || _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                throw new UnauthorizedAccessException("User is not authenticated");
            }
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var firstName = claims.Where(x => x.Type == ClaimTypes.GivenName)?.FirstOrDefault()?.Value;
            var lastName = claims.Where(x => x.Type == ClaimTypes.Surname)?.FirstOrDefault()?.Value;
            var middleName = claims.FirstOrDefault(x => x.Type == "middle_name")?.Value;
            var fullName = "";
            fullName += firstName + " ";
            if (!string.IsNullOrEmpty(middleName))
            {
                fullName += middleName + " ";
            }
            fullName += lastName;
            return fullName;
        }
    }
}
