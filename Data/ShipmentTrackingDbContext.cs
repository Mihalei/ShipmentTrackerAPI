using Microsoft.EntityFrameworkCore;
using ShipmentTrackerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipmentTrackerAPI.Data
{
    public class ShipmentTrackingDbContext : DbContext
    {
        public ShipmentTrackingDbContext(DbContextOptions<ShipmentTrackingDbContext> options)
            : base(options)
        { }

        public DbSet<ShipmentTracking> ShipmentTrackings { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<Checkpoint> Checkpoints { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
