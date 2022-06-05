using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabManagementSystem.Domain.Entities;
using CabManagementSystem.Domain.Abstract;

namespace CabManagementSystem.Domain.Concrete
{
    public class EFRouteDetailRepository : IRouteDetailRepository
    {
        private CabDbContext context = new CabDbContext();

        public IEnumerable<RouteDetail> RouteDetails => context.RouteDetails;

    }
}
