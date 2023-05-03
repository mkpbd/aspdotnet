using Microsoft.AspNetCore.Mvc;
using MVCProjectBootsrping.Data.Migrations;
using MVCProjectBootsrping.Models;
using MVCProjectBootsrping.Repository;
using System.Diagnostics;

namespace MVCProjectBootsrping.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeReposiory _employeeReposiory;

        public HomeController(ILogger<HomeController> logger, IEmployeeReposiory employeeReposiory)
        {
            _logger = logger;
            _employeeReposiory = employeeReposiory;
        }

        public IActionResult Index()
        {
            Employee employee = new Employee();
            employee.Name = "jamal";
            employee.EmployeeName = 88;
            employee.EmployeeAge = 600;
            employee.Description = "kamal";
            employee.EmployeeId = 887;

            _employeeReposiory.Add(employee);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}