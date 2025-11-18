using Luche.Domain.Entities;
using MediatR;

namespace Luche.Application.Requests.Products;

public record GetAllProductsR() : IRequest<List<Product>>;

public record GetProductByIdR(int Id) : IRequest<Product?>;