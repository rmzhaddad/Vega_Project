﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle_Project_CodeWithMosh.Models;

namespace Vehicle_Project_CodeWithMosh.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDbContext context;

        public VehicleRepository(VegaDbContext context)
        {
            this.context = context;
        }
        public async Task<Vehicle> GetVehicle(int id, bool includeRelated = true)
        {

            if (!includeRelated)
                return await context.Vehicles.FindAsync(id);

            return await context.
                 Vehicles.Include(v => v.Features)
                 .ThenInclude(vf => vf.Feature)
                 .Include(v => v.Model)
                 .ThenInclude(m => m.Make)
                 .SingleOrDefaultAsync(v => v.ID == id);
        }

        public void Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
        }

        public void Remove(Vehicle vehicle)
        {
            context.Remove(vehicle);
        }

    }
}
