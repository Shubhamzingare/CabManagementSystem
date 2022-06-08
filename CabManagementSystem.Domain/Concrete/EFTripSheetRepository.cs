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

    }
}
