namespace PizzaStore.Models;

public class Product
{
    public int? Id { get; }
    public string? Name { get; }
    public double Price { get; }
    public List<int> ProductComponentsIds { get; }

    public Product(int? id, string? name, double price, List<int> productComponents)
    {
        Id = id;
        Name = name;
        Price = price;
        ProductComponentsIds = productComponents;
    }

    public Product Add(int i)
    {
        if (ProductComponentsIds.Contains(i))
            return this;

        ProductComponentsIds.Add(i);
        return this;
    }
}