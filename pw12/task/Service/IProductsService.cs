using Microsoft.AspNetCore.Mvc;
using task.Models;

namespace task.Service
{
    public interface IProductsService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetSingleProduct(int id);
        Task<Product> AddProduct(ProductDTO newProduct);
        Task<Product> UpdateProduct(int id, ProductDTO updatedProduct);
        Task<Product> DeleteProduct(int id);
    }
}
