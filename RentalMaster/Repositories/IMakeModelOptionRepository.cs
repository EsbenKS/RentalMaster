using Microsoft.AspNetCore.Mvc.Rendering;
using RentalMaster.Models;
using System;
using System.Collections.Generic;

namespace RentalMaster.Repositories
{
    public interface IMakeModelOptionRepository
    {
        
        IEnumerable<MakeModelOption> GetAll();
        MakeModelOption GetByID(int MakeModelOptionID);
        List<MakeModelOption> GetAllAsList();    
        IEnumerable<MakeModelOption> GenerateMakeModelOptions();



    }
}