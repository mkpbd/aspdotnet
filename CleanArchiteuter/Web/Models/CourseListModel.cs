using Web.Domin.Entities;
using Web.Domin.Services;

namespace Web.Models
{
    public class CourseListModel
    {
        private readonly ICourseService _courseService;

        public CourseListModel()
        {

        }

        public CourseListModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IList<Course> GetPopularCourses()
        {
            return _courseService.GetCourses();
        }
    }
}
