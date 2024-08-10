using Microsoft.AspNetCore.Identity;

namespace Authentication.Api.Models
{
    public class DWUser : IdentityUser
    {
        public Guid Tenant { get; set; }
        public string? BadgeNumber { get; set; }
    }
}
