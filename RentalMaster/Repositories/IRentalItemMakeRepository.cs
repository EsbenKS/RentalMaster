using Microsoft.AspNetCore.Mvc.Rendering;
using RentalMaster.Models;
using System;
using System.Collections.Generic;

namespace RentalMaster.Repositories
{
    public interface IRentalItemMakeRepository
    {
        
        IEnumerable<RentalItemMake> GetAll();
        RentalItemMake GetByID(int RentalItemMakeID);
        List<RentalItemMake> GetAllAsList();
        RentalItemMake GetByName(string name);
        IEnumerable<MakeModelOption> MakeModelOptions();

    }
}