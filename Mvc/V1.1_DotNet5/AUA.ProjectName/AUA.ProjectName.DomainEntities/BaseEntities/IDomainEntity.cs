namespace AUA.ProjectName.DomainEntities.BaseEntities
{
    public interface IDomainEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }

        bool IsActive { get; set; }
    }

}
