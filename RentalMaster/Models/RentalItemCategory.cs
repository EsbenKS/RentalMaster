using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalMaster.Models
{
    public class RentalItemCategory
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public List<RentalItemMake> RentalItemMakes { get; set; }

        [NotMapped]
        public int RentalItemMakeID { get; set; }


    }
}
