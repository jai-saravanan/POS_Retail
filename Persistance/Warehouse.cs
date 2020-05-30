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
    
    public partial class Warehouse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Warehouse()
        {
            this.Sales_Product = new HashSet<Sales_Product>();
            this.StockAdjustment_Warehouse = new HashSet<StockAdjustment_Warehouse>();
            this.StockTransfer_Join = new HashSet<StockTransfer_Join>();
            this.StockTransfer_W2W = new HashSet<StockTransfer_W2W>();
            this.Temp_Stock = new HashSet<Temp_Stock>();
        }
    
        public string WarehouseName { get; set; }
        public string Address { get; set; }
        public string WarehouseType { get; set; }
        public string City { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sales_Product> Sales_Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockAdjustment_Warehouse> StockAdjustment_Warehouse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockTransfer_Join> StockTransfer_Join { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockTransfer_W2W> StockTransfer_W2W { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Temp_Stock> Temp_Stock { get; set; }
        public virtual WarehouseType WarehouseType1 { get; set; }
    }
}
