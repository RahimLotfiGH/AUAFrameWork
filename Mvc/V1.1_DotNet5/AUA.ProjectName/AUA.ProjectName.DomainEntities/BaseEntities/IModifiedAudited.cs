using System;

namespace AUA.ProjectName.DomainEntities.BaseEntities
{
   public interface IModifiedAudited
    {

        long? ModifierUserId { get; set; }

        DateTime? ModifyDate { get; set; }

    }
}
