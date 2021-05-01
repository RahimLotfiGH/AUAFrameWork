using System.Collections.Generic;
using AUA.ProjectName.Common.Enums;

namespace AUA.ProjectName.Models.InMemoryModels.General
{
    public class UserAccessInMemoryVm
    {
        public long  UserId { get; set; }

        public IEnumerable<EUserAccess> UserAccessIds { get; set; }

        public IEnumerable<int> RoleIds { get; set; }

    }
}
