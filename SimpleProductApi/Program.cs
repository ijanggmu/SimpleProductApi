using Microsoft.EntityFrameworkCore;
using SimpleProductApi.Data;
using SimpleProductApi.Middleware;
using SimpleProductApi.Repository;
using SimpleProductApi.Repository.Product;
using SimpleProductApi.Services.Product;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductService>();
var app = builder.Build();
//AutoMigration();
app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
void AutoMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var data = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        if (data.Database.GetPendingMigrations().Any())
        {
            data.Database.MigrateAsync();
        }
    }
}