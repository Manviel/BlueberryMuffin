using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlueberryMuffin.Data.Relation
{
    public static class RoleTypes
    {
        public const string User = "User";
        public const string Admin = "Administrator";
        public const string Manager = "Manager";
    }

    public static class IdTypes
    {
        public const string User = "uid";
    }

    public class RoleConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
        }
    }
}
