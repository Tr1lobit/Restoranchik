//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestoApp_Afonichev.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Position
    {
        public Position()
        {
            this.ChequePosition = new HashSet<ChequePosition>();
        }
    
        public int PositionId { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public int CategoryId { get; set; }
        public byte[] Photo { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<ChequePosition> ChequePosition { get; set; }
    }
}
