using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    public class UserConfiguration
        : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(u => u.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(u => u.Surname)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(u => u.RegistrationDate)
                .IsRequired();

            builder
                .Property(u => u.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(u => u.PasswordHash)
                .IsRequired();
        }
    }
}
