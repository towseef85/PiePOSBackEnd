using Microsoft.EntityFrameworkCore;
using PiePOS.Persistence.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreDbContext>(opt =>
{
    opt.UseSqlServer(configuration.GetConnectionString("StoreConnection"));
});
builder.Services.AddDbContext<InventoryDbContext>(opt =>
{
    opt.UseSqlServer(configuration.GetConnectionString("InventoryConnection"));
});

var app = builder.Build();

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
