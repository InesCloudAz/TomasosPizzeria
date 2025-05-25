using Microsoft.AspNetCore.Identity;

namespace Tomasos.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public int BonusPoints { get; set; }
        public object Address { get; set; }
    }
}
