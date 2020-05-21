﻿using System;
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
        public DbSet<RentalItemMake> RentalItemMakes { get; set; }
        public DbSet<RentalItemModel> RentalItemModels { get; set; }
        public DbSet<MakeModelOption> MakeModelOptions { get; set; }

 


    }
}
