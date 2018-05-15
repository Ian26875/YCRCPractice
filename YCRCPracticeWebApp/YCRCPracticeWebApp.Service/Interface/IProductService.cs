using System.Collections.Generic;
using YCRCPracticeWebApp.Service.DataTransferObject;

namespace YCRCPracticeWebApp.Service.Interface
{
    public interface IProductService
    {
        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <param name="dto">The dto.</param>
        void CreateProduct(ProductDto dto);

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="dto">The dto.</param>
        void DeleteProduct(ProductDto dto);

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        void DeleteProduct(int productId);

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="dto">The dto.</param>
        void EditProduct(ProductDto dto);

        /// <summary>
        /// Gets the page products.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IList&lt;ProductDto&gt;.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// pageNumber
        /// or
        /// pageSize
        /// </exception>
        IList<ProductDto> GetPageProducts(int pageNumber, int pageSize);

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>IList&lt;ProductDto&gt;.</returns>
        IList<ProductDto> GetAllProducts();

        /// <summary>
        /// Gets the name of the products by product.
        /// </summary>
        /// <param name="productName">Name of the product.</param>
        /// <returns>IList&lt;ProductDto&gt;.</returns>
        IList<ProductDto> GetProductsByProductName(string productName);

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>ProductDto.</returns>
        ProductDto GetProduct(int productId);
    }
}