using Microsoft.EntityFrameworkCore;
using RentalMaster.Data;
using RentalMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentalMaster.Repositories
{
    public class MakeModelOptionRepository : IMakeModelOptionRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        private readonly IRentalItemRepository _rentalItemRepository;
        private readonly IRentalItemMakeRepository _rentalItemMakeRepository;
        private readonly IRentalItemModelRepository _rentalItemModelRepository;
        private readonly IRentalItemStatusRepository _rentalItemStatusRepository;


        public MakeModelOptionRepository(ApplicationDbContext appDbContext,
                                    IRentalItemRepository rentalItemRepository,
                                    IRentalItemModelRepository rentalItemModelRepository,
                                    IRentalItemStatusRepository rentalItemStatusRepository,
                                    IRentalItemMakeRepository rentalItemMakeRepository
                                    )
        {
            _appDbContext = appDbContext;
            _rentalItemRepository = rentalItemRepository;
            _rentalItemModelRepository = rentalItemModelRepository;
            _rentalItemMakeRepository = rentalItemMakeRepository;
            _rentalItemStatusRepository = rentalItemStatusRepository;
        }
        public IEnumerable<MakeModelOption> GetAll()
        {
            return _appDbContext
                                .MakeModelOptions
                                .Include(r => r.RentalItemMake)
                                .Include(r => r.RentalItemModel)
                                .AsNoTracking()
                                .OrderBy(c => c.Name);
            
        }
        public MakeModelOption GetByID(int MakeModelOptionId)
        {
            return _appDbContext
                                .MakeModelOptions
                                .Include(r => r.RentalItemMake)
                                .Include(r => r.RentalItemModel)
                                .AsNoTracking()
                                .FirstOrDefault(p => p.ID == MakeModelOptionId);
        }

        public List<MakeModelOption> GetAllAsList()
        {
            // Sort by name
            return _appDbContext
                                .MakeModelOptions
                                .Include(r => r.RentalItemModel)
                                .Include(r => r.RentalItemMake)
                                .OrderBy(c => c.Name)
                                .AsNoTracking()
                                .ToList();       
        }

        public IEnumerable<MakeModelOption> GenerateMakeModelOptions()
        {
            ClearMakeModelOptions();

            var NewMakeModelOptions = new List<MakeModelOption>();

            var makes = _rentalItemMakeRepository.GetAllAsList();
            foreach (var make in makes)
            {
                foreach (var model in make.RentalItemModels)
                {
                    var MakeModel = new MakeModelOption();
                    MakeModel.MakeID = make.ID;
                    MakeModel.RentalItemMake = make;
                    MakeModel.RentalItemModel = model;

                    MakeModel.ModelID = model.ID;
                    MakeModel.Name = make.Name + ' ' + model.Name;
                    _appDbContext.MakeModelOptions.Update(MakeModel);
                }
            }
            // Add new MakeModelOptions
            _appDbContext.SaveChanges();


            return _appDbContext.MakeModelOptions
                                .AsNoTracking()
                                .OrderBy(c => c.Name).ToList();


        }


        public void ClearMakeModelOptions()
        {

                //Truncate Table to delete all old records, and reset the id colum..
                _appDbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [MakeModelOptions]");
            }
        
    }
}
