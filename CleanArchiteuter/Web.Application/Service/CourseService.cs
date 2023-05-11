using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domin.Entities;
using Web.Domin.Services;

namespace Web.Application.Service
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
