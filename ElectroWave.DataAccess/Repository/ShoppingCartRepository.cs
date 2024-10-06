using ElectroWave.DataAccess.Data;
using ElectroWave.DataAccess.Repository.IRepository;
using ElectroWave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroWave.DataAccess.Repository
{
    public class ShopingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _context;

        public ShopingCartRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public void Update(ShoppingCart Obj)
        {
            _context.ShoppingCarts.Update(Obj);
        }
    }
}
