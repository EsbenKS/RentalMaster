using Microsoft.EntityFrameworkCore;
using RentalMaster.Data;
using RentalMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentalMaster.Repositories
{
    public class RentalItemMakeRepository : IRentalItemMakeRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public RentalItemMakeRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<RentalItemMake> GetAll()
        {
            return _appDbContext
                                .RentalItemMakes
                                .Include(r => r.RentalItemModels)
                                .AsNoTracking()
                                .OrderBy(c => c.Name);
      
        }
        public RentalItemMake GetByID(int RentalItemMakeId)
        {
            return _appDbContext
                                .RentalItemMakes
                                .Include(r => r.RentalItemModels)
                                .FirstOrDefault(p => p.ID == RentalItemMakeId);
        }
        public RentalItemMake GetByName(string RentalItemMakename)
        {
            return _appDbContext
                                .RentalItemMakes
                                .Include(r => r.RentalItemModels)
                                .AsNoTracking()
                                .FirstOrDefault(p => p.Name == RentalItemMakename);
        }
        public List<RentalItemMake> GetAllAsList()
        {
            // Sort by name
            return _appDbContext
                                .RentalItemMakes
                                .Include(r => r.RentalItemModels)
                                .OrderBy(c => c.Name)
                                .AsNoTracking()
                                .ToList();       
        }
        public IEnumerable<RentalItemCategory> GetAllWhereUsed(RentalItemMake rentalItemMake)
        {
            return _appDbContext
                                .RentalItemCategories
                                .Include(r => r.RentalItemMakes)
                                .AsNoTracking()
                                .Where(x => x.RentalItemMakes.Any(x => x.ID == rentalItemMake.ID))
                                .OrderBy(o => o.Name);

        }

    }
}
