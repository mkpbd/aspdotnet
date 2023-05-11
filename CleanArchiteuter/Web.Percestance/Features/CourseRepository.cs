using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Features.Traning.Repository;
using Web.Domin.Entities;

namespace Web.Percestance.Features
{
    public class CourseRepository : Repository<Course, Guid>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}
