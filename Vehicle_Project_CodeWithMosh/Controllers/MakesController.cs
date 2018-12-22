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
    public class MakesController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;

        public MakesController(VegaDbContext context , IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/makes")]

        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes= await context.Makes.Include(m => m.Models).ToListAsync();
            return mapper.Map<List<Make>, List < MakeResource >> (makes);

        }
    }
}
