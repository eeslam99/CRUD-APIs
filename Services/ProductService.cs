using CRUD_APIs.Models;
using CRUD_APIs.Repository;

namespace CRUD_APIs.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        if (product.Price < 0)
            throw new ArgumentException("Price cannot be negative");

        if (product.Stock < 0)
            throw new ArgumentException("Stock cannot be negative");

        return await _repository.CreateAsync(product);
    }

    public async Task<Product?> UpdateProductAsync(int id, Product product)
    {
        if (product.Price < 0)
            throw new ArgumentException("Price cannot be negative");

        if (product.Stock < 0)
            throw new ArgumentException("Stock cannot be negative");

        return await _repository.UpdateAsync(id, product);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
