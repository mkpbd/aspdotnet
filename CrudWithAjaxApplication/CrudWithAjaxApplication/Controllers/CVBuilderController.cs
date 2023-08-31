using CrudWithAjaxApplication.GenericInterfaces;
using CrudWithAjaxApplication.Models;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace CrudWithAjaxApplication.Controllers
{
    public class CVBuilderController : Controller
    {
        private readonly ILogger<CVBuilderController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private IHostEnvironment _environment;
        private IHostingEnvironment Environment;
        public CVBuilderController(ILogger<CVBuilderController> logger, IUnitOfWork unitOfWork,
            IHostEnvironment hostEnvironment, IHostingEnvironment hostingEnvironment )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _environment = hostEnvironment;
            Environment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> CVBuilderAdd(CVBuilderDTO customer)
        {


            return new JsonResult("Add Successful");

        }


        public async Task<JsonResult> ImageUpload(FileUploadDTO imageFile)
        {
            string base64 = Request.Form["image"];
            byte[] bytes = Convert.FromBase64String(base64.Split(',')[1]);

            string filePath = Path.Combine(this.Environment.WebRootPath, "Images", "Cropped.png");
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
            }

            return new JsonResult("Add Successful");
        }
    }
}