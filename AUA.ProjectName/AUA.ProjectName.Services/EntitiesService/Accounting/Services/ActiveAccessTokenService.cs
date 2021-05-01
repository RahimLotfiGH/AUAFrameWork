using AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ServiceInfrastructure.BaseServices;
using AutoMapper;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Services
{
    public class ActiveAccessTokenService : GenericEntityService<ActiveAccessToken, ActiveAccessTokenDto,long>, IActiveAccessTokenService
    {
        public ActiveAccessTokenService(IUnitOfWork unitOfWork, IMapper mapperInstance) : base(unitOfWork,mapperInstance)
        {

        }

    }
}
