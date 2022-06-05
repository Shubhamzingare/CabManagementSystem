using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabManagementSystem.Domain.Entities;
using CabManagementSystem.Domain.Abstract;

namespace CabManagementSystem.Domain.Concrete
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private CabDbContext context = new CabDbContext();

        public IEnumerable<Employee> Employees => context.Employees;

        public Employee DeleteEmployee(int id)
        {
            Employee dbEntry = context.Employees.Find(id);
            if (dbEntry == null)
            {
                context.Employees.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveEmployee(Employee employee)
        {
            if (employee.empId == 0)
            {
                context.Employees.Add(employee);
            }
            else
            {
                Employee dbEntry = context.Employees.Find(employee.empId);
                if (dbEntry != null)
                {
                    dbEntry.empId = employee.empId;
                    dbEntry.empName = employee.empName;
                    dbEntry.perAddress = employee.perAddress;
                    dbEntry.comAddress = employee.comAddress;
                    dbEntry.qualification = employee.qualification;
                    dbEntry.DOB = employee.DOB;
                    dbEntry.vehrequired = employee.vehrequired;
                    dbEntry.gender = employee.gender;
                    dbEntry.phoneNo = employee.phoneNo;
                    dbEntry.designation = employee.designation;
                    dbEntry.department = employee.department;
                    dbEntry.DOJ = employee.DOJ;
                }
            }
            context.SaveChanges();
        }

    }
}
