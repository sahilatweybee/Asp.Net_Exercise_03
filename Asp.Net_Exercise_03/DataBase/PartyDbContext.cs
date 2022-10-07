using Microsoft.EntityFrameworkCore;

namespace Asp.Net_Exercise_03.DataBase
{
    public class PartyDbContext : DbContext
    {
        public PartyDbContext(DbContextOptions<PartyDbContext> options)
            : base(options)
        {

        }
        public DbSet<Party> Party_tbl { get; set; }
        public DbSet<Product> Product_tbl { get; set; }
        public DbSet<AssignParty> Assign_party_tbl { get; set; }
        public DbSet<ProductRate> Rate_tbl { get; set; }
        public DbSet<Invoice> Invoice_tbl { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Party>().HasIndex(x => new { x.Party_name }).IsUnique(true);
            modelBuilder.Entity<Product>().HasIndex(x => x.Product_name).IsUnique(true);
            modelBuilder.Entity<ProductRate>().HasIndex(x => x.Product_id).IsUnique(true);
        }
    }
}
