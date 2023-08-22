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
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _datacontext;
        
        public IRepository<Schedule> Schedule {get;}
        public UnitOfWork(DataContext datacontext, IRepository<Schedule> schedule)
        {
            _datacontext = datacontext;
            Schedule = schedule;
        }
        public async void SaveChanges()
        {
            await _datacontext.SaveChangesAsync();
        }
    }
}
