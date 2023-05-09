using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domin.Entities.CourseEntites;
using WebApp.Domin.Service;

namespace WebApp.Application.Service
{
    public class CourseService : ICourseService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public CourseService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<Course> GetCourses()
        {
            return _unitOfWork.Courses.GetAll();
        }
    }
}
