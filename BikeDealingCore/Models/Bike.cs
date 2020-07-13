using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeDealingCore.Models
{
    public class Bike
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
