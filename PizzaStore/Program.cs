using Microsoft.AspNetCore.Authentication.JwtBearer;
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
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1",
        new OpenApiInfo() { Title = "Todo API", Description = "To track your own tasks ", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s => { s.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1"); });
    app.MapGet("/", () => "Hello World!");
}

var productMockedRepository = new ProductMockedRepository();
// Products API
app.MapGet("/products", () => productMockedRepository.GetAll());
app.MapGet("/products/{id:int}", (int id) => productMockedRepository.Get(id));

app.MapPost("/products", (Product product) =>
{
    productMockedRepository.Add(product);
});

app.MapPut("/products", (Product product) => productMockedRepository.Update(product));

app.MapDelete("/products", (int id) => productMockedRepository.Delete(id));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();