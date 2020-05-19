using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalMaster.Data;
using RentalMaster.Models;

namespace RentalMaster.Repositories
{
    public class RentalItemCategoryRepository : IRentalItemCategoryRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public RentalItemCategoryRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<RentalItemCategory> GetAll()
        {
            return _appDbContext
                                .RentalItemCategories
                //                .                
                //.Include(r => r.RentalItemMake)
                //.Include(r => r.RentalItemModel)
                                .AsNoTracking()
                                .OrderBy(c => c.Name);
        }
 
        public RentalItemCategory GetByID(int RentalItemCategoryId)
        {
            return _appDbContext
                                .RentalItemCategories
                                .AsNoTracking()
                                .FirstOrDefault(p => p.ID == RentalItemCategoryId);
        }
        public RentalItemCategory GetByName(string RentalItemCategoryname)
        {
            return _appDbContext
                                .RentalItemCategories
                                .AsNoTracking()
                                .FirstOrDefault(p => p.Name == RentalItemCategoryname);
        }
        public List<RentalItemCategory> GetAllAsList()
        {
            // Sort by name
            return _appDbContext
                                .RentalItemCategories
                                .AsNoTracking()
                                .OrderBy(c => c.Name)
                                .ToList();
                
        }
    }
}
