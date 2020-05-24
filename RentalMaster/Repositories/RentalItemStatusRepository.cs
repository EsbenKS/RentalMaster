using RentalMaster.Data;
using RentalMaster.Models;
using System.Collections.Generic;
using System.Linq;

namespace RentalMaster.Repositories
{
    public class RentalItemStatusRepository : IRentalItemStatusRepository
    {

        private readonly ApplicationDbContext _appDbContext;

        public RentalItemStatusRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;



        }
        public IEnumerable<RentalItemStatus> GetAll()
        {
            return _appDbContext
                                .RentalItemStatuses
                                .OrderBy(c => c.SortOrder);
        }
        public RentalItemStatus GetByID(int RentalItemStatusId)
        {
            return _appDbContext
                                .RentalItemStatuses
                                .FirstOrDefault(p => p.ID == RentalItemStatusId);
        }
        public RentalItemStatus GetByName(string RentalItemStatusName)
        {
            return _appDbContext
                                .RentalItemStatuses
                                .FirstOrDefault(p => p.Name == RentalItemStatusName);
        }
        public List<RentalItemStatus> GetAllAsList()
        {
            // Sort by name
            return _appDbContext
                                .RentalItemStatuses
                                .OrderBy(c => c.SortOrder)
                                .ToList();
        }
       
    }
}