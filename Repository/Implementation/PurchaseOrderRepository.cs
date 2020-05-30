using Persistance;
using Repository.Interface;
using System.Linq;

namespace Repository.Implementation
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private POSDbContext _dbContext;
        public PurchaseOrderRepository(POSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetLastPONumber()
        {
            return _dbContext.PurchaseOrders.OrderByDescending(x => x.PO_ID).FirstOrDefault()?.PO_ID ?? 1;
        }

        public bool SavePODetails(PurchaseOrder purchaseOrder)
        {
            try
            {
                _dbContext.PurchaseOrders.Add(purchaseOrder);
                _dbContext.SaveChanges();
                return true;
            }
            catch (System.Exception Ex)
            {
                return false;
            }

        }
    }
}
