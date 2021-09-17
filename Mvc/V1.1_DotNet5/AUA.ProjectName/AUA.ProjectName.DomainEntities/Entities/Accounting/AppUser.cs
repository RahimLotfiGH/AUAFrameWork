using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.BaseEntities;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting
{
    [Table("AppUser", Schema = SchemaConsts.Accounting)]
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
