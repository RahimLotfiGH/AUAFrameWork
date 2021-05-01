using System.Collections.Generic;
using AUA.ProjectName.DomainEntities.BaseEntities;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting
{
    public sealed class AppUser: DomainEntity<long>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public ICollection<UserRole>  UserRoles { get; set; }
            
    }
}
