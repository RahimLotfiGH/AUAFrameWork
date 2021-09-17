namespace AUA.ProjectName.InMemoryServices.Contracts
{
    public interface IInMemoryLockedUsersService
    {
        void Add(long userId);

        void Delete(long userId);

        bool IsExists(long userId);

    }
}
