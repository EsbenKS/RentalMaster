﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalMaster.Models
{
    public class RentalItemMake
    {

        public RentalItemMake()
        {
            RentalItemModels = new List<RentalItemModel>();
        }
        [Key]
        [Display(Name = "Make ID")]

        public int ID { get; set; }
        [Display(Name = "Make")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        public List<RentalItemModel> RentalItemModels { get; set; }

        [NotMapped]
        public int RentalItemModelID { get; set; }


    }
}
