using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabManagementSystem.Domain.Abstract;
using CabManagementSystem.Domain.Entities;

namespace CabManagementSystem.Domain.Concrete
{
    public class EFVehicleDetailRepository : IVehicleDetailRepository
    {
        private CabDbContext context = new CabDbContext();
        public IEnumerable<VehicleDetail> VehicleDetails => context.VehicleDetails;

        public VehicleDetail DeleteVehicle(int id)
        {
            VehicleDetail dbEntry = context.VehicleDetails.Find(id);
            if (dbEntry == null)
            {
                context.VehicleDetails.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveVehicle(VehicleDetail vehicleDetail)
        {
            if (vehicleDetail.vehicleId == 0)
            {
                context.VehicleDetails.Add(vehicleDetail);
            }
            else
            {
                VehicleDetail dbEntry = context.VehicleDetails.Find(vehicleDetail.vehicleId);
                if (dbEntry != null)
                {
                    dbEntry.vehicleId = vehicleDetail.vehicleId;
                    dbEntry.vehicleName = vehicleDetail.vehicleName;
                    dbEntry.venderId = vehicleDetail.venderId;
                    dbEntry.driverId = vehicleDetail.driverId;
                    dbEntry.vehicleType = vehicleDetail.vehicleType;
                    dbEntry.vehicleNum = vehicleDetail.vehicleNum;
                    dbEntry.ratePerKM = vehicleDetail.ratePerKM;
                    dbEntry.capacity = vehicleDetail.capacity;
                    dbEntry.routeId = vehicleDetail.routeId;
                }
            }
            context.SaveChanges();
        }
    }
}
