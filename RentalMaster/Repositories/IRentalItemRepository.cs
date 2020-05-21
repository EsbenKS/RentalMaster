using Microsoft.AspNetCore.Mvc.Rendering;
using RentalMaster.Models;
using System;
using System.Collections.Generic;

namespace RentalMaster.Repositories
{
    public interface IRentalItemRepository
    {
        IEnumerable<RentalItem> GetAll();
        RentalItem GetByID(int RentalItemID);
        List<RentalItem> GetAllAsList();
        RentalItem GetByName(string name);
        

    }
}