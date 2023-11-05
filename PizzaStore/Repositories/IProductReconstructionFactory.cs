using PizzaStore.Entities;
using PizzaStore.Models;

namespace PizzaStore.Repositories;

public interface IProductReconstructionFactory
{
    public void Create(ProductEntity productEntity, Product product);
    public ProductEntity Create(Product product);
}