﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public class PointOfInterestForCreationDto
    {
        [Required(ErrorMessage = "Please enter a valid name"), MaxLength(50)]
        public string Name { get; set; }
        
        [Required, MaxLength(200)]
        public string Description { get; set; }
    }
}