using ElectroWave.DataAccess.Data;
using ElectroWave.DataAccess.Repository.IRepository;
using ElectroWave.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroWave.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context):base(context) 
        {
            this._context = context;
        }
        public void Updata(Product obj)
        {
            var objFromDb = _context.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name=obj.Name;
                objFromDb.Description=obj.Description;
                objFromDb.Price=obj.Price;
                objFromDb.OriginalPrice=obj.OriginalPrice;
                objFromDb.CategoryId=obj.CategoryId;

                if (obj.ImageURL != null)
                {
                    objFromDb.ImageURL=obj.ImageURL;   
                }
            }

        }
    }
}
