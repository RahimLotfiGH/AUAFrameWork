using System;
using AUA.ProjectName.DomainEntities.BaseEntities;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting
{
    public class ActiveAccessToken : DomainEntity<long>
    {
        public long UserId { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string RefreshToken { get; set; }

        public string AccessToken { get; set; }


    }
}
