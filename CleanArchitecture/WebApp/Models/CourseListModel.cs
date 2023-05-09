using WebApp.Domin.Entities.CourseEntites;
using WebApp.Domin.Service;

namespace WebApp.Models
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
