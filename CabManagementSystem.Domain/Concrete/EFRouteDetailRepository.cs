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

        public void SaveRoute(RouteDetail routeDetail)
        {
            if (routeDetail.routeId == 0)
            {
                context.RouteDetails.Add(routeDetail);
            }
            else
            {
                RouteDetail dbEntry = context.RouteDetails.Find(routeDetail.routeId);
                if (dbEntry != null)
                {
                    dbEntry.routeId = routeDetail.routeId;
                    dbEntry.empId = routeDetail.empId;
                    dbEntry.empName = routeDetail.empName;
                    dbEntry.sourceLOC = routeDetail.sourceLOC;
                    dbEntry.destLOC = routeDetail.destLOC;
                    dbEntry.batchId = routeDetail.batchId;
                }
            }
            context.SaveChanges();
        }

    }
}
