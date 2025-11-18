using Luche.Application.Requests.Products;
using Luche.Domain.Entities;
using Luche.Domain.Interfaces;
using MediatR;

namespace Luche.Application.Queries.Products;

public class ProductSearchH : IRequestHandler<GetProductByIdR, Product>
{
    private readonly IMediator m_mediator;
    private readonly IProductRepository m_productRepository;

    public ProductSearchH(IProductRepository productRepository, IMediator mediator)
    {
        m_productRepository = productRepository;
        m_mediator = mediator;
    }

    public async Task<Product> Handle(GetProductByIdR request, CancellationToken cancellationToken)
    {
        var product = await m_productRepository.GetProductByIdAsync(request.Id);

        return product;
    }
}