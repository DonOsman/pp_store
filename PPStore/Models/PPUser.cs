using Microsoft.AspNetCore.Identity;

namespace PPStore.Models
{
    public class PPUser : IdentityUser
    {
        public Address Address { get; set; }
    }
}