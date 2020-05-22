using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalMaster.Models
{
    public class RentalAgreement
    {
        public RentalAgreement()
        {
            this.Customer = new Customer();
            this.RentalItem = new RentalItem();
        }
        public int ID { get; set; }

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

        public Customer Customer { get; set; }
        public RentalItem RentalItem { get; set; }

        public bool isRentalActive()
        {
            return RentalReturnedDate == DateTime.MinValue || RentalReturnedDate == null;
        }

        public bool isRentalOverdue()
        {
            // Return true if Enddate is later than now - else false. 
            return RentalEndDate < DateTime.Now && isRentalActive();
        }
    }
}
