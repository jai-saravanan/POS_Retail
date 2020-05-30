using Persistance;
using Repository.Interface;
using System.Linq;

namespace Repository.Implementation
{
    public class TaxMasterRepository : ITaxMasterRepository
    {
        private POSDbContext _dbContext;
        public TaxMasterRepository(POSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TaxMaster> GetAllTax()
        {
            return _dbContext.TaxMasters.AsQueryable();
        }
    }
}
