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
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }
            
        public void Update(ApplicationUser user)
        {
           _context.ApplicationUsers.Update(user);
        }
    }
}
