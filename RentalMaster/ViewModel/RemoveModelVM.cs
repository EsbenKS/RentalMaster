using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalMaster.ViewModel
{
    public class RemoveModelVM
    {
        public int ModelID { get; set; }
        public string ModelName { get; set; }

        public int MakeID { get; set; }
        public string MakeName { get; set; }
    }
}
