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
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Threading.Tasks;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

    IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true)
            .Build();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddTransient<IRepositorioCrud<Producto>, ProductoRepository>();
    builder.Services.AddTransient<IProductoManager, ProductoManager>();
    builder.Services.AddSingleton(configuration);
    builder.Services.AddDbContext<BenitoDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("sql")));    
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

    // Configurar la autenticación JWT
    var key = Encoding.ASCII.GetBytes(configuration.GetSection("Jwt:Key").Value); 
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

    builder.Services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = @"Autenticacion mediante el esquema JWT \r\n\r\n 
                            Ingrese 'Bearer' [espacio] y el token obtenido en la autenticación. \r\n\r\n
                            Ejemplo: 'Bearer 12345abcdef'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });
    });

    builder.Services.AddControllers();

    var app = builder.Build();


        // Registra la configuración
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseDeveloperExceptionPage();
    }

    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseCors();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.MapControllers();

    app.Run();
