using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalMaster.Models;

namespace RentalMaster.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RentalItem> RentalItems { get; set; }
        public DbSet<RentalItemMake> RentalItemMakes { get; set; }
        public DbSet<RentalItemModel> RentalItemModels { get; set; }
        public DbSet<RentalItemStatus> RentalItemStatuses { get; set; }
        public DbSet<MakeModelOption> MakeModelOptions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RentalAgreement> RentalAgreements { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RentalItemMake>()
                    .HasMany(m => m.RentalItemModels)
                    .WithOne(a => a.RentalItemMake)
                    .IsRequired(false);

            modelBuilder.Seed(); 

         

        }




    }
}
