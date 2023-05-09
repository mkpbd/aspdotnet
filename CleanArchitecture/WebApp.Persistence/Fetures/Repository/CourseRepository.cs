using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Application.Features.Traning.Repository;
using WebApp.Domin.Entities.CourseEntites;

namespace WebApp.Persistence.Fetures.Repository
{
    public class CourseRepository : Repository<Course, Guid>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
