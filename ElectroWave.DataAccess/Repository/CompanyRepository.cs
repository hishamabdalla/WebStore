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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }
        public void Update(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
