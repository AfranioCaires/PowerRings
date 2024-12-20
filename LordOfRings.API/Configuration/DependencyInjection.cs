using System.Reflection;
using LordOfRings.App.Commands;
using LordOfRings.App.DTOs;
using LordOfRings.App.Interfaces;
using LordOfRings.Domain.Entities;
using LordOfRings.Infrastructure.Data;
using LordOfRings.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace LordOfRings.API.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AnelDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));
        
        services.AddAutoMapper(cfg =>
        {
            cfg.CreateMap<Anel, AnelDto>();
        });
        
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(CriarAnelCommand).Assembly));

        services.AddScoped<IAnelRepository, AnelRepository>();

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Lord of Rings API",
                Version = "v1",
                Description = "API para gerenciamento dos Anéis de Poder"
            });
            
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });


        return services;
    }
}