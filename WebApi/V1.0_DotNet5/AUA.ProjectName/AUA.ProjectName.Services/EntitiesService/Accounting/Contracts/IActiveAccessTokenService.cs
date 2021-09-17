using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ServiceInfrastructure.BaseServices;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Contracts
{
    public interface IActiveAccessTokenService : IGenericEntityService<ActiveAccessToken, ActiveAccessTokenDto, long>
    {


    }
}
