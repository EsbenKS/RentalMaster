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

      
        public int MakeID { get; set; }
        public RentalItemMake RentalItemMake { get; set; }

        public int ModelID { get; set; }
        public RentalItemModel RentalItemModel { get; set; }

        public int StatusID { get; set; }
        public RentalItemStatus RentalItemStatus { get; set; }


        [NotMapped]
        public int MakeModelID { get; set; }
        [NotMapped]
        public MakeModelOption MakeModelOption { get; set; }
        [NotMapped]
        public List<MakeModelOption> MakeModelOptions { get; set; }

    }
}
