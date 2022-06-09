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

        public void SaveVehicleAllocation(VehicleAllocationDetail vehicleAllocationDetail)
        {
            if (vehicleAllocationDetail.vehicleAlloId == 0)
            {
                context.VehicleAllocations.Add(vehicleAllocationDetail);
            }
            else
            {
                VehicleAllocationDetail dbEntry = context.VehicleAllocations.Find(vehicleAllocationDetail.vehicleAlloId);
                if (dbEntry != null)
                {
                    dbEntry.vehicleAlloId = vehicleAllocationDetail.vehicleAlloId;
                    dbEntry.vehicleId = vehicleAllocationDetail.vehicleId;
                    dbEntry.empId = vehicleAllocationDetail.empId;
                    dbEntry.driverId = vehicleAllocationDetail.driverId;
                    dbEntry.pickOrDrop = vehicleAllocationDetail.pickOrDrop;
                    dbEntry.routeId = vehicleAllocationDetail.routeId;
                }
            }
            context.SaveChanges();
        }
    }
}
