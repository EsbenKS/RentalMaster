using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalMaster.Models
{
    public class RentalItemModel
    {
        [Key]
        [Display(Name = "Model ID")]
        public int ID { get; set; }
        [Display(Name = "Model")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        public RentalItemMake  RentalItemMake { get; set; }
        public int MakeID { get; set; }


    }
}
