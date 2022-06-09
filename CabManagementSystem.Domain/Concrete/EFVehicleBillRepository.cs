using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabManagementSystem.Domain.Abstract;
using CabManagementSystem.Domain.Entities;

namespace CabManagementSystem.Domain.Concrete
{
    public class EFVehicleBillRepository ///* IVehicleBillRepository*/
    {
        private CabDbContext context = new CabDbContext();
        public IEnumerable<ShiftTiming> ShiftTimings => context.ShiftTimings;

        public IEnumerable<VehicleBill> VehicleBills => context.VehicleBills;

        public void SaveBill(VehicleBill vehicleBill)
        {
            if (vehicleBill.billId == 0)
            {
                context.VehicleBills.Add(vehicleBill);
            }
            else
            {
                VehicleBill dbEntry = context.VehicleBills.Find(vehicleBill.billId);
                if (dbEntry != null)
                {
                    dbEntry.billId = vehicleBill.billId;
                    dbEntry.billNum = vehicleBill.billNum;
                    dbEntry.vehicleId = vehicleBill.vehicleId;
                    dbEntry.totalAmount = vehicleBill.totalAmount;
                    dbEntry.dateOfBilling = vehicleBill.dateOfBilling;
                    dbEntry.venderId = vehicleBill.vehicleId;
                    dbEntry.deductions = vehicleBill.deductions;
                    dbEntry.netAmount = vehicleBill.netAmount;
                }
            }
            context.SaveChanges();
        }

    }
}
