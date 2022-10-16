using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTimeOffset RegistrationDate { get; set; } =
            DateTimeOffset.UtcNow;

        public ICollection<RefreshToken> RefreshTokens { get; set; } =
                new List<RefreshToken>();
    }
}
