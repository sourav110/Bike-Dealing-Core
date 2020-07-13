using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeDealingCore.Models;

namespace BikeDealingCore.Models
{
    public class BikeDbContext : DbContext
    {
        public BikeDbContext(DbContextOptions<BikeDbContext> options) : base(options)
        {}

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<BikeDealingCore.Models.Demo> Demo { get; set; }
    }
}
