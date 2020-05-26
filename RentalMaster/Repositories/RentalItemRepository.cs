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
            return _appDbContext.RentalItems
                                   .Include(r => r.RentalItemMake)
                                   .Include(r => r.RentalItemModel)
                                   .Include(r => r.RentalItemStatus)
                                   .AsNoTracking()
                                   .OrderBy(c => c.Name).ToList(); 
      
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
   
        public List<RentalItem> GetAllAsList()
        {
            // Sort by name
            return GetAll().ToList(); 
        }

        IEnumerable<RentalItem> IRentalItemRepository.GetByName(string searchStr)
        {
            return _appDbContext
                    .RentalItems
                     .Include(r => r.RentalItemMake)
                     .Include(r => r.RentalItemModel)
                     .Include(r => r.RentalItemStatus)
                    .AsNoTracking()
                    .Where(p => p.Name.Contains(searchStr));
        }
    }
}
