using Microsoft.AspNetCore.Mvc.Rendering;
using RentalMaster.Models;
using System;
using System.Collections.Generic;

namespace RentalMaster.Repositories
{
    public interface IRentalAgreementRepository
    {
        IEnumerable<RentalAgreement> GetAll();
        IEnumerable<RentalAgreement> GetAllActive();
        List<RentalAgreement> GetAllAsList();
        RentalAgreement GetByID(int RentalAgreementID);
        IEnumerable<RentalAgreement> GetByName(string searchStr);

    }
}