//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace shadab_electonic_shop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCT
    {
        public int ID { get; set; }
        public string PRODUCTNAME { get; set; }
        public Nullable<int> CAT_ID { get; set; }
        public Nullable<int> BRAND_ID { get; set; }
        public Nullable<decimal> QUANTITY { get; set; }
        public Nullable<decimal> PRICE { get; set; }
    
        public virtual BRAND BRAND { get; set; }
        public virtual CATEGORY CATEGORY { get; set; }
    }
}
