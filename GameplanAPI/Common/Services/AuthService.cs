using GameplanAPI.Common.Services._Interfaces;

namespace GameplanAPI.Common.Services
{
    public sealed class AuthService(IHttpContextAccessor httpContextAccessor)
        : IAuthService
    {
        public string GetCurrentUserId()
        {
            var userId = httpContextAccessor.HttpContext?.Items["UserId"] as string;
            return userId ?? string.Empty;
        }
    }
}
