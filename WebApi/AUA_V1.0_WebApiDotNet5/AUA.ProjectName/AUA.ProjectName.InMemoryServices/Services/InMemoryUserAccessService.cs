using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using AUA.ProjectName.InMemoryServices.Contracts;
using AUA.ProjectName.Models.InMemoryModels.General;

namespace AUA.ProjectName.InMemoryServices.Services
{
    public class InMemoryUserAccessService : IInMemoryUserAccessService
    {

        private readonly ConcurrentDictionary<long, UserAccessInMemoryVm> _dictionary;

        public InMemoryUserAccessService()
        {
            _dictionary = new ConcurrentDictionary<long, UserAccessInMemoryVm>();
        }

        public void Add(long userId, UserAccessInMemoryVm inMemoryTokenVm)
        {
            _dictionary.TryAdd(userId, inMemoryTokenVm);

        }

        public void Delete(long userId)
        {
            _dictionary.TryRemove(userId, out _);
        }

        public UserAccessInMemoryVm Get(long userId)
        {

            return _dictionary
                    .GetValueOrDefault(userId);

        }

        public void DeleteAll()
        {
            _dictionary.Clear();
        }

        public void DeleteUserTokens(long userId)
        {

            var items = _dictionary
                .Where(p => p.Value.UserId == userId)
                .ToList();

            foreach (var item in items)
                Delete(item.Key);


        }



    }
}
