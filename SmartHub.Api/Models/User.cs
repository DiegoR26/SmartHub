using Microsoft.AspNetCore.Identity;

namespace SmartHub.Api.Models
{
    public class User : IdentityUser<int>
    {
        public List<IdentityRole<int>>? Roles { get; set; }
    }
}
