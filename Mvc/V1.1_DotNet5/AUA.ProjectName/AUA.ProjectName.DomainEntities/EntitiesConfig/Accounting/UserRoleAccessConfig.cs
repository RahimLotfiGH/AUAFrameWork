using AUA.ProjectName.DomainEntities.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUA.ProjectName.DomainEntities.EntitiesConfig.Accounting
{
    public class UserRoleAccessConfig : IEntityTypeConfiguration<UserRoleAccess>
    {
        public void Configure(EntityTypeBuilder<UserRoleAccess> builder)
        {

            builder
                .HasOne(p => p.Role)
                .WithMany(p => p.UserRoleAccess)
                .HasForeignKey(p => p.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(p => p.UserAccess)
                .WithMany(p => p.RoleAccesses)
                .HasForeignKey(p => p.UserAccessId)
                .OnDelete(DeleteBehavior.NoAction);

        }

    }
}
