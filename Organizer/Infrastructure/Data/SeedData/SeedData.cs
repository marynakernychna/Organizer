using Core.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Data.SeedData
{
    public static class SeedData
    {
        private static readonly string ROLE_CLIENT_ID = Guid.NewGuid().ToString();

        public static void Seed(this ModelBuilder builder)
        {
            SeedIdentityRole(builder);
        }

        public static void SeedIdentityRole(ModelBuilder builder) =>
            builder.Entity<IdentityRole>()
                   .HasData(
                        new IdentityRole()
                        {
                            Id = ROLE_CLIENT_ID,
                            Name = IdentityRoleNames.Client.ToString(),
                            NormalizedName = IdentityRoleNames.Client.ToString().ToUpper(),
                            ConcurrencyStamp = ROLE_CLIENT_ID
                        });
    }
}
