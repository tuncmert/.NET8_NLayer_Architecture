using App.Repositories.Products;
using App.Services.Filter;
using App.Services.Products;
using App.Services.Products.Create;
using App.Services.Products.Update;
using App.Services.Products.UpdateStock;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{

    public class ProductsController(IProductService productService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var serviceResult = await productService.GetAllListAsync();
            return CreateActionResult(serviceResult);
        }
        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedAll(int pageNumber, int pageSize)
        {
            var serviceResult = await productService.GetPagedAllListAsync(pageNumber, pageSize);
            return CreateActionResult(serviceResult);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var serviceResult = await productService.GetByIdAsync(id);
            return CreateActionResult(serviceResult);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var serviceResult = await productService.CreateAsync(request);
            return CreateActionResult(serviceResult);
        }
        [ServiceFilter(typeof(NotFoundFilter<Product, int>))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateProductRequest request)
        {
            var serviceResult = await productService.UpdateAsync(id, request);
            return CreateActionResult(serviceResult);
        }

        [HttpPatch("stock")] //or HttpPut
        public async Task<IActionResult> UpdateStock(UpdateProductStockRequest request)
        {
            var serviceResult = await productService.UpdateStockAsync(request);
            return CreateActionResult(serviceResult);
        }

        [ServiceFilter(typeof(NotFoundFilter<Product,int>))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var serviceResult = await productService.DeleteAsync(id);
            return CreateActionResult(serviceResult);
        }
    }
}
