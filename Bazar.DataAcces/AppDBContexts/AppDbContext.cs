using Bazar.Domain.Entities.Collectors;
using Bazar.Domain.Entities.Others;
using Bazar.Domain.Entities.Taxi;
using Bazar.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.DataAcces.AppDBContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }

        public DbSet<Collector> collectors { get; set; }

        public DbSet<Address> addresses { get; set; }

        public DbSet<Car> cars { get; set; }

        public DbSet<Driver> drivers { get; set; }

        public DbSet<Orders> DriverOrder { get; set; }

        public DbSet<Order> UserOrder { get; set; }    

        public DbSet<User> Users { get; set; }
    }
}
