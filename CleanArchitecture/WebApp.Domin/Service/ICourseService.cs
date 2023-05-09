using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domin.Entities.CourseEntites;

namespace WebApp.Domin.Service
{
    public interface ICourseService
    {
        public IList<Course> GetCourses();
    }
}
