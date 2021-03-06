﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalMaster.Models
{
    public class MakeModelOption
    {   
        [Key]
        public int ID { get; set; }
        [Display(Name = "Make and Model")]
        public string Name { get; set; }
        public int MakeID { get; set; }
        public RentalItemMake RentalItemMake { get; set; }
        public int ModelID { get; set; }
        public RentalItemModel RentalItemModel { get; set; }


    }
}
