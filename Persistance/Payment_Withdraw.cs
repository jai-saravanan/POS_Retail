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
    
    public partial class Payment_Withdraw
    {
        public int id { get; set; }
        public string AccountFrom { get; set; }
        public string PaymentMode { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string ReceiverName { get; set; }
        public string PhoneNo { get; set; }
        public string Notes { get; set; }
    
        public virtual BankAccountRegistration BankAccountRegistration { get; set; }
    }
}
