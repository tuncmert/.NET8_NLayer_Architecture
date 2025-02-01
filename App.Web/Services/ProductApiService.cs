using App.Services;
using App.Services.Products;
using App.Services.Products.Create;
using App.Services.Products.Update;

namespace App.Web.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResult<List<ProductDto>>>("products");

            return response.Data;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<ServiceResult<ProductDto>>($"products/{id}");
            return response.Data;


        }

        public async Task<ProductDto> SaveAsync(CreateProductRequest newProduct)
        {
            var response = await _httpClient.PostAsJsonAsync("products", newProduct);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<ServiceResult<ProductDto>>();

            return responseBody.Data;


        }
        public async Task<bool> UpdateAsync(int id ,UpdateProductRequest newProduct)
        {
            var response = await _httpClient.PutAsJsonAsync($"products/{id}", newProduct);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"products/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
