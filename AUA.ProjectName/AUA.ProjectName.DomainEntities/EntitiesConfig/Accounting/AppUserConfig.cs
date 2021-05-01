using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUA.ProjectName.DomainEntities.EntitiesConfig.Accounting
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            
            builder
                .Property(p => p.FirstName)
                .HasMaxLength(LengthConsts.MaxStringLen50);
            
            builder
                .Property(p => p.LastName)
                .HasMaxLength(LengthConsts.MaxStringLen50);
            
            builder
                .Property(p => p.UserName)
                .HasMaxLength(LengthConsts.MaxStringLen50);
            
            builder
                .Property(p => p.Password)
                .HasMaxLength(LengthConsts.MaxStringLen250);
            
            builder
                .Property(p => p.Phone)
                .HasMaxLength(LengthConsts.MaxStringLen25);
            
            builder
                .Property(p => p.Email)
                .HasMaxLength(LengthConsts.MaxStringLen100);
            
            builder
                .Property(p => p.IsActive)
                .IsRequired();

        }

    }
}
