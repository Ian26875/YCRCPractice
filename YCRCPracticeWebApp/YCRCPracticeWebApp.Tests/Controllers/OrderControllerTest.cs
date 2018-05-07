using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YCRCPracticeWebApp.Service.Interface;
using NSubstitute;
using FluentAssertions;
using YCRCPracticeWebApp.Controllers;
using System.Web.Mvc;
using AutoFixture;
using YCRCPracticeWebApp.Service.DataTransferObject;

namespace YCRCPracticeWebApp.Tests.Controllers
{
    /// <summary>
    /// Class OrderControllerTest.
    /// </summary>
    [TestClass]
    public class OrderControllerTest
    {
        private IOrderService OrderSvc { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            OrderSvc = Substitute.For<IOrderService>();
        }

        /// <summary>
        /// Gets the system under test.
        /// </summary>
        /// <returns>OrderController.</returns>
        private OrderController GetSystemUnderTest()
        {
            var sut = new OrderController(this.OrderSvc);
            return sut;
        }

        [TestCategory("OrderController")]
        [TestProperty("OrderController", "Index")]
        [TestMethod]
        public void Index_執行Index頁面_ViewResult不為Null()
        {
            // arrange
            var sut = GetSystemUnderTest();

            // act
            ViewResult actual = sut.Index() as ViewResult;

            // assert
            actual.Should().NotBeNull();
        }

        [TestCategory("OrderController")]
        [TestProperty("OrderController", "List")]
        [TestMethod]
        public void List_執行List頁面資料_應為回傳Model及ViewName為_List()
        {
            // arrange        
            var expected = "_List";

            var fixture = new Fixture();
            var dtos = fixture.Build<OrderDto>()
                              .CreateMany(30)
                              .ToList();

            OrderSvc.GetPageOrders(1, 20)
                    .Returns(dtos);

            var sut = GetSystemUnderTest();
            // act
            PartialViewResult actual = sut.List() as PartialViewResult;

            // assert
            actual.Model.Should().NotBeNull();
            actual.ViewName.Should().Be(expected);
        }
    }
}
