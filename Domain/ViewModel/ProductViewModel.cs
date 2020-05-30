namespace Domain.ViewModel
{
    public class ProductViewModel
    {
        public int PID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public decimal? PurchaseCost { get; set; }

        public string PurchaseUnit { get; set; }
    }
}
