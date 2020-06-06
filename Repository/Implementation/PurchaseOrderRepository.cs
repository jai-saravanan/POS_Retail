using Domain.Enum;
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

        public bool SavePODetails(PurchaseOrder purchaseOrder, Status formStatus)
        {
            try
            {
                if (formStatus == Status.Create)
                {
                    _dbContext.PurchaseOrders.Add(purchaseOrder);
                    _dbContext.SaveChanges();
                }
                else
                {
                    var data = _dbContext.PurchaseOrders.FirstOrDefault(x => x.PO_ID == purchaseOrder.PO_ID);

                    var list = data.PurchaseOrder_Join.ToList();
                    foreach (var item in list)
                    {
                        _dbContext.PurchaseOrder_Join.Remove(item);
                    }

                    data.TaxType = purchaseOrder.TaxType;
                    data.Date = purchaseOrder.Date;
                    data.GrandTotal = purchaseOrder.GrandTotal;
                    data.SubTotal = purchaseOrder.SubTotal;
                    data.Supplier_ID = purchaseOrder.Supplier_ID;
                    data.Terms = purchaseOrder.Terms;
                    data.VATAmount = purchaseOrder.VATAmount;
                    data.VATPer = purchaseOrder.VATPer;
                    _dbContext.PurchaseOrder_Join.AddRange(purchaseOrder.PurchaseOrder_Join);
                    _dbContext.SaveChanges();
                }
                return true;
            }
            catch (System.Exception Ex)
            {
                return false;
            }

        }

        public List<PurchaseOrderDetailList> GetPOList(PurchaseOrderFilter purchaseOrderFilter)
        {
            return _dbContext.spGetPOList2(purchaseOrderFilter.SupplierId, purchaseOrderFilter.FromDate, purchaseOrderFilter.ToDate)
                .Select(x => new PurchaseOrderDetailList()
                {
                    POId = x.PO_ID,
                    Date = x.Date.ToString(),
                    GrandTotal = x.GrandTotal,
                    OrderDetail = x.OrderDetail,
                    PONumber = x.PONumber,
                    SupplierName = x.SupplierName,
                    IsDeleted = x.IsDeleted ?? false
                })?.Distinct()?.ToList();


        }

        public decimal GetTotalAmtForAllPO()
        {
            return _dbContext.PurchaseOrders.Sum(x => x.GrandTotal).Value;
        }

        public PurchaseOrder GetPurchaseOrderById(int purchaseOrderId)
        {
            return _dbContext.PurchaseOrders.Include("PurchaseOrder_Join").FirstOrDefault(x => x.PO_ID == purchaseOrderId);
        }

        public void DeletePurchaseOrderById(int purchaseOrderId)
        {
            var data = _dbContext.PurchaseOrders.First(x => x.PO_ID == purchaseOrderId);
            data.IsDeleted = true;
            _dbContext.SaveChanges();
        }
    }
}
