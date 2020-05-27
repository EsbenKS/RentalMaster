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
                                   .Include(a => a.RentalAgreements)
                                   .AsNoTracking()
                                   .OrderBy(c => c.Name).ToList(); 
      
        }
        public IEnumerable<RentalItem> GetAllReady()
        {
            return _appDbContext.RentalItems
                                   .Include(r => r.RentalItemMake)
                                   .Include(r => r.RentalItemModel)
                                   .Include(r => r.RentalItemStatus)
                                   .Include(a => a.RentalAgreements)
                                   .Where(s => s.RentalItemStatus.ID == 1)
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
                                .Include(a => a.RentalAgreements)
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
                     .Include(a => a.RentalAgreements)
                    .AsNoTracking()
                    .Where(p => p.Name.Contains(searchStr) || p.RentalItemMake.Name.Contains(searchStr) || p.RentalItemModel.Name.Contains(searchStr));
        }
    }
}
