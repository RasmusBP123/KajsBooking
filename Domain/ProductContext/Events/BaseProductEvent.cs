using Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ProductContext.Events
{
    public abstract class BaseProductEvent : BaseDomainEvent
    {
        public abstract Guid ProductId { get; }
    }
}
