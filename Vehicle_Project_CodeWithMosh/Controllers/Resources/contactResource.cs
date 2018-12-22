using System;
using System.ComponentModel.DataAnnotations;

namespace Vehicle_Project_CodeWithMosh.Controllers.Resources
{
    public partial class VehicleResource
    {
        public class contactResource
        {
            [Required]
            [StringLength(255)]
            public String Name { get; set; }
            [StringLength(255)]
            public String Email { get; set; }
            [Required]
            [StringLength(255)]
            public String Phone { get; set; }
        }
    }
}
