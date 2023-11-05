using PizzaStore.Entities;
using PizzaStore.Models;

namespace PizzaStore.Repositories;

public class ProductMapper : IProductMapper
{
    public Product Map(ProductEntity productEntity) => new(productEntity.Id, productEntity.Name, productEntity.Price,
        productEntity.Description);
}