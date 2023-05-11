using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Features.Traning.Repository;
using Web.Domin.UnitOfWorks;

namespace Web.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {

        ICourseRepository Courses {  get; }
    }
}
