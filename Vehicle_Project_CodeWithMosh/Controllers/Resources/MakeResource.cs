﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vehicle_Project_CodeWithMosh.Models;

namespace Vehicle_Project_CodeWithMosh.Controllers.Resources
{
    public class MakeResource : KeyValuePairResource
    {

        public ICollection<KeyValuePairResource> Models { get; set; }

        public MakeResource()
        {
            Models = new Collection<KeyValuePairResource>();
        }
    }
}
