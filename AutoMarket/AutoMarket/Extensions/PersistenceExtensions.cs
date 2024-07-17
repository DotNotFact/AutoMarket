using AutoMarket.Repositories.Abstracts;
using AutoMarket.Services.Abstracts;
using AutoMarket.Repositories.Bases;
using AutoMarket.Services.Bases;
using Microsoft.OpenApi.Models;
using AutoMarket.Entities;
using AutoMarket.Mappers;
using AutoMarket.Data;

namespace AutoMarket.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();

        services
            .AddScoped<IRepository<MakerEntity>, MakersRepository>()
            .AddScoped<IRepository<ModelEntity>, ModelsRepository>();

        services
            .AddScoped<ICarService, CarService>();

        services.AddEndpointsApiExplorer();

        services.AddAutoMapper(typeof(MappingProfile));

        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "1.0",
                Title = "AutoMarket API",
                Description = "Default AutoMarket API.",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Apxauk",
                    Email = "apxauk@gmail.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Example License",
                    Url = new Uri("https://example.com/license")
                }
            });

            c.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Name = "Password",
                Description = "Password"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "JWT",
                        }
                    },
                    Array.Empty<string>()
                }
            }); 
        }); 

        return services;
    }
}