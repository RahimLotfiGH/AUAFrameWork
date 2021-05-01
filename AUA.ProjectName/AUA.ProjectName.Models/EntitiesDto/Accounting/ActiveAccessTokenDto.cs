using System;
using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseDto;

namespace AUA.ProjectName.Models.EntitiesDto.Accounting
{
    public class ActiveAccessTokenDto : BaseEntityDto<long>, IMapFrom<ActiveAccessToken>
    {
        public long  UserId { get; set; }

        public string Guid { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string RefreshToken { get; set; }
        
        public string AccessToken { get; set; }


    }
}
