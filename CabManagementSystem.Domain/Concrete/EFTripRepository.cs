using CabManagementSystem.Domain.Abstract;
using CabManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabManagementSystem.Domain.Concrete
{
    public class EFTripRepository : ITripRepository
    {
        private CabDbContext context = new CabDbContext();

        public IEnumerable<Trip> TripSheet => context.TripSheet;
        //
    }
}
