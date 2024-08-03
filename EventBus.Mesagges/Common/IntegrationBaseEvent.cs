namespace EventBus.Mesagges.Common
{
    public abstract class IntegrationBaseEvent
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }

        protected IntegrationBaseEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        protected IntegrationBaseEvent(Guid id, DateTime creationDate)
        {
            Id = id;
            CreationDate = creationDate;          
        }
    }
}
