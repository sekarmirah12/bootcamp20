using Boootcamp20.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boootcamp20.BaseContext
{
    class MyContext : DbContext 
    {
        public MyContext() : base("Bootcamp20") { }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Penjualan> Penjualann { get; set; }
        public DbSet<DetailPenjualan> Details { get; set; }
    }
}
