using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUA.ProjectName.DomainEntities.EntitiesConfig.Accounting
{
    public class UserAccessConfig : IEntityTypeConfiguration<UserAccess>
    {
        public void Configure(EntityTypeBuilder<UserAccess> builder)
        {

            builder
                .Property(p => p.Title)
                .HasMaxLength(LengthConsts.MaxStringLen250);


            builder
                .Property(p => p.PageTitle)
                .HasMaxLength(LengthConsts.MaxStringLen250);

            builder
                .Property(p => p.PageDescription)
                .HasMaxLength(LengthConsts.MaxStringLen250);

            builder
                .Property(p => p.Url)
                .HasMaxLength(LengthConsts.MaxStringLen250);


            //builder
            //    .HasQueryFilter(p => p.IsActive);
        }

    }
}
