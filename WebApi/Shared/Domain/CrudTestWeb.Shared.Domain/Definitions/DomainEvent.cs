using System;

namespace CrudTestWeb.Shared.Domain.Definitions
{
    public class DomainEvent
    {
        protected DomainEvent()
        {
            DateOccurred = DateTimeOffset.UtcNow;
        }

        public string id { get; set; } = Guid.NewGuid().ToString();
        public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;


    }
}
