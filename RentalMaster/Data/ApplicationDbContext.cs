using System;
using System.Collections.Generic;
using System.Text;
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
        public DbSet<RentalItemCategory> RentalItemCategories { get; set; }
        public DbSet<RentalItemMake> RentalItemMakes { get; set; }
        public DbSet<RentalItemModel> RentalItemModels { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<RentalItemMake>()
        //        .HasOptional(a => a.RentalItemModel)
        //        .WithOptionalDependent()
        //        .WillCascadeOnDelete(true);
        //}


    }
}
