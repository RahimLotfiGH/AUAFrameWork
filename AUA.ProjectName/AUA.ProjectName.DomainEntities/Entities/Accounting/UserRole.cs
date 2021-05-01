using AUA.ProjectName.DomainEntities.BaseEntities;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting
{
    public class UserRole : DomainEntity
    {

        public long AppUserId { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual AppUser AppUser { get; set; }


    }
}
