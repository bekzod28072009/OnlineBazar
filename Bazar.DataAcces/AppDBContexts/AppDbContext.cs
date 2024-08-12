using Bazar.Domain.Entities.Collectors;
using Bazar.Domain.Entities.Others;
using Bazar.Domain.Entities.Taxi;
using Bazar.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.DataAcces.AppDBContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }

        public virtual DbSet<Collector> collectors { get; set; }

        public virtual DbSet<Address> addresses { get; set; }

        public virtual DbSet<Car> cars { get; set; }

        public virtual DbSet<Driver> drivers { get; set; }

        public virtual DbSet<Orders> DriverOrder { get; set; }

        public virtual DbSet<Order> UserOrder { get; set; }    

        public virtual DbSet<User> Users { get; set; }
    }
}
