using PizzaStore.Models;

namespace PizzaStore.Repositories;

public interface IProductMockedRepository
{
    public List<Product> GetAll();
    public Product Get(int id);
    public void Add(Product product);
    public void Update(Product product);
    public void Delete(int id);
}