using System.Collections.Generic;

namespace Domain.ViewModel
{
    public class SupplierViewModel
    {
        public int ID { get; set; }
        public string SupplierID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ContactNo { get; set; }
        public decimal? OpeningBalance { get; set; }
    }


    public class POCumulativeViewModel
    {
        public List<SupplierViewModel> SupplierData { get; set; }

        public decimal TotalAmt { get; set; }
    }
}
