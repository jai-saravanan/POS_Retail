using Persistance;
using Repository.Interface;
using System.Linq;

namespace Repository.Implementation
{
    public class SupplierRepository : ISupplierRepository
    {
        private POSDbContext _dbContext;
        public SupplierRepository(POSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Supplier> GetAllSubliers()
        {
            return _dbContext.Suppliers.AsQueryable();
        }

        public Supplier GetAllSubliersById(int supplierId)
        {
            return _dbContext.Suppliers.Where(x => x.ID == supplierId).FirstOrDefault();
        }
    }
}
