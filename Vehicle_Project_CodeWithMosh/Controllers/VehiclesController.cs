
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    {      private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
       
        private readonly IVehicleRepository repository;
  

        public VehiclesController(IMapper mapper, IVehicleRepository repository,IUnitOfWork unitOfWork)
        {

            this.mapper = mapper;
           
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }



        [HttpPost]
        public async Task<IActionResult> CreatVehicle([FromBody]SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);

           

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;
            repository.Add(vehicle);
            await unitOfWork.CompleteAsync();

            vehicle = await repository.GetVehicle(vehicle.ID);


            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }
        //-------------------------this action is to edit a record----------------
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody]VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // this code is for business rule validation, not required in this application
            //var model = await context.Models.FindAsync(vehicleResource.ModelId);
            //if (model == null)
            //{
            //    ModelState.AddModelError("ModelId", "Invalid modelId.");
            //    return BadRequest(ModelState);
            //}

            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
                return NotFound();
            mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            await unitOfWork.CompleteAsync();
            vehicle = await repository.GetVehicle(vehicle.ID);
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }
        //-------------------------End of edit a record

        //---------------------Delete a record
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await repository.GetVehicle(id, includeRelated: false);
            if (vehicle == null)
                return NotFound();

            repository.Remove(vehicle);
            await unitOfWork.CompleteAsync();
            return Ok(id);
        }

        //---------------------------------

        // this code is to get an object
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {

            var vehicle = await repository.GetVehicle(id);


            if (vehicle == null)
                return NotFound();

            var VehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(VehicleResource);

        }


    }
}
