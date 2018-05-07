using System;
using System.Linq;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YCRCPracticeWebApp.Repository;
using YCRCPracticeWebApp.Repository.Interface;
using NSubstitute;
using FluentAssertions;
using YCRCPracticeWebApp.Service;
using YCRCPracticeWebApp.Service.Interface;
using AutoMapper;
using YCRCPracticeWebApp.Service.DataTransferObject;
using YCRCPracticeWebApp.Service.Mapping;


namespace YCRCPracticeWebApp.ServiceTest
{
    [TestClass]
    [DeploymentItem(@"TestData\Order_TestData.csv")]
    public class OrderServiceTest
    {

        private IGeneralRepository<Orders> OrdeRepository { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            OrdeRepository = Substitute.For<IGeneralRepository<Orders>>();

        }

        /// <summary>
        /// Gets the system under test.
        /// </summary>
        /// <returns>IOrderService.</returns>
        private IOrderService GetSystemUnderTest()
        {
            var sut = new OrderService(OrdeRepository);
            return sut;
        }


        [TestCategory("OrderService")]
        [TestProperty("OrderService", "GetPageOrders")]
        [TestMethod]
        public void GetPageOrders_輸入pageNumber為0及pageSize為20_應ArgumentOutOfRangeException()
        {
            //arrange
            var pageNumber = 0;
            var pageSize = 20;
            var sut = this.GetSystemUnderTest();

            //act
            Action action = () => sut.GetPageOrders(pageNumber, pageSize);

            //assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }


        [TestCategory("OrderService")]
        [TestProperty("OrderService", "GetPageOrders")]
        [TestMethod]
        public void GetPageOrders_輸入pageNumber為1及pageSize為0_應ArgumentOutOfRangeException()
        {
            //arrange
            int pageNumber = 1;
            int pageSize = 0;
            var sut = this.GetSystemUnderTest();

            //act
            Action action = () => sut.GetPageOrders(pageNumber, pageSize);

            //assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestCategory("OrderService")]
        [TestProperty("OrderService", "GetPageOrders")]
        [TestMethod]
        public void GetPageOrders_輸入pageNumber為1及pageSize為20_應ArgumentOutOfRangeException()
        {
            //arrange
            int pageNumber = 1;
            int pageSize = 0;
            var sut = this.GetSystemUnderTest();

            //act
            Action action = () => sut.GetPageOrders(pageNumber, pageSize);

            //assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestCategory("OrderService")]
        [TestProperty("OrderService", "GetPageOrders")]
        [TestMethod]
        public void GetPageOrders_輸入pageNumber為1及pageSize為20_應取得20筆資料()
        {

            //arrange
            int expected = 20;
            int pageNumber = 1;
            int pageSize = 20;

            Fixture fixture = new Fixture();
            var source = fixture.Build<Orders>()
                                .OmitAutoProperties()
                                .CreateMany(30)
                                .AsQueryable();
            this.OrdeRepository.GetAll()
                               .ReturnsForAnyArgs(source);
            var sut = this.GetSystemUnderTest();

            //act
            var actual = sut.GetPageOrders(pageNumber, pageSize);

            //assert
            actual.Should().HaveCount(expected);
        }

        [TestCategory("OrderService")]
        [TestProperty("OrderService", "GetOrder")]
        [TestMethod]
        public void GetOrder_輸入orderId為負一_應ThrowArgumentOutOfRangeException()
        {

            //arrange         
            int orderId = -1;

            var sut = this.GetSystemUnderTest();

            //act
            Action action = () => sut.GetOrder(orderId);

            //assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }


        [TestCategory("OrderService")]
        [TestProperty("OrderService", "GetOrder")]
        [TestMethod]
        public void GetOrder_輸入orderId_應取得該筆訂單資料()
        {

            //arrange         

            var sut = this.GetSystemUnderTest();
            Fixture fixture = new Fixture();
            var source = fixture.Build<Orders>()
                                .OmitAutoProperties()
                                .Create();
            var expected = new OrderDto
            {
                CustomerID = source.CustomerID,
                EmployeeID = source.EmployeeID,
                Freight = source.Freight,
                OrderID = source.OrderID,
                OrderDate = source.OrderDate,
                RequiredDate = source.RequiredDate,
                ShipAddress = source.ShipAddress,
                ShipCity = source.ShipCity,
                ShipCountry = source.ShipCountry,
                ShippedDate = source.ShippedDate,
                ShipName = source.ShipName,
                ShipPostalCode = source.ShipPostalCode,
                ShipRegion = source.ShipRegion,
                ShipVia = source.ShipVia,
            };

            OrdeRepository.Find(null)
                          .ReturnsForAnyArgs(source);
            //act
            var actual = sut.GetOrder(source.OrderID);

            //assert

            actual.Should().BeEquivalentTo(expected);
        }

        [TestCategory("OrderService")]
        [TestProperty("OrderService", "CreateOrder")]
        [TestMethod]
        public void CreateOrder_輸入OrderDto為空_應ThrowArgumentNullException()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();
            OrderDto dto = null;

            //act
            Action action = () => sut.CreateOrder(dto);

            //assert
            action.Should().Throw<ArgumentNullException>();
        }




        [TestCategory("OrderService")]
        [TestProperty("OrderService", "CreateOrder")]
        [TestMethod]
        public void CreateOrder_新增訂單()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();

            Fixture fixture = new Fixture();
            var dto = fixture.Build<OrderDto>()
                             .Create();

            //act
            Action action = () => sut.CreateOrder(dto);

            //assert
            action.Should().NotThrow<Exception>();
        }


        [TestCategory("OrderService")]
        [TestProperty("OrderService", "EditOrder")]
        [TestMethod]
        public void EditOrder_輸入OrderDto為空_應ThrowArgumentNullException()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();

            Fixture fixture = new Fixture();
            var dto = fixture.Build<OrderDto>()
                             .Create();

            //act
            Action action = () => sut.EditOrder(dto);

            //assert
            action.Should().NotThrow<Exception>();
        }

        [TestCategory("OrderService")]
        [TestProperty("OrderService", "EditOrder")]
        [TestMethod]
        public void EditOrder_修改訂單()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();

            Fixture fixture = new Fixture();
            var dto = fixture.Build<OrderDto>()
                             .Create();

            //act
            Action action = () => sut.EditOrder(dto);

            //assert
            action.Should().NotThrow<Exception>();
        }


        [TestCategory("OrderService")]
        [TestProperty("OrderService", "DeleteOrder")]
        [TestMethod]
        public void DeleteOrder_orderId為小於零數值_應ThrowArgumentOutOfRangeException()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();
            Fixture fixture = new Fixture();
            fixture.Customizations.Add(new RandomNumericSequenceGenerator(int.MinValue, 0));
            int orderId = fixture.Create<int>();
            //act
            Action action = () => sut.DeleteOrder(orderId);

            //assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestCategory("OrderService")]
        [TestProperty("OrderService", "DeleteOrder")]
        [TestMethod]
        public void DeleteOrder_刪除訂單()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();

            Fixture fixture = new Fixture();
            fixture.Customizations.Add(new RandomNumericSequenceGenerator(0, int.MaxValue));
            int orderId = fixture.Create<int>();

            //act
            Action action = () => sut.DeleteOrder(orderId);

            //assert
            action.Should().NotThrow<Exception>();
        }
    }
}
