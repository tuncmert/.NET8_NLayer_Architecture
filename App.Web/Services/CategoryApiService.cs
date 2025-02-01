using App.Services;
using App.Services.Categories.Dto;

namespace App.Web.Services
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {


            _httpClient = httpClient;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResult<List<CategoryDto>>>("categories");
            return response.Data;
        }
    }
}
