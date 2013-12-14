//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyCompanySellInfo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Stock
    {
        public int Id { get; set; }

        [Display(Name = "Goods")]
        public int GoodsID { get; set; }

        [Display(Name = "Client name")]
        [StringLength(50)]
        public string Client { get; set; }

        [Display(Name = "Manager")]
        public int ManagerID { get; set; }

        [Display(Name = "Date of sale")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime Date { get; set; }

        [Display(Name = "Purchase price")]
        [Range(1, 1000000)]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Cost { get; set; }

        public virtual Good Good { get; set; }

        public virtual Manager Manager { get; set; }
    }
}
