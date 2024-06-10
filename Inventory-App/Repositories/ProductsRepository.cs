using Inventory_App.Data;
using Inventory_App.DTOs;
using Inventory_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory_App.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductsRepository(ApplicationDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public async Task<IEnumerable<ProductModel>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<ProductModel?> GetById(int id)
        {
            return await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> Create(ProductModel productModel)
        {
            _dbContext.Add(productModel);
            await _dbContext.SaveChangesAsync();
            return productModel.Id;
        }

        public async Task Update(ProductModel productModel)
        {

            _dbContext.Update(productModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _dbContext.Products.Where(p => p.Id == id).ExecuteDeleteAsync();
        }
    }
}
