using System.Net.Http.Json;
using OrderService.API.Models;

namespace OrderService.API.Services;

public class ProductServiceClient : IProductServiceClient
{
    private readonly HttpClient _httpClient;

    public ProductServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ProductDTO?> GetProductAsync(int productId)
    {
        var response = await _httpClient.GetAsync(
            $"api/products/{productId}");

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content
            .ReadFromJsonAsync<ProductDTO>();
    }

    public async Task<bool> ReduceStockAsync(
        int productId,
        int quantity)
    {
        var request = new ReduceStockRequest
        {
            Quantity = quantity
        };

        var response = await _httpClient.PutAsJsonAsync(
            $"api/products/{productId}/reduce-stock",
            request);

        return response.IsSuccessStatusCode;
    }
}