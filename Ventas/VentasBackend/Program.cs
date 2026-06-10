using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using VentasBackend.Data;
using VentasBackend.Repositories.Implementation;
using VentasBackend.Repositories.Interfaces;
using VentasBackend.UnitOfWork.Implementation;
using VentasBackend.UnitOfWork.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=LocalConnection"));
builder.Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<ICategoriasRepository, CategoriasRepository>();
builder.Services.AddScoped<ICategoriasUnitOfWork, CategoriasUnitOfWork>();
builder.Services.AddScoped<IClientesRepository, ClientesRepository>();
builder.Services.AddScoped<IClientesUnitOfWork, ClientesUnitOfWork>();
builder.Services.AddScoped<ITiendasRepository, TiendasRepository>();
builder.Services.AddScoped<ITiendasUnitOfWork, TiendasUnitOfWork>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // tu frontend
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
builder.Services.AddTransient<SeedDb>();
var app = builder.Build();
SeedData(app);

void SeedData(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory!.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeedDb>();
        service!.SeedAsync().Wait();
    }
}

// 👇 Activa la política CORS antes de MapControllers()
app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
