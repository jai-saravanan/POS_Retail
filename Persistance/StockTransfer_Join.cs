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
    
    public partial class StockTransfer_Join
    {
        public int STJ_ID { get; set; }
        public int StockTransferID { get; set; }
        public string Warehouse { get; set; }
        public int ProductID { get; set; }
        public string Barcode { get; set; }
        public Nullable<decimal> SalesRate { get; set; }
        public string ManufacturingDate { get; set; }
        public string ExpiryDate { get; set; }
        public Nullable<decimal> Qty { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual StockTransfer StockTransfer { get; set; }
        public virtual Warehouse Warehouse1 { get; set; }
    }
}
