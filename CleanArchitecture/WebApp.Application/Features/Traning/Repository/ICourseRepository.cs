using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domin.Entities.CourseEntites;
using WebApp.Domin.Repositories;

namespace WebApp.Application.Features.Traning.Repository
{
    public interface ICourseRepository : IRepository<Course, Guid>
    {

    }
}
