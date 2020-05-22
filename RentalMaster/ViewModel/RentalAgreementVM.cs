using RentalMaster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalMaster.ViewModel
{
    public class RentalAgreementVM
    {
        [DataType(DataType.Date)]
        [DisplayName("Rental Date")]
        public DateTime RentalStartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Due Date")]
        public DateTime RentalEndDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RentalReturnedDate { get; set; }

        public int CustomerID { get; set; }

        public int RentalItemID { get; set; }


    }
}
