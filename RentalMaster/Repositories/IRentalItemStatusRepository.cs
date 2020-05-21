using Microsoft.AspNetCore.Mvc.Rendering;
using RentalMaster.Models;
using System;
using System.Collections.Generic;

namespace RentalMaster.Repositories
{
    public interface IRentalItemStatusRepository
    {
        
        IEnumerable<RentalItemStatus> GetAll();
        RentalItemStatus GetByID(int RentalItemStatusID);
        List<RentalItemStatus> GetAllAsList();  
        
    }
}