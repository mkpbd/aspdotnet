using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domin.Entities;
using Web.Domin.Repositories;

namespace Web.Application.Features.Traning.Repository
{
    public interface ICourseRepository : IRepository<Course, Guid>
    {
    }
}
