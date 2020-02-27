using Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ProductContext
{
    public class Product : AggregateRoot<Guid>
    {
        public Product()
        {
        }
    }
}
