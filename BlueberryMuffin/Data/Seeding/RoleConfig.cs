using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlueberryMuffin.Data.Seeding
{
    public static class RoleTypes
    {
        public const string User = "User";
        public const string Admin = "Administrator";
        public const string Manager = "Manager";
    }

    public class RoleConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole { Name = RoleTypes.Admin, NormalizedName = "ADMIN" },
                new IdentityRole { Name = RoleTypes.User, NormalizedName = "USER" },
                new IdentityRole { Name = RoleTypes.Manager, NormalizedName = "MANAGER" }
            );
        }
    }
}
