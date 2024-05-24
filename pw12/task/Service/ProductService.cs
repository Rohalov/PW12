using Microsoft.EntityFrameworkCore;
using task.Data;
using task.Models;

namespace task.Service
{
    public class ProductService : IProductsService
    {
        private ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetSingleProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }

        public async Task<Product> AddProduct(ProductDTO newProduct)
        {
            var product = new Product()
            {
                Name = newProduct.Name,
                Price = newProduct.Price,
                IsInStock = newProduct.IsInStock,
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProduct(int id, ProductDTO updatedProduct)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.IsInStock = updatedProduct.IsInStock;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
