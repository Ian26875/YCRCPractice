using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YCRCPracticeWebApp.Models.ViewModels
{
    /// <summary>
    /// Class OrderEditViewModel.
    /// </summary>
    public class OrderEditViewModel
    {
        [Display(Name = "訂單ID")]
        public int OrderID { get; set; }

        [Display(Name = "客戶ID")]
        public string CustomerID { get; set; }

        [Display(Name = "員工ID")]
        public int? EmployeeID { get; set; }

        [Display(Name = "訂購日期")]
        public DateTime? OrderDate { get; set; }

        [Display(Name = "要求日期")]
        public DateTime? RequiredDate { get; set; }

        [Display(Name = "運送日期")]
        public DateTime? ShippedDate { get; set; }

        [Display(Name = "托運公司")]
        public int? ShipVia { get; set; }

        [Display(Name = "運費")]
        public decimal? Freight { get; set; }

        [Display(Name = "收件人名稱")]
        [StringLength(40)]
        public string ShipName { get; set; }

        [Display(Name = "收件人所在地址")]
        [StringLength(60)]
        public string ShipAddress { get; set; }

        [Display(Name = "收件人所在城市")]
        [StringLength(15)]
        public string ShipCity { get; set; }

        [Display(Name = "收件所在地區")]
        [StringLength(15)]
        public string ShipRegion { get; set; }

        [Display(Name = "收件郵編")]
        [StringLength(10)]
        public string ShipPostalCode { get; set; }

        [Display(Name = "收件所在國家")]
        [StringLength(15)]
        public string ShipCountry { get; set; }
    }
}