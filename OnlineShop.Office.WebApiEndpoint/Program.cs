using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Services.SaleService;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.EFCore;
using OnlineShop.RepositoryDesignPattern.Framework.Abstract;
using OnlineShop.RepositoryDesignPattern.Services.Contracts;
using OnlineShop.RepositoryDesignPattern.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionstring =builder.Configuration.GetConnectionString("OnlineShop");
builder.Services.AddDbContext<OnlineShopDbContext>(option=>option.UseSqlServer(connectionstring));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRepository<Product,Guid>, ProductRepository>();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
