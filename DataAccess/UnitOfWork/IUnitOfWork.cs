using DataAccess.Repository;
using MVCAnri.Controllers.Data;
using MVCAnri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {

        IRepository<Schedule> Schedule { get; }

        public void SaveChanges();

        

    }
}
