using Microsoft.EntityFrameworkCore;
using RentalMaster.Data;
using RentalMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentalMaster.Repositories
{
    public class RentalAgreementRepository : IRentalAgreementRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public RentalAgreementRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public RentalAgreement GetByID(int rentalAgreementID)
        {
            return _appDbContext
                               .RentalAgreements
                               .Include(r => r.Customer)
                               .Include(r => r.RentalItem)
                               .AsNoTracking()
                               .FirstOrDefault(p => p.ID == rentalAgreementID);
        }

        public List<RentalAgreement> GetAllAsList()
        {
            // Sort by name
            return GetAll().ToList();
        }


        public IEnumerable<RentalAgreement> GetAll()
        {
            return _appDbContext
                                .RentalAgreements.Include(r => r.Customer)
                                .Include(r => r.RentalItem)
                                 .ThenInclude(ma => ma.RentalItemMake)
                                .Include(r => r.RentalItem)
                                 .ThenInclude(mo => mo.RentalItemModel)
                                .OrderByDescending(c => c.RentalStartDate);
        }

        public List<RentalAgreement> AllAgreementsByCustomer(int customerID)
        {
            return _appDbContext
                               .RentalAgreements
                               .Where(a => a.CustomerID == customerID)
                               .AsNoTracking()
                               .OrderByDescending(c => c.RentalStartDate)
                               .Include(r => r.Customer)
                               .Include(r => r.RentalItem)
                                 .ThenInclude(ma => ma.RentalItemMake)
                               .Include(r => r.RentalItem)
                                 .ThenInclude(mo => mo.RentalItemModel)
                               .ToList();
        }

        public List<RentalAgreement> ActiveAgreementsByCustomer(int CustomerID)
        {
            return _appDbContext
                      .RentalAgreements
                      .Where(a => a.RentalEndDate > DateTime.Now && a.RentalReturnedDate == null)
                      .AsNoTracking()
                        .OrderByDescending(c => c.RentalStartDate)
                        .Include(r => r.Customer)
                        .Include(r => r.RentalItem)
                            .ThenInclude(ma => ma.RentalItemMake)
                        .Include(r => r.RentalItem)
                            .ThenInclude(mo => mo.RentalItemModel)
                      .ToList();
        }

        public List<RentalAgreement> PreviousAgreementsByCustomer(int CustomerID)
        {
            return _appDbContext
                              .RentalAgreements
                              .Where(a => a.RentalReturnedDate != null)
                               .OrderByDescending(c => c.RentalStartDate)
                               .Include(r => r.Customer)
                               .Include(r => r.RentalItem)
                                 .ThenInclude(ma => ma.RentalItemMake)
                               .Include(r => r.RentalItem)
                                 .ThenInclude(mo => mo.RentalItemModel)
                              .ToList();
        }

        public IEnumerable<RentalAgreement> GetByName(string searchStr)
        {
            return _appDbContext
                              .RentalAgreements
                              .OrderByDescending(c => c.RentalStartDate)
                               .Include(r => r.Customer)
                               .Include(r => r.RentalItem)
                                 .ThenInclude(ma => ma.RentalItemMake)
                               .Include(r => r.RentalItem)
                                 .ThenInclude(mo => mo.RentalItemModel)
                               .Where(p => p.Customer.FirstName.Contains(searchStr) ||
                                           p.Customer.LastName.Contains(searchStr) ||
                                           p.Customer.PostArea.Contains(searchStr) ||
                                           p.RentalItem.Name.Contains(searchStr) ||                                      p.RentalItem.RentalItemMake.Name.Contains(searchStr) ||
                                           p.RentalItem.RentalItemModel.Name.Contains(searchStr));
        }
    }
}
