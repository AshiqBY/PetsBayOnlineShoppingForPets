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
    
    public partial class Seller_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seller_Details()
        {
            this.Feedback_Details = new HashSet<Feedback_Details>();
            this.Pet_Details = new HashSet<Pet_Details>();
        }
    
        public int Id { get; set; }
        public string Seller_Name { get; set; }
        public string Seller_Address { get; set; }
        public string Seller_City { get; set; }
        public string Seller_State { get; set; }
        public string Seller_Pincode { get; set; }
        public string Seller_EmailId { get; set; }
        public string Seller_MobileNo { get; set; }
        public string Seller_UserId { get; set; }
        public string Seller_ImagePath { get; set; }
        public string Seller_ImageName { get; set; }
        public string Seller_Password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback_Details> Feedback_Details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pet_Details> Pet_Details { get; set; }
    }
}