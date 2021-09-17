using System.Text;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.WebUI.Controllers
{
    public class BaseController : InfraController
    {

        protected void FixSearchVm(BaseSearchVm searchVm)
        {
            if (searchVm.PageSize <= 0)
                searchVm.PageSize = AppConsts.UnlimitedPageSize;

            if (searchVm.TotalSize < 0)
                searchVm.TotalSize = 0;

            if (searchVm.PageNumber <= 0)
                searchVm.PageNumber = 1;

        }

        protected void SetAuditInfo<T>(BaseVm<T> baseVm)
        {
            baseVm.CreatorUserId = CurrentUserId;
        }

        protected string CreateLogMessage(params string[] messages)
        {
            var logMessage = new StringBuilder();

            foreach (var message in messages)
                logMessage.Append(message+AppConsts.LogSplitter);

            return logMessage.ToString();
        }

    }
}
