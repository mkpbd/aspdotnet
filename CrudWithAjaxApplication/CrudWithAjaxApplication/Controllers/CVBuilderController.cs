using CrudWithAjaxApplication.GenericInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudWithAjaxApplication.Controllers
{
    public class CVBuilderController : Controller
    {
        private readonly ILogger<CVBuilderController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public CVBuilderController(ILogger<CVBuilderController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }



    }
}
