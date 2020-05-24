using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalMaster.Models
{
    public static class ModelBuildExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentalItemStatus>().HasData(
                        new RentalItemStatus { ID = 1, Name = "Ready", SortOrder = 10 },
                        new RentalItemStatus { ID = 2, Name = "Repair", SortOrder = 60 },
                        new RentalItemStatus { ID = 3, Name = "Not Available", SortOrder = 20 },
                        new RentalItemStatus { ID = 4, Name = "Pending Repair", SortOrder = 50 },
                        new RentalItemStatus { ID = 5, Name = "Wrecked", SortOrder = 99 }
                        );

            modelBuilder.Entity < RentalItemModel>().HasData(
                        new RentalItemModel { ID = 1, Name = "Auris", RentalItemMake = null },
                        new RentalItemModel { ID = 2, Name = "Corolla", RentalItemMake = null },
                        new RentalItemModel { ID = 3, Name = "MF 1500 | 19.5 - 32 HK", RentalItemMake = null},
                        new RentalItemModel { ID = 4, Name = "MF 3700 AL", RentalItemMake = null},
                        new RentalItemModel { ID = 5, Name = "MF 1700 | 38 - 46 HK", RentalItemMake = null}
                        );

        }
    }
}
                    