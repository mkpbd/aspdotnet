using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domin.Entities;

namespace Web.Domin.Services
{
    public interface ICourseService
    {
         IList<Course> GetCourses();
    }
}
