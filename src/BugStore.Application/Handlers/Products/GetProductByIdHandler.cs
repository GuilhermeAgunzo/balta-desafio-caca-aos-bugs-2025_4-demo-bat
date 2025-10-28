using BugStore.Application.Abstractions.Repositories;
using BugStore.Application.Responses;
using BugStore.Domain.Entities;

namespace BugStore.Application.Handlers.Products;

public class GetProductByIdHandler(IProductRepository productRepository)
{
    public async Task<Response<Product>> Handle(Guid productId, CancellationToken cancellationToken = default)
    {
        var result = await productRepository.GetByIdAsync(productId, cancellationToken);

        if (result.Data is null)
            return new Response<Product>(null, 404, ["Product not found"]);

        return new Response<Product>(result.Data);
    }
}
