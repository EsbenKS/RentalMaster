using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalMaster.Models
{
    public class RentalItemStatus
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
    }
}
