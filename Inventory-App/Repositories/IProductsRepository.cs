using Inventory_App.Models;

namespace Inventory_App.Repositories
{
    public interface IProductsRepository
    {
        Task<int> Create(ProductModel productModel);
        Task Delete(int id);
        Task<IEnumerable<ProductModel>> GetAll();
        Task<ProductModel?> GetById(int id);
        Task Update(ProductModel productModel);
    }
}