using DatabaseProject.Interfaces;
using DatabaseProject.DatabaseContext;
using DatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace DatabaseProject.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SqlServerContext _sqlServerContext;

        public EmployeeRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public List<Employee> GetEmployees()
        {
           var listEmployees = _sqlServerContext.Employee.ToList();
           return listEmployees;
        }

        public Employee GetEmployeeById(int id)
        {
            var Employee = _sqlServerContext.Employee.FirstOrDefault(x => x.EmployeeId == id);
            return Employee;
        }

        public Employee AddEmployee(Employee Employee)
        {
            _sqlServerContext.Employee.Add(Employee);
            _sqlServerContext.SaveChanges();
            return Employee;
        }
    }
}
