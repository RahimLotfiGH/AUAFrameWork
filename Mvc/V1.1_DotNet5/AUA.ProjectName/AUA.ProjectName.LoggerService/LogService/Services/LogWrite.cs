using System.Threading.Tasks;
using AUA.ProjectName.Common.Tools.Config.JsonSetting;
using AUA.ProjectName.LoggerServices.LogService.Contracts;
using AUA.ProjectName.Models.GeneralModels.LogModels;

namespace AUA.ProjectName.LoggerServices.LogService.Services
{
    public class LogWrite : ILogWrite
    {
        private readonly ISqlLogService _sqlLogService;

        public LogWrite(ISqlLogService sqlLogService)
        {
            _sqlLogService = sqlLogService;
        }

        public void Add(LogDto logDto)
        {
            if (LogSetting.IsEnableSqlServerLog)
                _sqlLogService.Insert(logDto);

        }

        public async Task AddAsync(LogDto logDto)
        {
            if (LogSetting.IsEnableSqlServerLog)
                await _sqlLogService.InsertAsync(logDto);

        }


    }
}
