namespace Common.Domain
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; }
        public BaseEntity()
        {
            CreateDate = new DateTime();
        }

    }
}