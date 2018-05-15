using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YCRCPracticeWebApp.Repository;
using YCRCPracticeWebApp.Repository.Interface;
using YCRCPracticeWebApp.Service.DataTransferObject;
using YCRCPracticeWebApp.Service.Interface;

namespace YCRCPracticeWebApp.Service
{
    /// <summary>
    /// Class ProductService.
    /// </summary>
    public class ProductService : IProductService
    {

        /// <summary>
        /// The Product Repository
        /// </summary>
        private readonly IGeneralRepository<Products> _productRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="productRepo">The product repo.</param>
        public ProductService(IGeneralRepository<Products> productRepo)
        {
            this._productRepo = productRepo;
        }

        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <param name="dto">The dto.</param>
        public void CreateProduct(ProductDto dto)
        {
            var model = Mapper.Map<ProductDto, Products>(dto);
            this._productRepo.Insert(model);
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="dto">The dto.</param>
        public void DeleteProduct(ProductDto dto)
        {
            var model = Mapper.Map<ProductDto, Products>(dto);
            this._productRepo.Delete(model);
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        public void DeleteProduct(int productId)
        {
            var source = _productRepo.Find(productId);
            this._productRepo.Delete(source);
        }

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="dto">The dto.</param>
        public void UpdateProduct(ProductDto dto)
        {
            var model = Mapper.Map<ProductDto, Products>(dto);
            this._productRepo.Update(model);
        }

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
        public IList<ProductDto> GetPageProducts(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber));
            }
            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }
            var source = this._productRepo
                    .GetAll()
                    .OrderBy(x => x.ProductID)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            var dtos = Mapper.Map<IList<Products>, IList<ProductDto>>(source);
            return dtos;
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>IList&lt;ProductDto&gt;.</returns>
        public IList<ProductDto> GetAllProducts()
        {
            var source = this._productRepo
                  .GetAll()
                  .OrderBy(x => x.ProductID)
                  .ToList();
            var dtos = Mapper.Map<IList<Products>, IList<ProductDto>>(source);
            return dtos;
        }

        /// <summary>
        /// Gets the name of the products by product.
        /// </summary>
        /// <param name="productName">Name of the product.</param>
        /// <returns>IList&lt;ProductDto&gt;.</returns>
        public IList<ProductDto> GetProductsByProductName(string productName)
        {
            var source = this._productRepo
                 .Where(x => x.ProductName.Contains(productName))
                 .OrderBy(x => x.ProductID)
                 .ToList();
            var dtos = Mapper.Map<IList<Products>, IList<ProductDto>>(source);
            return dtos;
        }
    }
}
