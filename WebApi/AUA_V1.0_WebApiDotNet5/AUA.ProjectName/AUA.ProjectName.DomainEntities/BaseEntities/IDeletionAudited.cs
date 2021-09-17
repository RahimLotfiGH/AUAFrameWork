using System;

namespace AUA.ProjectName.DomainEntities.BaseEntities
{
    public interface IDeletionAudited : ISoftDelete
    {
        long? DeleterUserId { get; set; }

        DateTime? DeletionDate { get; set; }

    }
}
