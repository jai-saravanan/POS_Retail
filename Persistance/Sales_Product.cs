//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Persistance
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sales_Product
    {
        public int SP_ID { get; set; }
        public int SalesID { get; set; }
        public int ProductID { get; set; }
        public string Warehouse { get; set; }
        public int QtyPerCarton { get; set; }
        public int TotalQty { get; set; }
        public decimal PricePerQtyBC { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Total_SalesdCurrency { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal PricePerQty { get; set; }
        public decimal Total_QuotedCurrency { get; set; }
        public decimal DiscountPer { get; set; }
        public decimal Discount { get; set; }
        public decimal VATPer { get; set; }
        public decimal VAT { get; set; }
        public decimal AdditionalVAT { get; set; }
        public decimal AdditionalVATPer { get; set; }
        public decimal TotalAmount { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual Warehouse Warehouse1 { get; set; }
    }
}
