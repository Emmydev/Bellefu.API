using Bellefu.API.DbObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bellefu.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Order> Order { get; set; }

        public DbSet<Menu> Menu { get; set; }
    }
}
