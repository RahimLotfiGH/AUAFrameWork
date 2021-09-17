using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUA.ProjectName.DomainEntities.EntitiesConfig.Accounting
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            builder
                .Property(p => p.Title)
                .HasMaxLength(LengthConsts.MaxStringLen50);

            builder
                .Property(p => p.Description)
                .HasMaxLength(LengthConsts.MaxStringLen250);

            //builder
            //    .HasQueryFilter(p => p.IsActive);
        }

    }
}
