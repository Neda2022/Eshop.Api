namespace Common.Domain
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public BaseEntity()
        {
            CreateDate = new DateTime();
        }

    }
}