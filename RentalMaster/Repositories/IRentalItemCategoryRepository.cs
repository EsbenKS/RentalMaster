using Microsoft.AspNetCore.Mvc.Rendering;
using RentalMaster.Models;
using System;
using System.Collections.Generic;

namespace RentalMaster.Repositories
{
    public interface IRentalItemCategoryRepository
    {
        
        IEnumerable<RentalItemCategory> GetAll();
        RentalItemCategory GetByID(int RentalItemCategoryID);
        List<RentalItemCategory> GetAllAsList();
        RentalItemCategory GetByName(string name);
        
    }
}