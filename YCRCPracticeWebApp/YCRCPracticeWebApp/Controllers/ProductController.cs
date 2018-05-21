using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using WebGrease.Css.Extensions;
using YCRCPracticeWebApp.Models.ViewModels;
using YCRCPracticeWebApp.Service.DataTransferObject;
using YCRCPracticeWebApp.Service.Interface;

namespace YCRCPracticeWebApp.Controllers
{
    public class ProductController : BaseController
    {
        /// <summary>
        /// The product service
        /// </summary>
        private readonly IProductService _productSvc;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="productService">The product service.</param>
        public ProductController(IProductService productService)
        {
            this._productSvc = productService;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [ChildActionOnly]
        public ActionResult List(int pageNumber = 1, int pageSize = 10)
        {
            var dtos = _productSvc.GetAllProducts();           
            var viewModels = Mapper.Map<IList<ProductDto>, IList<ProductViewModel>>(dtos);
            var pageLists = viewModels.ToPagedList(pageNumber, pageSize);
            return PartialView("_List", pageLists);
        }
    }
}