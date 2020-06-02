using Domain.Model;
using Persistance;
using Repository.Interface;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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

        public List<PurchaseOrderDetailList> GetPOList(PurchaseOrderFilter purchaseOrderFilter)
        {
            return _dbContext.spGetPOList1(purchaseOrderFilter.SupplierName, purchaseOrderFilter.FromDate, purchaseOrderFilter.ToDate)
                .Select(x => new PurchaseOrderDetailList()
                {
                    POId = x.PO_ID,
                    Date = x.Date.ToString(),
                    GrandTotal = x.GrandTotal,
                    OrderDetail = x.OrderDetail,
                    PONumber = x.PONumber,
                    SupplierName = x.SupplierName
                })?.Distinct()?.ToList();


        }

        public decimal GetTotalAmtForAllPO()
        {
            return _dbContext.PurchaseOrders.Sum(x => x.GrandTotal).Value;
        }
    }
}
