using System.Threading.Tasks;
using AUA.ProjectName.LoggerServices.LogService.Contracts;
using AUA.ProjectName.Models.GeneralModels.LogModels;

namespace AUA.ProjectName.LoggerServices.LogService.Services
{
    public class SqlLogService : ISqlLogService
    {
        public void Insert(LogDto logDto)
        {
            //TODo: Not implemented in this version(This feature is not free)
        }

        public Task InsertAsync(LogDto logDto)
        {
            throw new System.NotImplementedException();
            //TODo: Not implemented in this version(This feature is not free)
        }



    }
}
