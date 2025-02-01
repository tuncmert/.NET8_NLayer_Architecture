using App.Repositories.Products;
using App.Services.Products;
using App.Services.Products.Update;
using App.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Web.Controllers
{
    public class ProductsController(CategoryApiService categoryApiService, ProductApiService productApiService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            return View(await productApiService.GetProductsAsync());
        }
        //[ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> Update(int id)
        {
            var product = await productApiService.GetByIdAsync(id);


            var categoriesDto = await categoryApiService.GetAllAsync();



            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", product.CategoryId);

            return View(product);

        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var product = new UpdateProductRequest(productDto.Name, productDto.Price, productDto.Stock, productDto.CategoryId);
                await productApiService.UpdateAsync(productDto.Id, product);

                return RedirectToAction(nameof(Index));

            }

            var categoriesDto = await categoryApiService.GetAllAsync();



            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", productDto.CategoryId);

            return View(productDto);

        }
    }
}
