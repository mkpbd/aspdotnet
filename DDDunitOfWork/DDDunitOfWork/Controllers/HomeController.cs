using DDDunitOfWork.Models;
using DDDunitOfWork.UnitOfWroks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DDDunitOfWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            Employee employee = new Employee()
            {
                Name = "jamal",
                Address = "gazipur",
                Email = "abc@gmail.com",
                Phone = "34341234132"

            };
            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Save();

           var rr =  _unitOfWork.EmployeeRepository.GetAll();
            
            return View();
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