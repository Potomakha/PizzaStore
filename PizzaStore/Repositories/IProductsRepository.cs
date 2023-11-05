using PizzaStore.Models;

namespace PizzaStore.Repositories;

public interface IProductsRepository
{
    public Task<List<Product>> GetAll();
    public Task<Product> Get(int id);
    public Task Add(Product product);
    public Task Update(Product product);
    public Task Delete(int id);
}