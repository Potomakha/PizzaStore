using Microsoft.EntityFrameworkCore;
using PizzaStore.Entities;
using PizzaStore.Models;

namespace PizzaStore.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly ProductDbContext _dbContext;
    private readonly IProductReconstructionFactory _reconstructionFactory;
    private readonly IProductMapper _mapper;

    public ProductsRepository(ProductDbContext dbContext, IProductMapper mapper,
        IProductReconstructionFactory reconstructionFactory)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _reconstructionFactory = reconstructionFactory;
    }

    public async Task<List<Product>> GetAll()
    {
        return await Get().Select(s => _mapper.Map(s)).ToListAsync();
    }

    public async Task<Product> Get(int id)
    {
        var productEntity = await GetOne(id);
        return _mapper.Map(productEntity);
    }

    public async Task Add(Product product)
    {
        var productEntity = _reconstructionFactory.Create(product);
        await _dbContext.AddAsync(productEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {
        if (!product.Id.HasValue)
            throw new ArgumentNullException(nameof(Product.Id));

        var productEntity = await GetOne((int)product.Id);
        _reconstructionFactory.Create(productEntity, product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var productEntity = await GetOne(id);
        _dbContext.Remove(productEntity);
        await _dbContext.SaveChangesAsync();
    }

    private IQueryable<ProductEntity> Get() => _dbContext.ProductEntities;
    private async Task<ProductEntity> GetOne(int id) => await _dbContext.ProductEntities.FirstAsync(f => f.Id == id);


    private async Task<ProductEntity?> GetOneOrDefault(int id) =>
        await _dbContext.ProductEntities.FindAsync(id);
}