using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.DomainEntities.BaseEntities;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting
{
    [Table("UserAccess", Schema = SchemaConsts.Accounting)]
    public sealed class UserAccess : DomainEntity
    {
        public int ParentId { get; set; }

        public EUserAccess AccessCode { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public bool IsIndirect { get; set; }

        public string PageTitle { get; set; }

        public string PageDescription { get; set; }

        public ICollection<UserRoleAccess> RoleAccesses { get; set; }

    }
}
