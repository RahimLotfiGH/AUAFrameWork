using AUA.ProjectName.Common.Extensions;
using System;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.Models.BaseModel.BaseDto
{
    public class BaseEntityDto<TPrimaryKey> : BaseVm<TPrimaryKey>, IBaseEntityDto
    {
        public DateTime RegistrationDate { get; private protected set; }

    

    }



}
