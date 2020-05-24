using Microsoft.EntityFrameworkCore;
using RentalMaster.Data;
using RentalMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentalMaster.Repositories
{
    public class RentalItemModelRepository : IRentalItemModelRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public RentalItemModelRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<RentalItemModel> GetAll()
        {
            return _appDbContext
                                .RentalItemModels
                                .Include(r => r.RentalItemMake)
                                .AsNoTracking()
                                .OrderBy(c => c.Name);
        }
        public RentalItemModel GetByID(int RentalItemModelId)
        {
            return _appDbContext
                                .RentalItemModels
                                .Include(r => r.RentalItemMake)
                                .FirstOrDefault(p => p.ID == RentalItemModelId);
        }
        public RentalItemModel GetByName(string RentalItemModelname)
        {
            return _appDbContext
                                .RentalItemModels
                                .Include(r => r.RentalItemMake)
                                .AsNoTracking()
                                .FirstOrDefault(p => p.Name == RentalItemModelname);
        }
        public List<RentalItemModel> GetAllAsList()
        {
            // Sort by name
            return _appDbContext
                                .RentalItemModels
                                .Include(r => r.RentalItemMake)
                                .AsNoTracking()
                                .OrderBy(c => c.Name)
                                .ToList();
        }
        public IEnumerable<RentalItemMake> GetAllWhereUsed(int ModelID)
        {
            return _appDbContext
                                .RentalItemMakes
                                .Include(r => r.RentalItemModels)
                                .AsNoTracking()
                                .Where(x => x.RentalItemModels.Any(x => x.ID == ModelID))
                                .OrderBy(o => o.Name);

        }
        public bool isModelInUse(int ModelID)
        {
            // If you don't just want to know if it in use, but not where.  
            return (GetAllWhereUsed(ModelID).Count() > 0);
        }
        public IEnumerable<RentalItemModel> GetAvailable()
        {
            // Return only models without make. 
            return _appDbContext
                                .RentalItemModels
                                .Where(p => p.RentalItemMake == null)
                                .AsNoTracking()
                                .OrderBy(c => c.Name);
        }


    }    
}
