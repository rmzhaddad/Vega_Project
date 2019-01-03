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
    public class FeaturesController :Controller
    {

        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public FeaturesController(VegaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/features")]

        public async Task<IEnumerable<KeyValuePairResource>> GetFeatures()
        {
            var features = await context.Features.ToListAsync();
            return mapper.Map<List<Feature>, List <KeyValuePairResource>>(features);


        }
    }
}
