using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options):base(options)
        {

        }
   public DbSet<Car> Car { get; set; }
   public DbSet<Category> Category { get; set; }
   public DbSet<ShopCartItems> ShopCartItems { get; set; }
   public DbSet<Order> Order { get; set; }
   public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
