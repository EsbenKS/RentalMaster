using RentalMaster.Models;
using System.Collections.Generic;
using System.Linq;

namespace RentalMaster.Repositories
{
    public class RentalItemStatusRepository : IRentalItemStatusRepository
    {
        private List<RentalItemStatus> RentalItemStatuses = new List<RentalItemStatus>();

        public RentalItemStatusRepository()
        {
            var Ready = new RentalItemStatus
            {
                ID = 1,
                Name = "Ready",
                SortOrder = 10
            };
            RentalItemStatuses.Add(Ready);
            var Repair = new RentalItemStatus
            {
                ID = 2,
                Name = "Repair",
                SortOrder = 30
            };
            RentalItemStatuses.Add(Repair);
            var NA = new RentalItemStatus
            {
                ID = 3,
                Name = "Not Available",
                SortOrder = 20
            };
            RentalItemStatuses.Add(NA);
            var PR = new RentalItemStatus
            {
                ID = 4,
                Name = "Pending Repair",
                SortOrder = 90
            };
            RentalItemStatuses.Add(PR);

        }
        public IEnumerable<RentalItemStatus> GetAll()
        {
            var result =  RentalItemStatuses
                                    .OrderBy(c => c.SortOrder)
                                    .ThenBy(d => d.Name);
            return result;
        }
        public RentalItemStatus GetByID(int RentalItemStatusId)
        {

            try
            {
                var result = RentalItemStatuses.Single(s => s.ID == RentalItemStatusId);
                return result;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public List<RentalItemStatus> GetAllAsList()
        {
            var result = GetAll().ToList();
            return result;
        }
    }
}
