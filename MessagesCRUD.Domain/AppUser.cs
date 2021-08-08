using Microsoft.AspNetCore.Identity;
using System;

namespace MessagesCRUD.Domain
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
