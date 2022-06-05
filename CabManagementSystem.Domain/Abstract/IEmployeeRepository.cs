using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabManagementSystem.Domain.Entities;

namespace CabManagementSystem.Domain.Abstract
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Employees { get; }

        void SaveEmployee(Employee employee);

        Employee DeleteEmployee(int id);

    }
}
