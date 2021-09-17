using System.Collections.Generic;
using AUA.ProjectName.InMemoryServices.Contracts;

namespace AUA.ProjectName.InMemoryServices.Services
{

    public class InMemoryLockedUsersService : IInMemoryLockedUsersService
    {
        private readonly List<long> _userIds;

        public InMemoryLockedUsersService()
        {
            _userIds = new List<long>();
        }

        public void Add(long userId)
        {
            if (!IsExists(userId))
                _userIds.Add(userId);
        }

        public void Delete(long userId)
        {
            if (IsExists(userId))
                _userIds.Remove(userId);
        }

        public bool IsExists(long userId)
        {
            return _userIds.Contains(userId);
        }
    }
}
