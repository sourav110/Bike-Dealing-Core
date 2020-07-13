using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeDealingCore.Models
{
    public class Demo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
