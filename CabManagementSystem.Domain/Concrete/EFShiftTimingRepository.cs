using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabManagementSystem.Domain.Entities;
using CabManagementSystem.Domain.Abstract;

namespace CabManagementSystem.Domain.Concrete
{
    public class EFShiftTimingRepository : IShiftTimingsRepository
    {
        private CabDbContext context = new CabDbContext();
        public IEnumerable<ShiftTiming> ShiftTimings => context.ShiftTimings;


        public void SaveShift(ShiftTiming shiftTiming)
        {
            if (shiftTiming.shiftId == 0)
            {
                context.ShiftTimings.Add(shiftTiming);
            }
            else
            {
                ShiftTiming dbEntry = context.ShiftTimings.Find(shiftTiming.shiftId);
                if (dbEntry != null)
                {
                    dbEntry.shiftId = shiftTiming.shiftId;
                    dbEntry.ShiftName = shiftTiming.ShiftName;
                    dbEntry.shiftStartTime = shiftTiming.shiftStartTime;
                    dbEntry.shiftEndTime = shiftTiming.shiftEndTime;
                    dbEntry.totalBatches = shiftTiming.totalBatches;
                }
            }
            context.SaveChanges();
        }
    }
}
