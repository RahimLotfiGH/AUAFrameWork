using AUA.ProjectName.Models.InMemoryModels.General;

namespace AUA.ProjectName.InMemoryServices.Contracts
{
    public interface IInMemoryUserAccessService
    {
        void Add(long userId, UserAccessInMemoryVm inMemoryTokenVm);

        void Delete(long userId);

        UserAccessInMemoryVm Get(long userId);

        void DeleteAll();

        void DeleteUserTokens(long userId);


    }
}
