using CabManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabManagementSystem.Domain.Abstract
{
    public interface ITripSheetRepository
    {
        IEnumerable<TripSheet> TripSheet { get; }
    }
}
