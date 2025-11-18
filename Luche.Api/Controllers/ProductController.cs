using Luche.Application.Requests.Products;
using Luche.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Luche.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator m_mediator;

    public ProductController(IMediator mediator)
    {
        m_mediator = mediator;
    }

    [HttpPost("/product")]
    public async Task<ActionResult<int>> CreateAsync([FromBody] Product product)
    {
        var req = new ProductCreateR(
            product.Code,
            product.Name,
            product.Category,
            product.Brand,
            product.Type,
            product.Description);
        var productId = await m_mediator.Send(req);

        return Ok(productId);
    }

    /*[HttpGet("/products")]
    public async Task<ActionResult<List<Product>>> GetAllAsync()
    {
        var products = await m_mediator.Send(new GetAllProductsQuery());

        return Ok(products);
    }*/

    [HttpGet("/product/{id}")]
    public async Task<ActionResult<Product>> GetByIdAsync(int id)
    {
        var product = await m_mediator.Send(new GetProductByIdR(id));
        return Ok(product);
    }
}