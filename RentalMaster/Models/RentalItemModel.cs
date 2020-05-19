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
        public int ID { get; set; }
        public string Name { get; set; }
        //public int? MakeID { get; set; }
        

    }
}
