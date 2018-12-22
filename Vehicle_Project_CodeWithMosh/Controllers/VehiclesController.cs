
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle_Project_CodeWithMosh.Controllers.Resources;
using Vehicle_Project_CodeWithMosh.Models;
using Vehicle_Project_CodeWithMosh.Persistence;

namespace Vehicle_Project_CodeWithMosh.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController :Controller
    {
        private readonly IMapper mapper;

        public VehiclesController(IMapper mapper)
        {
            this.mapper = mapper;
           
        }



        [HttpPost]
        public IActionResult CreatVehicle([FromBody]VehicleResource vehicleResource)
        {
            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            return Ok(vehicle);
        }
    }
}
