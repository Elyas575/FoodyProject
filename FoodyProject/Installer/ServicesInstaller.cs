using Entities;
using FoodyProject.Services;
using FoodyProject.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodyProject.Installer
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServicesAssembly(IServiceCollection services, IConfiguration configuration)
        {
            var ConnectionString = configuration["ConnectionStrings:sqlConnection"];
            services.AddDbContext<RepositoryContext>(item =>
            item.UseSqlServer(ConnectionString, options => options.CommandTimeout(180)));

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder =>
                {
                    //For signalR you must use .SetIsOriginAllowed((host) => true) with .AllowCredentials();
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                }));

            services.AddScoped<IRepositoryManager, RepositoryManager>();

            services.Configure<IISOptions>(options =>
            {
            });

            services.AddControllers();
        }
    }
}
