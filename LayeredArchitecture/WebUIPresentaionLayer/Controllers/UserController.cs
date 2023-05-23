using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;
using System.Security.AccessControl;
using WebUIPresentaionLayer.Data;

namespace WebUIPresentaionLayer.Controllers
{
    public class UserController : Controller
    {
        private readonly DbContext _db;
        //public UserController(ApplicationDbContext db) {
        //        _db = db;
        //}
        
        public IActionResult Index()
        {
            return View();
        }


        public ActionResult Create(ContactDetails contactDetails)
        {
            //  OperationResult result = null;
            //try
            //{
            //    _db.StartTransaction();
            //    var user = new User();
            //    user.SetContactDetails(contactDetails)
            //user.Save();
            //    _db.Commit();
            //    result = OperationResult.Success;
            //}
            //catch (Exception ex)
            //{
            //    _db.Rollback();
            //    result = OperationResult.Exception(ex);
            //}
  
            
           var resutl =   new UserService().Create("Hellow");
            return View(resutl);
        }
    }
}
