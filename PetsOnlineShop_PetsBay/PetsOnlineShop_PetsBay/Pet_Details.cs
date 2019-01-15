//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetsOnlineShop_PetsBay
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pet_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pet_Details()
        {
            this.Accessories_Details = new HashSet<Accessories_Details>();
            this.Category_Details = new HashSet<Category_Details>();
            this.Order_Cart = new HashSet<Order_Cart>();
            this.Order_Details = new HashSet<Order_Details>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Seller_Id { get; set; }
        public string Pet_Category { get; set; }
        public string Pet_Description { get; set; }
        public string Pet_Color { get; set; }
        public Nullable<int> Pet_Age { get; set; }
        public Nullable<int> Pet_Weight { get; set; }
        public string Pet_Gender { get; set; }
        public Nullable<int> Pet_AvailableQuantity { get; set; }
        public Nullable<decimal> Pet_Price { get; set; }
        public string Pet_ImagePath { get; set; }
        public string Pet_ImageName { get; set; }
        public string Flag { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Accessories_Details> Accessories_Details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category_Details> Category_Details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Cart> Order_Cart { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Details> Order_Details { get; set; }
        public virtual Seller_Details Seller_Details { get; set; }
    }
}
