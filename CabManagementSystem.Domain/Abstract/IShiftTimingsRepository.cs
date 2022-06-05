using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabManagementSystem.Domain.Entities;

namespace CabManagementSystem.Domain.Abstract
{
    public interface IShiftTimingsRepository
    {
        IEnumerable<ShiftTiming> ShiftTimings { get; }

        void SaveShift(ShiftTiming shiftTiming);

        ShiftTiming DeleteShift(int id);
    }
}
