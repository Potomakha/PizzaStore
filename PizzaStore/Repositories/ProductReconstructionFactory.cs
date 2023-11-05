using PizzaStore.Entities;
using PizzaStore.Models;

namespace PizzaStore.Repositories;

public class ProductReconstructionFactory : IProductReconstructionFactory
{
    public ProductEntity Create(Product product) => new()
        { Id = product.Id, Name = product.Name, Price = product.Price, Description = product.Description };

    public void Create(ProductEntity productEntity, Product product)
    {
        productEntity.Name = product.Name;
        productEntity.Price = product.Price;
        productEntity.Description = product.Description;
    }
}