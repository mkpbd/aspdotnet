using DDDGroupStudy.Web.Models;
using DDDGroupStudy.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DDDGroupStudy.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository  )
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            Employee employee = new Employee()
            {
                Name = "shamim",
                Description = "Group Study",
                EmployeeId = 56878,

            };
            _employeeRepository.Add(employee);

            var getAll = _employeeRepository.GetAll();


            return View(getAll);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}