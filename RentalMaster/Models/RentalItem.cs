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
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "Make")]
        [ForeignKey("RentalItemMake")]
        public int MakeID { get; set; }
        public RentalItemMake RentalItemMake { get; set; }

        [Display(Name = "Model")]
        [ForeignKey("RentalItemModel")]
        public int ModelID { get; set; }
        public RentalItemModel RentalItemModel { get; set; }

        [Display(Name = "Status")]
        [ForeignKey("RentalItemStatus")]
        public int StatusID { get; set; }
        public RentalItemStatus RentalItemStatus { get; set; }

        public ICollection<RentalAgreement> RentalAgreements { get; set; }

        [NotMapped]
        public int MakeModelID { get; set; }

        [NotMapped]
        public MakeModelOption MakeModelOption { get; set; }
        [NotMapped]
        public List<MakeModelOption> MakeModelOptions { get; set; }

    }
}
