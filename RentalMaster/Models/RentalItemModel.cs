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
        [Display(Name = "Model Name")]
        public string Name { get; set; }
       
        [ForeignKey("RentalItemMake")]
        public int? MakeID { get; set; }
        

    }
}
