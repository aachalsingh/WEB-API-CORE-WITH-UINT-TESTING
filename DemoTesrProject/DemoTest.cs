using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using DatabaseProject.DatabaseContext;
using DatabaseProject.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineeringDesk.Controllers;

namespace DemoTesrProject
{
    [TestClass]
    public class DemoTest
    {
        [TestMethod]
        public void TestGetEmployeeByIdMethod()
        {
            var employee = new Employee
            {
                EmployeeId = 1,
                EmployeeName = "AAAA",
                City = "Kathmandu",
                DateOfJoining = System.DateTime.MaxValue,
                Salary = 134000
            };
            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(x => x.GetEmployeeById(employee.EmployeeId)).Returns(employee);
            var controller = new EmployeeController(employeeRepository.Object);

            var getEmployeeById = controller.GetEmployeeById(1);
            Assert.IsNotNull(getEmployeeById);
        }
        [TestMethod]
        public void TestGetSum()
        {
            int x = 9, y = 7;
            var results = GetSum(x, y);
            Assert.AreEqual(x+y, results);
            Assert.AreNotEqual(x-y, results);
        }

        [TestMethod]
        public void TestGetFullName()
        {
            string firstName = "aac";
            string lastName = "singh";
            var result = GetFullName(firstName, lastName);
            Assert.AreEqual(firstName+lastName, result);
            Assert.IsNotNull(result);
        }
        private int GetSum(int x, int y)
        {
            return x + y;
        }

        private string GetFullName(string firstName, string lastName)
        {
            string fullName = firstName + lastName;
            return fullName;
        }
    }
}
