using System.Threading.Tasks;
using AUA.ProjectName.Models.GeneralModels.LogModels;

namespace AUA.ProjectName.LoggerServices.LogService.Contracts
{
    public interface ILogWrite
    {
        void Add(LogDto logDto);

        Task AddAsync(LogDto logDto);

    }
}