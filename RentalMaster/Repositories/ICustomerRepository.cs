using Microsoft.AspNetCore.Mvc.Rendering;
using RentalMaster.Models;
using System;
using System.Collections.Generic;

namespace RentalMaster.Repositories
{
    public interface ICustomerRepository
    {
        
        IEnumerable<Customer> GetAll();
        Customer GetByID(int CustomerID);
        List<Customer> GetAllAsList();
        IEnumerable<Customer> GetByName(string name);
    }
}