using System.Threading.Tasks;
using AUA.ProjectName.Models.GeneralModels.LogModels;

namespace AUA.ProjectName.LoggerServices.LogService.Contracts
{
    public interface ISqlLogService
    {
        void Insert(LogDto logDto);

        Task InsertAsync(LogDto logDto);

    }
}
