using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabManagementSystem.Domain.Entities;
namespace CabManagementSystem.Domain.Abstract
{
    public interface IVehicleAllocationRepository
    {
        IEnumerable<VehicleAllocationDetail> VehicleAllocations { get; }

        void SaveVehicleAllocation(VehicleAllocationDetail vehicleAllocationDetail);
    }
}
