using CabManagementSystem.Domain.Abstract;
using CabManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabManagementSystem.Domain.Concrete
{
    public class EFTripSheetRepository : ITripSheetRepository
    {
        private CabDbContext context = new CabDbContext();

        public IEnumerable<TripSheet> TripSheet => context.TripSheets;

        public void SaveSheet(TripSheet tripSheet)
        {
            if (tripSheet.tripSheetId == 0)
            {
                context.TripSheets.Add(tripSheet);
            }
            else
            {
                TripSheet dbEntry = context.TripSheets.Find(tripSheet.tripSheetId);
                if (dbEntry != null)
                {
                    dbEntry.tripSheetId = tripSheet.tripSheetId;
                    dbEntry.vehicleAlloId = tripSheet.vehicleAlloId;
                    dbEntry.vehicleId = tripSheet.vehicleId;
                    dbEntry.distanceTravelled = tripSheet.distanceTravelled;
                    dbEntry.remark = tripSheet.remark;
                }
            }
            context.SaveChanges();
        }
    }
}
