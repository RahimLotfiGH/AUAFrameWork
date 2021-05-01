using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUA.ProjectName.DomainEntities.EntitiesConfig.Accounting
{
    public class ActiveAccessTokenConfig : IEntityTypeConfiguration<ActiveAccessToken>
    {
        public void Configure(EntityTypeBuilder<ActiveAccessToken> builder)
        {

            builder
                .Property(p => p.AccessToken)
                .HasMaxLength(LengthConsts.MaxStringLen2000);

            builder
                .Property(p => p.RefreshToken)
                .HasMaxLength(LengthConsts.MaxStringLen200);

        }

    }
}
