using System;

namespace AUA.ProjectName.DomainEntities.BaseEntities
{

    public class DomainEntity<TPrimaryKey> : BaseDomainEntity<TPrimaryKey>, IAuditInfo, ICreationAudited
    {
        public DateTime RegistrationDate { get; set; }

        public long? CreatorUserId { get; set; }

    }
}