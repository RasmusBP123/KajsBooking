using Domain.Abstraction;
using Domain.ProductContext.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ProductContext
{
    public class Product : AggregateRoot<Guid>
    {
        public Product()
        {
            Register<ProductCreated>(Apply);
        }

        public BrandRef Brand { get; private set; }

        public CategoryRef Category { get; private set; }
        public string Code { get; set; }

        private void Apply(ProductCreated @event)
        {
            Id = @event.ProductId;
            Brand = new BrandRef(@event.BrandId, "");
            Category = new CategoryRef(@event.CategoryId, "");
            Code = @event.ProductCode;
        }

        public static Product Create(Guid id, int categoryId, int brandId, string code)
        {
            var product = new Product();
            product.ApplyChange(new ProductCreated(id, code, brandId, categoryId)); //ApplyChanges comes from AggregateRoot
            return product;
        }
    }
}
