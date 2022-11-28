using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace KeysShop.Core
{
    public class KeysShopContext : DbContext
    {
        public KeysShopContext(DbContextOptions<KeysShopContext> options)
            : base(options)
        {
        }

        public DbSet<Key> Keys { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}