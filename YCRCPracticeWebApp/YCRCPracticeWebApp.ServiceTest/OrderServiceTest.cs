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

            //Resets the mapper configuration. Not intended for production use, but for testing scenarios.
            Mapper.Reset();

            Mapper.Initialize(config =>
            {
                config.AddProfile<ServiceProfile>();
            });
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
            var actual=sut.GetPageOrders(pageNumber, pageSize);

            //assert
            actual.Should().HaveCount(expected);
        }
    }
}
