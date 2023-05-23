using BusnessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class UserService
    {

        public string Create(string contactDetails)
        {
            string result = null;
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
            return result;
        }
    }
}
