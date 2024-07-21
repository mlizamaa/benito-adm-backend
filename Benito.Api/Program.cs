using Benito.Datos;
using Benito.Model.Entities.ECommerce;
using Benito.Model.Entities.Despensa;
using Benito.Model.Entities.IOT;
using Benito.Datos.Repositorio;
using Benito.Datos.Despensa;
using Benito.Model.Core;
using Benito.Negocio.Managers.ECommerce;
using Benito.Negocio.Managers.Despensa;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

    IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory() )
            .AddJsonFile("appsettings.json", true)
            
            .Build();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddTransient<IRepositorioCrud<Producto>, ProductoRepository>();
    builder.Services.AddTransient<IProductoManager, ProductoManager>();
    builder.Services.AddSingleton(configuration);
    builder.Services.AddDbContext<BenitoDbContext>(options => options.UseSqlServer("Server=localhost,1433; Database=benito; User ID=sa; Password=Marcelo1597;TrustServerCertificate=True;"));    
    builder.Services.AddTransient<IItemRepository, ItemRepository>();
    builder.Services.AddTransient<IBenitoBaseRepository<ItemDespensa>, BenitoBaseRepository<ItemDespensa>>();
    builder.Services.AddTransient<IBenitoBaseRepository<Sensor>, BenitoBaseRepository<Sensor>>();
    builder.Services.AddTransient<IItemManager, ItemManager>();


    //builder.Services.AddTransient<IRepositorioCrud<Producto>, ProductoRepository>();
    builder.Services.AddCors(options =>{
        options.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
    });

    var app = builder.Build();


        // Registra la configuración
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // app.UseHttpsRedirection();
    app.UseCors();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
