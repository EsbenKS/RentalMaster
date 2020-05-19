using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace RentalMaster.Models
{
    public class RentalItem
    {
        [Key] 
        public int ID { get; set; }
        public string Name { get; set; }

        public int CategoryID { get; set; }
        public RentalItemCategory RentalItemCategory { get; set; }

        
        public int MakeID { get; set; }
        public RentalItemMake RentalItemMake { get; set; }

        public int ModelID { get; set; }
        public RentalItemModel RentalItemModel { get; set; }

        public RentalItemStatus Status { get; set; }
       
    }
 

    public enum RentalItemStatus
    {
        Ready,
        Repair,
        NotAvailable
    }
}
