namespace PizzaStore.Models;

public class ProductComponent
{
    public int Id { get; }
    public string Name { get; }

    public ProductComponent(int id, string name)
    {
        Id = id;

        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name));
        Name = name;
    }
}