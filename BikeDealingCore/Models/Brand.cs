using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeDealingCore.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Brand Name")]
        public string Name { get; set; }
    }
}
