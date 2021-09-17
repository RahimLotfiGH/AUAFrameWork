using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.BaseEntities;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting
{
    [Table("Role", Schema = SchemaConsts.Accounting)]
    public sealed class Role : DomainEntity
    {
        public string Title { get; set; }
     
        public string Description { get; set; }       

        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<UserRoleAccess> UserRoleAccess { get; set; }
    }
}
