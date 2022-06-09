using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabManagementSystem.Domain.Entities;

namespace CabManagementSystem.Domain.Concrete
{
    public class CabDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ShiftTiming> ShiftTimings { get; set; }
        public DbSet<RouteDetail> RouteDetails { get; set; }
        public DbSet<BatchDetail> BatchDetails { get; set; }
        public DbSet<VehicleDetail> VehicleDetails { get; set; }
        public DbSet<TripSheet> TripSheets { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<VehicleAllocationDetail> VehicleAllocations { get; set; }

        public DbSet<VehicleBill> VehicleBills { get; set; }

    }
}

