using RentalMaster.Data;
using RentalMaster.Models;
using RentalMaster.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalMaster.Services
{
    public class DbSeeder
    {
        private readonly ApplicationDbContext _context;

        private readonly IRentalItemRepository _rentalItemRepository;
        private readonly IRentalItemMakeRepository _rentalItemMakeRepository;
        private readonly IRentalItemModelRepository _rentalItemModelRepository;
        private readonly IRentalItemStatusRepository _rentalItemStatusRepository;
        private readonly IMakeModelOptionRepository _makeModelOptionRepository;



        public DbSeeder(ApplicationDbContext context,
                                IRentalItemRepository rentalItemRepository,
                                IRentalItemModelRepository rentalItemModelRepository,
                                IRentalItemStatusRepository rentalItemStatusRepository,
                                IRentalItemMakeRepository rentalItemMakeRepository,
                                IMakeModelOptionRepository makeModelOptionRepository)
        {
            _context = context;
            _rentalItemRepository = rentalItemRepository;
            _rentalItemModelRepository = rentalItemModelRepository;
            _rentalItemMakeRepository = rentalItemMakeRepository;
            _rentalItemStatusRepository = rentalItemStatusRepository;
            _makeModelOptionRepository = makeModelOptionRepository;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            // Status codes
            if (!_context.RentalItemStatuses.Any())
            {
                _context.AddRange(
                    new RentalItemStatus { Name = "Ready", SortOrder = 10 },
                    new RentalItemStatus { Name = "Repair", SortOrder = 60 },
                    new RentalItemStatus { Name = "Not Available", SortOrder = 20 },
                    new RentalItemStatus { Name = "Pending Repair", SortOrder = 50  },
                    new RentalItemStatus { Name = "Wrecked", SortOrder = 99 }
                 );
                _context.SaveChanges();
            }

            // Status codes
            if (!_context.RentalItemModels.Any())
            {
                _context.AddRange(
                    new RentalItemModel { ID = 1, Name = "Toyota", RentalItemMake = null },
                    new RentalItemModel { ID = 2, Name = "Komatsu", RentalItemMake = null },
                    new RentalItemModel { ID = 3, Name = "Massey Ferguson", RentalItemMake = null },
                    new RentalItemModel { ID = 4, Name = "John Deere", RentalItemMake = null }
                    );
                _context.SaveChanges();
            }
        }
    }
}


