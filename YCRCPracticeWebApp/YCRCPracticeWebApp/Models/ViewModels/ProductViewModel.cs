using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YCRCPracticeWebApp.Models.ViewModels
{
    /// <summary>
    /// Class ProductViewModel.
    /// </summary>
    public class ProductViewModel
    {
        [Display(Name = "產品Id")]
        [Range(0, int.MaxValue)]
        public int ProductID { get; set; }

        [Display(Name = "")]
        [StringLength(40)]
        public string ProductName { get; set; }

        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
    }
}