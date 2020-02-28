using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.CreateProduct
{
    public class CreateProductCommand 
    {
        public CreateProductCommand(int categoryId, int brandId, string code)
        {
            CategoryId = categoryId;
            BrandId = brandId;
            Code = code;
        }

        public int CategoryId { get; }
        public int BrandId { get; }
        public string Code { get; }
    }
}
