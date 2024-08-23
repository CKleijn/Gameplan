using GameplanAPI.Common.Implementations;

namespace GameplanAPI.Features.User
{
    public sealed class User : Entity
    {
        public string UID { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
    }
}
