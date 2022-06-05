using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CabManagementSystem.Domain.Entities;

namespace CabManagementSystem.WebUI.Models
{
    public class EmployeeListViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}