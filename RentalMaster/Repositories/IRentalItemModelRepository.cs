﻿using Microsoft.AspNetCore.Mvc.Rendering;
using RentalMaster.Models;
using System;
using System.Collections.Generic;

namespace RentalMaster.Repositories
{
    public interface IRentalItemModelRepository
    {
        
        IEnumerable<RentalItemModel> GetAll();
        RentalItemModel GetByID(int RentalItemModelID);
        List<RentalItemModel> GetAllAsList();
         IEnumerable<RentalItemMake> GetAllWhereUsed(int ModelID);
        bool isModelInUse(int ModelID);
        public IEnumerable<RentalItemModel> GetAvailable();
        
    }
}