﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using YCRCPracticeWebApp.ActionFilter;
using YCRCPracticeWebApp.ActionResults;
using YCRCPracticeWebApp.Models.ViewModels;
using YCRCPracticeWebApp.Service.DataTransferObject;
using YCRCPracticeWebApp.Service.Interface;

namespace YCRCPracticeWebApp.Controllers
{
    /// <summary>
    /// Class OrderController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class OrderController : BaseController
    {

        /// <summary>
        /// The order service
        /// </summary>
        private readonly IOrderService _orderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// </summary>
        /// <param name="orderService">The order service.</param>
        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
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
        /// Lists the specified page number.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>ActionResult.</returns>
        [ChildActionOnly]
        public ActionResult List(int pageNumber = 1, int pageSize = 20)
        {
            var dtos = this._orderService.GetAllOrders();
            var viewModels = Mapper.Map<IList<OrderDto>, IList<OrderViewModel>>(dtos);
            var pageLists = viewModels.ToPagedList(pageNumber, pageSize);
            ViewData["PageSize"] = pageSize;
            return PartialView("_List", pageLists);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [TransactionEvent]
        public ActionResult Create(OrderCreateViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(viewModel);
            }
            var dto = Mapper.Map<OrderCreateViewModel, OrderDto>(viewModel);
            this._orderService.CreateOrder(dto);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Edits the specified order identifier.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Edit(int orderId)
        {
            var order=this._orderService.GetOrder(orderId);
            if (order == null)
            {
                return HttpNotFound();
            }
            var viewModel = Mapper.Map<OrderDto, OrderEditViewModel>(order);
            return View(viewModel);
        }

        /// <summary>
        /// Edits the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [TransactionEvent]
        public ActionResult Edit(OrderEditViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(viewModel);
            }
            var dto = Mapper.Map<OrderEditViewModel, OrderDto>(viewModel);
            this._orderService.EditOrder(dto);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Deletes the specified order identifier.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Delete(int orderId)
        {
            var order = this._orderService.GetOrder(orderId);
            if (order == null)
            {
                return HttpNotFound();
            }
            var viewModel = Mapper.Map<OrderDto, OrderDeleteViewModel>(order);
            return View(viewModel);
        }

        /// <summary>
        /// Deletes the confirm.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        [TransactionEvent]
        public ActionResult DeleteConfirm(int orderId)
        {
            this._orderService.DeleteOrder(orderId);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Exports the CSV.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult ExportCsv()
        {
            var source = this._orderService.GetAllOrders();          
            var viewModel = Mapper.Map<IList<OrderDto>, IList<OrderDeleteViewModel>>(source);
            return new CsvFileResult<OrderDeleteViewModel>(viewModel, "Order.csv");
        }
    }
}