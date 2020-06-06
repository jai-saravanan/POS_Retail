using System;

namespace Domain.Model
{
    public class PurchaseOrderDetailList
    {
        public int POId { get; set; }

        public string PONumber { get; set; }

        public string Date { get; set; }

        public string SupplierName { get; set; }

        public string OrderDetail { get; set; }

        public decimal? GrandTotal { get; set; }

        public bool IsDeleted { get; set; }
    }


    public class PurchaseOrderFilter
    {
        public int? SupplierId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
