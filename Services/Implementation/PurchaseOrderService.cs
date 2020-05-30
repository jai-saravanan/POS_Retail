using Domain.ViewModel;
using Persistance;
using Repository.Interface;
using Services.Interface;
using System;
using System.Linq;

namespace Services.Implementation
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }
        public int GetLastPONumber()
        {
            return _purchaseOrderRepository.GetLastPONumber();
        }

        public bool SavePODetails(PurchaseOrderViewModel purchaseOrderViewModel)
        {
            var purchaseOrder = new PurchaseOrder()
            {
                PO_ID = purchaseOrderViewModel.POId,
                Date = DateTime.Now,
                GrandTotal = purchaseOrderViewModel.GrandTotal,
                PONumber = purchaseOrderViewModel.PONumber,
                SubTotal = purchaseOrderViewModel.SubTotal,
                Supplier_ID = purchaseOrderViewModel.Supplier_ID,
                TaxType = "",
                Terms = purchaseOrderViewModel.Terms,
                VATAmount = purchaseOrderViewModel.VATAmount,
                VATPer = purchaseOrderViewModel.VATPer,
                PurchaseOrder_Join = purchaseOrderViewModel.ProductDetail
                                                                .Select(x => new PurchaseOrder_Join()
                                                                {
                                                                    Amount = x.Amount,
                                                                    PricePerUnit = x.PricePerUnit,
                                                                    ProductID = x.ProductID,
                                                                    PurchaseOrderID = purchaseOrderViewModel.POId,
                                                                    Qty = x.Qty
                                                                }).ToList()
            };
            return _purchaseOrderRepository.SavePODetails(purchaseOrder);
        }
    }
}
