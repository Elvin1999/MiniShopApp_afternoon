using OrderService.API.Models;

namespace OrderService.API.Services;

public interface IProductServiceClient
{
    Task<ProductDTO?> GetProductAsync(int productId);

    Task<bool> ReduceStockAsync(
        int productId,
        int quantity);
}