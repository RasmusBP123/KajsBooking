using Domain.ProductContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.CreateProduct
{
    public class CreateProductHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(CreateProductCommand message, CancellationToken token)
        {
            var product = Product.Create(Guid.NewGuid(), message.CategoryId, message.BrandId, message.Code);
            await _productRepository.Save(product, token);
        }
    }
}
