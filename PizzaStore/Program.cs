using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using PizzaStore.Models;
using PizzaStore.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ProductDbContext>(options => options.UseInMemoryDatabase("productsDb"));
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1",
        new OpenApiInfo() { Title = "Todo API", Description = "To track your own tasks ", Version = "v1" });
});

builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
builder.Services.AddTransient<IProductReconstructionFactory, ProductReconstructionFactory>();
builder.Services.AddTransient<IProductMapper, ProductMapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s => { s.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1"); });
    app.MapGet("/", () => "Hello World!");
}

// Products API
app.MapGet("/products", (IProductsRepository repository) => repository.GetAll());
app.MapGet("/products/{id:int}", (IProductsRepository repository, int id) => repository.Get(id));

app.MapPost("/products", (IProductsRepository repository, Product product) => repository.Add(product));

app.MapPut("/products", (IProductsRepository repository, Product product) => repository.Update(product));

app.MapDelete("/products", (IProductsRepository repository, int id) => repository.Delete(id));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();