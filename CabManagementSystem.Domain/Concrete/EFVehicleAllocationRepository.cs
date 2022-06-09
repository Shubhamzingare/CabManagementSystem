using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabManagementSystem.Domain.Abstract;
using CabManagementSystem.Domain.Entities;

namespace CabManagementSystem.Domain.Concrete
{
    public class EFVehicleAllocationRepository : IVehicleAllocationRepository
    {
        CabDbContext context = new CabDbContext();
        public IEnumerable<VehicleAllocationDetail> VehicleAllocations => context.VehicleAllocations;
    }
}
