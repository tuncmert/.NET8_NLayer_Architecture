namespace App.Repositories.Products
{
    public interface IProductRepository:IGenericRepository<Product,int>
    {
        public Task<List<Product>> GetTopPriceProductAsnyc(int count);
    }
}
