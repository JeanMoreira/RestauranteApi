using Microsoft.EntityFrameworkCore;
using RestauranteWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteWebApplication.Data
{
    public class BdContext :DbContext
    {
        public BdContext(DbContextOptions<BdContext> options) : base(options)
        {
        }

        public DbSet<Restaurante> Restarantes { get; set; }
        public DbSet<Prato> Pratos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurante>().ToTable("Restaurante");
            modelBuilder.Entity<Prato>().ToTable("Prato");
        }

    }
}
