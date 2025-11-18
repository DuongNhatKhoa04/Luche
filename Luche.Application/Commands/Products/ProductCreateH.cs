using Luche.Application.Requests.Products;
using Luche.Domain.Entities;
using Luche.Domain.Interfaces;
using MediatR;

namespace Luche.Application.Commands.Products;

public class ProductCreateH : IRequestHandler<ProductCreateR, int>
{
    private readonly IMediator m_mediator;
    private readonly IProductRepository m_productRepository;

    public ProductCreateH(IProductRepository productRepository, IMediator mediator)
    {
        m_productRepository = productRepository;
        m_mediator = mediator;
    }

    public async Task<int> Handle(ProductCreateR request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Code = request.Code,
            Name = request.Name,
            Category = request.Category,
            Brand = request.Brand,
            Type = request.Type,
            Description = request.Description
        };

        var productId = await m_productRepository.AddProductAsync(product);
        return productId;
    }
}