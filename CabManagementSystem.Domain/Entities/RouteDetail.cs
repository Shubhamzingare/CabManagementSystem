using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CabManagementSystem.Domain.Entities
{
    public class RouteDetail
    {
        [Key]
        public int routeId { get; set; }
        public int empId { get; set; }
        public string empName { get; set; }
        public string sourceLOC { get; set; }
        public string destLOC { get; set; }
        public int batchId { get; set; }

    }
}
