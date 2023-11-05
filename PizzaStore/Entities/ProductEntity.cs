using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Entities;

public class ProductEntity
{
    [Key] public int? Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; } = null!;

    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}