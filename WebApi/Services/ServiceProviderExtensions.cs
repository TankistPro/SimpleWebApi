using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using WebApi.Context;
using WebApi.Interfaces;
using WebApi.Interfaces.Repositories;
using WebApi.Interfaces.Services;
using WebApi.Mapping;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services
{
    public static class ServiceProviderExtensions
    {
        public static void InitServices(this IServiceCollection services)
        {
            services.AddTransient<IBaseRepository<User>, BaseRepository<User>>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public static void InitDbContext(this IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = config.GetConnectionString("DefaultConnection");

            services.AddControllers();
            services.AddAutoMapper(typeof(AppMapping));
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
