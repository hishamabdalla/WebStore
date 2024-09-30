using ElectroWave.DataAccess.Data;
using ElectroWave.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroWave.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product  { get; private set; }


        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context) 
        {
            this._context = context;
            Category = new CategoryRepository(_context);
            Product = new ProductRepository(_context);
        }

        public void Save()
        {
           _context.SaveChanges();
        }
    }
}
