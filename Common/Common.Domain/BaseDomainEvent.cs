using MediatR;

namespace Common.Domain
{
    public class BaseDomainEvent : INotification
    {

        public DateTime CreateDate { get; protected set; }
        public BaseDomainEvent()
        {
            CreateDate = DateTime.Now;
        }

    }
}