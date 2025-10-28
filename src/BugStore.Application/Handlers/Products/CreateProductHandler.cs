using BugStore.Application.Abstractions.Repositories;
using BugStore.Application.Requests.Products;
using BugStore.Application.Responses;
using BugStore.Domain.Entities;

namespace BugStore.Application.Handlers.Products;

public class CreateProductHandler(IProductRepository productRepository)
{
    public async Task<Response<Product>> Handle(CreateProductRequest req, CancellationToken cancellationToken = default)
    {
        var (product, errors) = Product.Create(req.Title, req.Description, req.Price);

        if (product is null)
        {
            return new Response<Product>(null, 400, [.. errors.Select(e => e.Message)]);
        }

        var result = await productRepository.AddAsync(product, cancellationToken);

        return result.Success
            ? new Response<Product>(result.Data)
            : new Response<Product>(null, 400, [result.ErrorMessage ?? "Unspecified error"]);
    }
}
