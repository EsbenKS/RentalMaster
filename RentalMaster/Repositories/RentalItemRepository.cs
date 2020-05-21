using Microsoft.EntityFrameworkCore;
using RentalMaster.Data;
using RentalMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentalMaster.Repositories
{
    public class RentalItemRepository : IRentalItemRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly IRentalItemModelRepository _rentalItemModelRepository;
        private readonly IRentalItemMakeRepository _rentalItemMakeRepository;
        private readonly IRentalItemStatusRepository _rentalItemStatusRepository;

        public RentalItemRepository(ApplicationDbContext appDbContext, IRentalItemModelRepository rentalItemModelRepository,
                                    IRentalItemStatusRepository rentalItemStatusRepository,
                                    IRentalItemMakeRepository rentalItemMakeRepository)
        {
            _appDbContext = appDbContext;
            _rentalItemModelRepository = rentalItemModelRepository;
            _rentalItemMakeRepository = rentalItemMakeRepository;
            _rentalItemStatusRepository = rentalItemStatusRepository;
        }
        public IEnumerable<RentalItem> GetAll()
        {
            var AllItems = _appDbContext.RentalItems
                                   .Include(r => r.RentalItemMake)
                                   .Include(r => r.RentalItemModel)
                                   .Include(r => r.RentalItemStatus)
                                   .AsNoTracking()
                                   .OrderBy(c => c.Name)
                                   .ToList();


            foreach (var item in AllItems)
            {
                // Include the objects in the RentalItem. 
                item.RentalItemMake = _rentalItemMakeRepository.GetByID(item.MakeID);
                if (item.RentalItemMake.Name == null) Console.ReadLine(); 
                item.RentalItemModel = _rentalItemModelRepository.GetByID(item.ModelID);
                item.RentalItemStatus = _rentalItemStatusRepository.GetByID(item.StatusID);
            }

            return AllItems;
      
        }
        public RentalItem GetByID(int RentalItemId)
        {
            return _appDbContext
                                .RentalItems
                                .Include(r => r.RentalItemMake)
                                .Include(r => r.RentalItemModel)
                                .Include(r => r.RentalItemStatus)
                                .FirstOrDefault(p => p.ID == RentalItemId);
        }
        public RentalItem GetByName(string name)
        {
            return _appDbContext
                                .RentalItems
                                 .Include(r => r.RentalItemMake)
                                 .Include(r => r.RentalItemModel)
                                 .Include(r => r.RentalItemStatus)
                                .AsNoTracking()
                                .FirstOrDefault(p => p.Name == name);
        }
        public List<RentalItem> GetAllAsList()
        {
            // Sort by name
            return GetAll().ToList(); 
        }

  
    }
}
