using Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ProductContext
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
    }
}
