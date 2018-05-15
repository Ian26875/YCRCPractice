using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YCRCPracticeWebApp.Models.ViewModels
{
    /// <summary>
    /// Class ProductViewModel.
    /// </summary>
    public class ProductViewModel
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>The name of the product.</value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the supplier identifier.
        /// </summary>
        /// <value>The supplier identifier.</value>
        public int? SupplierID { get; set; }

        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>The category identifier.</value>
        public int? CategoryID { get; set; }

        /// <summary>
        /// Gets or sets the quantity per unit.
        /// </summary>
        /// <value>The quantity per unit.</value>
        public string QuantityPerUnit { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>The unit price.</value>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the units in stock.
        /// </summary>
        /// <value>The units in stock.</value>
        public short? UnitsInStock { get; set; }

        /// <summary>
        /// Gets or sets the units on order.
        /// </summary>
        /// <value>The units on order.</value>
        public short? UnitsOnOrder { get; set; }

        /// <summary>
        /// Gets or sets the reorder level.
        /// </summary>
        /// <value>The reorder level.</value>
        public short? ReorderLevel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ProductDto"/> is discontinued.
        /// </summary>
        /// <value><c>true</c> if discontinued; otherwise, <c>false</c>.</value>
        public bool Discontinued { get; set; }
    }
}