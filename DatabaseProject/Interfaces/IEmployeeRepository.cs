using DatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Interfaces
{
    //creating 3 APIs - 1. returns all Employee data, ii. returns based on the id, iii. we intert Employee ourself
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();

        Employee GetEmployeeById(int id);

        Employee AddEmployee(Employee Employee);
    }
}

