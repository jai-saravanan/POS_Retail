using Domain.Enum;
using System;
using System.Collections.Generic;
namespace Domain.ViewModel
{
    public class PurchaseOrderViewModel
    {
        public int POId { get; set; }

        public string PONumber { get; set; }

        public string Supplier_ID { get; set; }

        public string Terms { get; set; }

        public decimal SubTotal { get; set; }

        public decimal VATPer { get; set; }

        public decimal VATAmount { get; set; }

        public decimal GrandTotal { get; set; }

        public string TaxType { get; set; }

        public DateTime Date { get; set; }

        public List<TaxMasterViewModel> TaxData { get; set; }

        public List<SupplierViewModel> SupplierData { get; set; }

        public List<ProductViewModel> ProductData { get; set; }

        public List<PurchaseOrderDetailViewModel> ProductDetail { get; set; }

        public Status FormStatus { get; set; }
    }

    public class PurchaseOrderDetailViewModel
    {
        public int PurchaseOrderID { get; set; }

        public int ProductID { get; set; }

        public decimal Qty { get; set; }

        public decimal PricePerUnit { get; set; }

        public decimal Amount { get; set; }
    }
}
