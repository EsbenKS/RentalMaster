using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalMaster.Models
{
    public class RentalItemStatus
    {
        [Display(Name = "Status ID")]
        public int ID { get; set; }
        [Display(Name = "Status Name")]
        public string Name { get; set; }
        [Display(Name = "Sort Order")]
        public int SortOrder { get; set; }
    }
}
