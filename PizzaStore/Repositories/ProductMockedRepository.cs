using PizzaStore.Models;

namespace PizzaStore.Repositories;

public class ProductMockedRepository : IProductMockedRepository
{
    private static readonly List<Product> Repository = new()
    {
        new(1, "Cheese Pizza", 100),
        new(2, "Tabasco Pizza", 100),
        new(3, "Meat Pizza", 100),
        new(4, "Vegan Pizza", 100),
    };

    public List<Product> GetAll()
    {
        return Repository;
    }

    public Product Get(int id)
    {
        return Repository.First(f => f.Id == id);
    }

    public void Add(Product product)
    {
        var maxId = Repository.Max(m => m.Id) ?? 1;
        var newProduct = new Product(maxId + 1, product.Name, product.Price);
        Repository.Add(newProduct);
    }

    public void Update(Product product)
    {
        if (!product.Id.HasValue)
            throw new ArgumentNullException(nameof(Product.Id));

        var oldProduct = Get((int)product.Id);
        var oldProductIndex = Repository.IndexOf(oldProduct);
        Repository[oldProductIndex] =
            new Product(product.Id, product.Name, product.Price);
    }

    public void Delete(int id)
    {
        var productToRemove = Get(id);
        Repository.Remove(productToRemove);
    }
}