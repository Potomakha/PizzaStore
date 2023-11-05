using PizzaStore.Entities;
using PizzaStore.Models;

namespace PizzaStore.Repositories;

public interface IProductMapper
{
    public Product Map(ProductEntity productEntity);
}