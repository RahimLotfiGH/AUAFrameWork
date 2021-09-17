using AUA.ProjectName.Common.Enums;

namespace AUA.ProjectName.Models.DataModels.AccessTokenDataModels
{
    public class RefreshTokenDm
    {
        public long UserId { get; set; }

        public bool IsAuthenticated { get; set; }

        public EResultStatus ResultStatus { get; set; }

    }
}
