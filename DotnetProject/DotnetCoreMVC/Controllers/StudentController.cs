using DotnetCoreMVC.Models;
using DotnetCoreMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreMVC.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            StudentBusinessLayer studentBL = new StudentBusinessLayer();
            IEnumerable<Student> studentDetail = studentBL.GetAll();
            return View(studentDetail);
        }

        // Get Stduent Details 
        public ActionResult Details(int studentId)
        {
            StudentBusinessLayer studentBL = new StudentBusinessLayer();
            Student studentDetail = studentBL.GetById(studentId);
            return View(studentDetail);
        }
    }
}
