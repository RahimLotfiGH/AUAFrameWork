namespace AUA.ProjectName.DomainEntities.BaseEntities
{
    public interface ICreationAudited
    {
        long? CreatorUserId { get; set; }

    }
}
