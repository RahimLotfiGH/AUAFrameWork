using System.ComponentModel.DataAnnotations.Schema;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.BaseEntities;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting
{
    [Table("UserRoleAccess", Schema = SchemaConsts.Accounting)]
    public sealed class UserRoleAccess : DomainEntity
    {
        public int RoleId { get; set; }

        public int UserAccessId { get; set; }

        public Role Role { get; set; }

        public UserAccess UserAccess { get; set; }
    }
}
