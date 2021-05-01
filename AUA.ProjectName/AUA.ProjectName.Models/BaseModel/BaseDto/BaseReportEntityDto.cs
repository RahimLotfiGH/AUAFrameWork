using System;
using System.ComponentModel.DataAnnotations;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Extensions;

namespace AUA.ProjectName.Models.BaseModel.BaseDto
{
    public class BaseReportEntityDto
    {

        [Required(ErrorMessage = MessageConsts.PropertyValueRequired)]
        public DateTime RegistrationDate { get; set; }


        public string RegDatePersian
        {
            get => RegistrationDate.ToPersianDate();
            set => RegistrationDate = value.ToDateTime();
        }

    }



}
