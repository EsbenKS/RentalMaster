using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalMaster.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(75, MinimumLength = 3)]
        public string Adresse1 { get; set; }
       
        [StringLength(75, MinimumLength = 3)]
        public string Adresse2 { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string PostArea { get; set; }


        public ICollection<RentalAgreement> RentalAgreements { get; set; }


        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
