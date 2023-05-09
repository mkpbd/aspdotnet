using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Application.Features.Traning.Repository;
using WebApp.Domin.UnitOfWorks;

namespace WebApp.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        ICourseRepository Courses { get; }
    }
}
