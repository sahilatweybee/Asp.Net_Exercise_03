using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.DataBase
{
    public class PartyDbContext : DbContext
    {
        public PartyDbContext(DbContextOptions<PartyDbContext> options)
            : base(options)
        {

        }
        public DbSet<Party> party { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<AssignParty> assign_party { get; set; }
        public DbSet<ProductRate> rate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Party>().HasIndex(x => new { x.party_name }).IsUnique(true);
            modelBuilder.Entity<Product>().HasIndex(x => x.product_name).IsUnique(true);
        }
    }
}
