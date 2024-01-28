using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using EngineeringDesk.Caching;
using LazyCache;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace EngineeringDesk.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private ICacheProvider _cacheProvider;

        public EmployeeController(IEmployeeRepository employeeRepository,ICacheProvider _cacheProvider)
        {
            _employeeRepository = employeeRepository;
        }

        public EmployeeController(IEmployeeRepository @object)
        {
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            if(!_cacheProvider.TryGetValue(CacheKeys.Employee, out List<Employee> employees))
            {
                employees = _employeeRepository.GetEmployees();

                var cacheEntryOption = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                    SlidingExpiration = TimeSpan.FromSeconds(30),
                    Size = 1024
                };

                _cacheProvider.Set(CacheKeys.Employee, employees, cacheEntryOption);
            }
            return Ok(employees);

            //try
            //{
            //    var employees = _employeeRepository.GetEmployees();
            //    return Ok(employees);
            //}
            //catch(Exception ex)
            //{
            //    return StatusCode(StatusCodes.Status412PreconditionFailed, ex.Message);
            //}
        }

        [HttpGet]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var Employee = _employeeRepository.GetEmployeeById(id);
                return Ok(Employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status412PreconditionFailed, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee Employee)
        {
            try
            {
                var addedEmployee = _employeeRepository.AddEmployee(Employee);
                return Ok(addedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status412PreconditionFailed, ex.Message);
            }
            
        }
    }
}
