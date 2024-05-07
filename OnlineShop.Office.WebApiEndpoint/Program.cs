using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Services.SaleService;
using OnlineShop.Application.Services.UserManagementService;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using OnlineShop.EFCore;
using OnlineShop.RepositoryDesignPattern.Framework.Abstract;
using OnlineShop.RepositoryDesignPattern.Services.Contracts;
using OnlineShop.RepositoryDesignPattern.Services.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionstring =builder.Configuration.GetConnectionString("OnlineShop");
builder.Services.AddDbContext<OnlineShopDbContext>(option=>option.UseSqlServer(connectionstring));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddIdentity<OnlineShopUser,OnlineShopRole>()
    .AddEntityFrameworkStores<OnlineShopDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = builder.Configuration["JWT:ValidAudience"],
                ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
            };
        });

builder.Services.AddCors(o => o.AddPolicy("MyPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader();
        }));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("MyPolicy");
app.MapControllers();

app.Run();
