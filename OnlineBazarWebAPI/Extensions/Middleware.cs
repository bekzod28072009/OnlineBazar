using Bazar.DataAcces.AppDBContexts;
using Microsoft.EntityFrameworkCore;

namespace OnlineBazarWebAPI.Extensions
{
    public static class Middleware
    {
        public static void AddDBConTextes(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                 options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
