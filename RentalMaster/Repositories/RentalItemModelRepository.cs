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
                                .AsNoTracking()
                                .OrderBy(c => c.Name);
        }
        public RentalItemModel GetByID(int RentalItemModelId)
        {
            return _appDbContext
                                .RentalItemModels
                                .AsNoTracking()
                                .FirstOrDefault(p => p.ID == RentalItemModelId);
        }
        public RentalItemModel GetByName(string RentalItemModelname)
        {
            return _appDbContext
                                .RentalItemModels
                                .AsNoTracking()
                                .FirstOrDefault(p => p.Name == RentalItemModelname);
        }
        public List<RentalItemModel> GetAllAsList()
        {
            // Sort by name
            return _appDbContext
                                .RentalItemModels
                                .AsNoTracking()
                                .OrderBy(c => c.Name)
                                .ToList();                
        }
        public IEnumerable<RentalItemMake> GetAllWhereUsed(RentalItemModel rentalItemModel)
        {
            return _appDbContext
                                .RentalItemMakes
                                .Include(r => r.RentalItemModels)
                                .AsNoTracking()
                                .Where(x => x.RentalItemModels.Any(x => x.ID == rentalItemModel.ID))
                                .OrderBy(o => o.Name);

        }
    }
}
