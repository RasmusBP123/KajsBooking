using System;

namespace Domain.ProductContext.Events
{
    public class ProductCreated : BaseProductEvent
    {
        public override Guid ProductId { get; }
        public string ProductCode { get; }
        public int BrandId { get; }
        public int CategoryId { get; }

        public ProductCreated(Guid productId, string productCode, int brandId, int categoryId)
        {
            ProductId = productId;
            ProductCode = productCode;
            BrandId = brandId;
            CategoryId = categoryId;
        }
    }
}
