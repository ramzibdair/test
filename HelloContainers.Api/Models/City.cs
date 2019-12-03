using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloContainers.Api.Models
{
    public class City
    {
        [Key] 
        public string Name { get; set; }
    }
}
