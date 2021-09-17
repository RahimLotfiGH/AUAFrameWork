namespace AUA.ProjectName.Models.BaseModel.BaseViewModels
{
    public class BaseVm<TPrimaryKey> : GeneralVm<TPrimaryKey>
    {
        public long? CreatorUserId { get; set; }

        public bool IsActive { get; set; }
    }
}
