using Bazar.DataAcces.AppDBContexts;
using Bazar.DataAcces.IRepository;
using Bazar.DataAcces.Repository;
using Bazar.Domain.Entities.Collectors;
using Bazar.Domain.Entities.Others;
using Bazar.Domain.Entities.Taxi;
using Bazar.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace OnlineBazarWebAPI.Extensions
{
    public static class Middleware
    {
        public static void AddDBConTextes(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                 options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddRepository(this IServiceCollection collection)
        {
            collection.AddTransient<IGenericRepository<User>, GenericRepository<User>>();
            collection.AddTransient<IGenericRepository<Collector>, GenericRepository<Collector>>();
            collection.AddTransient<IGenericRepository<Address>, GenericRepository<Address>>();
            collection.AddTransient<IGenericRepository<Car>, GenericRepository<Car>>();
            collection.AddTransient<IGenericRepository<Driver>, GenericRepository<Driver>>();
            collection.AddTransient<IGenericRepository<Order>, GenericRepository<Order>>();
            collection.AddTransient<IGenericRepository<Orders>, GenericRepository<Orders>>();
        }
    }
}
