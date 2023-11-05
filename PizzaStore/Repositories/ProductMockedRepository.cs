using PizzaStore.Models;

namespace PizzaStore.Repositories;

public class ProductMockedRepository : IProductMockedRepository
{
    private static List<Product> _repository;

    public ProductMockedRepository()
    {
        _repository = new List<Product>()
        {
            new(1, "Cheese Pizza", 100, new List<int>() { 1, 2, 3 }),
            new(2, "Tabasco Pizza", 100, new List<int>() { 1, 2, 3 }),
            new(3, "Meat Pizza", 100, new List<int>() { 1, 2, 3 }),
            new(4, "Vegan Pizza", 100, new List<int>() { 1, 2, 3 }),
        };
    }

    public List<Product> GetAll()
    {
        return _repository;
    }

    public Product Get(int id)
    {
        return _repository.First(f => f.Id == id);
    }

    public void Add(Product product)
    {
        var maxId = _repository.Max(m => m.Id) ?? 1;
        var newProduct = new Product(maxId, product.Name, product.Price, product.ProductComponentsIds);
        _repository.Add(newProduct);
    }

    public void Update(Product product)
    {
        if (!product.Id.HasValue)
            throw new ArgumentNullException(nameof(Product.Id));

        var oldProduct = Get((int)product.Id);
        var oldProductIndex = _repository.IndexOf(oldProduct);
        _repository[oldProductIndex] =
            new Product(product.Id, product.Name, product.Price, product.ProductComponentsIds);
    }

    public void Delete(int id)
    {
        var productToRemove = Get(id);
        _repository.Remove(productToRemove);
    }
}