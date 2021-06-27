using CRUDPOC.Application.Developers;
using CRUDPOC.Application.Films;
using CRUDPOC.Data.EfCore.Repository;
using CRUDPOC.Data.Mongo.Repository;
using CRUDPOC.Domain.Config;
using CRUDPOC.Domain.Interfaces;
using CRUDPOC.Domain.models;
using CRUDPOC.Domain.Services;
using CRUDPOC.Infraestructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CRUDPOC.Infraestructure.Common
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureServicesExt(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IMongoDbSettings>(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            return services;
        }

        public static IServiceCollection ConfigureDIServices(this IServiceCollection services, IConfiguration config)
        {
            //services.AddScoped<IFilmService, FilmService>();
            //services.AddScoped<IDeveloperService, DeveloperService>();

            services.AddScoped<IFilmsApi, FilmService>();
            services.AddScoped<IDevelopersApi, DeveloperService>();
            services.AddScoped<IService<Developer>, DeveloperService>();

            services.AddScoped<IRepository<Developer>, DeveloperRepository>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();

            return services;
        }

        public static IServiceCollection ConfigureMongoDb(this IServiceCollection services, IConfiguration config)
        {
            return services;
        }
    }
}