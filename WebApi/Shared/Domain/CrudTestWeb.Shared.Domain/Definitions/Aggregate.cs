using System;
using System.Collections.Generic;

namespace CrudTestWeb.Shared.Domain.Definitions
{
    public class Aggregate
    {
        public string Id { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
