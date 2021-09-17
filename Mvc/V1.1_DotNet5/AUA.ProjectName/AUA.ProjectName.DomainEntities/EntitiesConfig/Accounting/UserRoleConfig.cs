using AUA.ProjectName.DomainEntities.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUA.ProjectName.DomainEntities.EntitiesConfig.Accounting
{
    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {

            builder
                .HasOne(p => p.AppUser)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(p => p.AppUserId)
                .OnDelete(DeleteBehavior.NoAction);


            builder
                .HasOne(p => p.Role)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(p => p.RoleId)
                .OnDelete(DeleteBehavior.NoAction); ;
            
        }

    }
}
