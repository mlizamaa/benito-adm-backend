using Benito.Datos;
using Benito.Datos.ECommerce.Modelo;
using Benito.Datos.Repositorio;
using Benito.Negocio;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("./appsettings.Development.json")
        .Build();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRepositorioCrud<Producto>, ProductoRepository>();
builder.Services.AddTransient<IProductoManager, ProductoManager>();
builder.Services.AddSingleton(configuration);
builder.Services.AddTransient<IRepositorioCrud<Producto>, ProductoRepository>();
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

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
