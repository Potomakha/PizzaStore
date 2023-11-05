namespace PizzaStore.Models;

public class Product
{
    public int? Id { get; }
    public string? Name { get; }
    public double Price { get; }
    public string Description { get; }

    public Product(int? id, string? name, double price, string description)
    {
        if (price <= 0)
            throw new AggregateException(nameof(price));

        Id = id;
        Name = name;
        Price = price;
        Description = description;
    }
}