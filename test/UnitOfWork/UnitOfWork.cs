using DataAccess.Repository;
using ModelsF.Models;
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

        public IRepository<Product> Product { get;}

        public IRepository<Category> Category { get; }


        public UnitOfWork(DataContext datacontext, IRepository<Schedule> schedule,IRepository<Product> product, IRepository<Category> category)
        {
            _datacontext = datacontext;
            Schedule = schedule;
            Product = product;
            Category = category;
        }
        public void SaveChanges()
        {
            _datacontext.SaveChanges();
        }
    }
}
