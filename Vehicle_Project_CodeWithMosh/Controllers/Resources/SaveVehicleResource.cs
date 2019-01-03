using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vehicle_Project_CodeWithMosh.Models;

namespace Vehicle_Project_CodeWithMosh.Controllers.Resources
{
    public partial class SaveVehicleResource
    {

        public int ID { get; set; }
        public int ModelId { get; set; }
     
        public bool IsRegistered { get; set; }
        
       
        public ICollection<int> Features { get; set; }
        [Required]
        public contactResource Contact { get; set; }

        public SaveVehicleResource()
        {
            Features = new Collection<int>();
        }
    }
}
