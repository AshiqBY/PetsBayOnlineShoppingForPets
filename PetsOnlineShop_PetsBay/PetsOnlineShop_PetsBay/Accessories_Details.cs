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
    
    public partial class Accessories_Details
    {
        public int Id { get; set; }
        public Nullable<int> Pets_Id { get; set; }
        public string Accessories_Name { get; set; }
        public Nullable<int> Accessories_Quantity { get; set; }
        public Nullable<int> Accessories_Price { get; set; }
        public string Accessories_Description { get; set; }
        public string Accessories_ImagePath { get; set; }
        public string Accessories_ImageName { get; set; }
    
        public virtual Pet_Details Pet_Details { get; set; }
    }
}
