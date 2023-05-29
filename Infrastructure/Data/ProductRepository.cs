using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(product => product.ProductType)
                .Include(product => product.ProductBrand)
                .FirstOrDefaultAsync(product => product.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            // with Include() we say that we need that property to be returned
            // otherwise there will be null
            return await _context.Products
                .Include(product => product.ProductType)
                .Include(product => product.ProductBrand)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToArrayAsync();
        }
    }
}
