using App.Repositories.Categories;
using App.Repositories.Products;
using App.Services.Categories;
using App.Services.Categories.Create;
using App.Services.Categories.Update;
using App.Services.Filter;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class CategoriesController(ICategoryService categoryService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var serviceResult = await categoryService.GetAllListAsync();
            return CreateActionResult(serviceResult);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var serviceResult = await categoryService.GetByIdAsync(id);
            return CreateActionResult(serviceResult);
        }
        [HttpGet("products")]
        public async Task<IActionResult> GetCategoryWithProduct()
        {
            var serviceResult = await categoryService.GetCategoryWithProductsAsync();
            return CreateActionResult(serviceResult);
        }
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetCategoryWithProduct(int id)
        {
            var serviceResult = await categoryService.GetCategoryWithProductsAsync(id);
            return CreateActionResult(serviceResult);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryRequest request)
        {
            var serviceResult = await categoryService.CreateAsync(request);
            return CreateActionResult(serviceResult);
        }
        [ServiceFilter(typeof(NotFoundFilter<Category, int>))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id , UpdateCategoryRequest request)
        {
            var serviceResult = await categoryService.UpdateAsync(id,request);
            return CreateActionResult(serviceResult);
        }
        [ServiceFilter(typeof(NotFoundFilter<Category, int>))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var serviceResult = await categoryService.DeleteAsync(id);
            return CreateActionResult(serviceResult);
        }
    }
}
