using MediatR;

namespace Luche.Application.Requests.Products;

public record ProductCreateR(string Code, string Name, string Category, string Brand, string Type, string Description) : IRequest<int>;