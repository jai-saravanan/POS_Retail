using Domain.Enum;
using Domain.Model;
using Domain.ViewModel;
using Persistance;
using Repository.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
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

        public List<PurchaseOrderDetailList> GetPOList(PurchaseOrderFilter purchaseOrderFilter)
        {
            return _purchaseOrderRepository.GetPOList(purchaseOrderFilter);
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
                TaxType = purchaseOrderViewModel.TaxType,
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
            return _purchaseOrderRepository.SavePODetails(purchaseOrder, purchaseOrderViewModel.FormStatus);
        }

        public decimal GetTotalAmtForAllPO()
        {
            return _purchaseOrderRepository.GetTotalAmtForAllPO();
        }

        public PurchaseOrderViewModel GetPurchaseOrderById(int purchaseOrderId)
        {
            var data = _purchaseOrderRepository.GetPurchaseOrderById(purchaseOrderId);

            return new PurchaseOrderViewModel()
            {
                Date = data.Date.Value,
                GrandTotal = data.GrandTotal.Value,
                POId = data.PO_ID,
                PONumber = data.PONumber,
                ProductDetail = data.PurchaseOrder_Join.Select(x => new PurchaseOrderDetailViewModel()
                {
                    Amount = x.Amount.Value,
                    PricePerUnit = x.PricePerUnit.Value,
                    ProductID = x.ProductID,
                    PurchaseOrderID = x.PurchaseOrderID,
                    Qty = x.Qty
                }).ToList(),
                SubTotal = data.SubTotal.Value,
                Supplier_ID = data.Supplier_ID,
                TaxType = data.TaxType,
                Terms = data.Terms,
                VATAmount = data.VATAmount.Value,
                VATPer = data.VATPer.Value
            };
        }

        public void DeletePurchaseOrderById(int purchaseOrderId)
        {
            _purchaseOrderRepository.DeletePurchaseOrderById(purchaseOrderId);
        }
    }
}
