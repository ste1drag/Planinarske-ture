namespace Reviewing.Domain.Common
{
    public abstract class EntityBase(int Id, DateTime CreateDate, DateTime UpdateDate)
    {
        public int Id { get; protected set; } = Id;
        public DateTime CreatedDate { get; set; } = CreateDate;
        public DateTime UpdatedDate { get; set; } = UpdateDate;
    }
}
