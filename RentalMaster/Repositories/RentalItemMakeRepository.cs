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

        public IEnumerable<MakeModelOption> MakeModelOptions()
        {
   

            //Truncate Table to delete all old records, and reset the id colum..
            _appDbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [MakeModelOptions]");

            var NewMakeModelOptions = new List<MakeModelOption>(); 

            var makes = GetAllAsList();
            foreach (var make in makes)
            {
                foreach (var model in make.RentalItemModels)
                {
                    var MakeModel = new MakeModelOption();
                    MakeModel.MakeID = make.ID;
                    MakeModel.ModelID = model.ID;
                    MakeModel.Name = make.Name + ' ' + model.Name;
                    _appDbContext.MakeModelOptions.Add(MakeModel);
                }
            }
            // Add new MakeModelOptions
            _appDbContext.SaveChanges();


            return _appDbContext.MakeModelOptions
                                .AsNoTracking()
                                .OrderBy(c => c.Name).ToList(); 
        }
        public IEnumerable<RentalItem> GetAllWhereUsed(int id)
        {
            return _appDbContext
                    .RentalItems
                    .AsNoTracking()
                    .Where(x => x.MakeID == id)
                    .OrderBy(o => o.Name);
        }

        public bool isMakeInUse(int ModelID)
        {
            // If you don't just want to know if it in use, but not where.  
            return (GetAllWhereUsed(ModelID).Count() > 0);
        }
    }
}
