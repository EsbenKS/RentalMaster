using Microsoft.EntityFrameworkCore;
using RentalMaster.Data;
using RentalMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentalMaster.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public CustomerRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Customer> GetAll()
        {
            return _appDbContext
                                .Customers
                                .AsNoTracking()
                                .OrderBy(c => c.FirstName);
                                
        }
        public Customer GetByID(int CustomerId)
        {
            return _appDbContext
                                .Customers
                                .AsNoTracking()
                                .FirstOrDefault(p => p.ID == CustomerId);
        }
        public Customer GetByName(string Customername)
        {
            return _appDbContext
                                .Customers
                                .AsNoTracking()
                                .FirstOrDefault(p => p.FullName == Customername);
        }
        public List<Customer> GetAllAsList()
        {
            // Sort by name
            return _appDbContext
                                .Customers
                                .AsNoTracking()
                                .OrderBy(c => c.FirstName)
                                .ToList();
        }
    }    
}
