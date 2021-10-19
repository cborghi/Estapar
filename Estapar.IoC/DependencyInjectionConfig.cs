using Estapar.Business.Services;
using Estapar.DB.Repositories;
using Estapar.Interfaces.Repositories;
using Estapar.Interfaces.Services;
using Estapar.Model.ValueObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estapar.IoC
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration config, IHostEnvironment env)
        {

            services.AddSingleton(new RepositoryConfiguration
            {
                ConnectionString = config.GetValue<string>("DB_CONNECTION")
            });

            services.AddScoped<IManobristaRepository, ManobristaRepository>();
            services.AddScoped<IManobristaService, ManobristaService>();

            services.AddScoped<ICarroRepository, CarroRepository>();
            services.AddScoped<ICarroService, CarroService>();

            services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
            services.AddScoped<IMovimentacaoService, MovimentacaoService>();

            return services;
        }
    }
}
