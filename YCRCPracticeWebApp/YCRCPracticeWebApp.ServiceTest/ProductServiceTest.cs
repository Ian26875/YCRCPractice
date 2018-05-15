using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YCRCPracticeWebApp.Repository;
using YCRCPracticeWebApp.Repository.Interface;
using NSubstitute;
using FluentAssertions;
using YCRCPracticeWebApp.Service;
using YCRCPracticeWebApp.Service.Interface;
using AutoFixture;
using System.Linq;
using YCRCPracticeWebApp.Service.DataTransferObject;

namespace YCRCPracticeWebApp.ServiceTest
{
    [TestClass]
    public class ProductServiceTest
    {
        private IGeneralRepository<Products> ProductRepository { get; set; }

        /// <summary>
        /// Tests the initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            this.ProductRepository = Substitute.For<IGeneralRepository<Products>>();
        }

        /// <summary>
        /// Gets the system under test.
        /// </summary>
        /// <returns>IProductService.</returns>
        private IProductService GetSystemUnderTest()
        {
            var sut = new ProductService(this.ProductRepository);
            return sut;
        }

        [TestCategory("ProductService")]
        [TestProperty("ProductService", "GetPageProducts")]
        [TestMethod]
        public void GetPageProducts_輸入pageNumber為0及pageSize為20_應ArgumentOutOfRangeException()
        {
            //arrange
            var pageNumber = 0;
            var pageSize = 20;
            var sut = this.GetSystemUnderTest();

            //act
            Action action = () => sut.GetPageProducts(pageNumber, pageSize);

            //assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }


        [TestCategory("Productservice")]
        [TestProperty("Productservice", "GetPageProducts")]
        [TestMethod]
        public void GetPageProducts_輸入pageNumber為1及pageSize為0_應ArgumentOutOfRangeException()
        {
            //arrange
            int pageNumber = 1;
            int pageSize = 0;
            var sut = this.GetSystemUnderTest();

            //act
            Action action = () => sut.GetPageProducts(pageNumber, pageSize);

            //assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestCategory("Productservice")]
        [TestProperty("Productservice", "GetPageProducts")]
        [TestMethod]
        public void GetPageProducts_輸入pageNumber為1及pageSize為20_應ArgumentOutOfRangeException()
        {
            //arrange
            int pageNumber = 1;
            int pageSize = 0;
            var sut = this.GetSystemUnderTest();

            //act
            Action action = () => sut.GetPageProducts(pageNumber, pageSize);

            //assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestCategory("Productservice")]
        [TestProperty("Productservice", "GetPageProducts")]
        [TestMethod]
        public void GetPageProducts_輸入pageNumber為1及pageSize為20_應取得20筆資料()
        {

            //arrange
            int expected = 20;
            int pageNumber = 1;
            int pageSize = 20;

            Fixture fixture = new Fixture();
            var source = fixture.Build<Products>()
                                .OmitAutoProperties()
                                .CreateMany(30)
                                .AsQueryable();
            this.ProductRepository.GetAll()
                               .ReturnsForAnyArgs(source);
            var sut = this.GetSystemUnderTest();

            //act
            var actual = sut.GetPageProducts(pageNumber, pageSize);

            //assert
            actual.Should().HaveCount(expected);
        }

        [TestCategory("Productservice")]
        [TestProperty("Productservice", "GetProduct")]
        [TestMethod]
        public void GetProduct_輸入ProductId為負一_應ThrowArgumentOutOfRangeException()
        {

            //arrange         
            int ProductId = -1;

            var sut = this.GetSystemUnderTest();

            //act
            Action action = () => sut.GetProduct(ProductId);

            //assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }


        [TestCategory("Productservice")]
        [TestProperty("Productservice", "GetProduct")]
        [TestMethod]
        public void GetProduct_輸入ProductId_應取得該筆訂單資料()
        {

            //arrange         

            var sut = this.GetSystemUnderTest();
            Fixture fixture = new Fixture();
            var source = fixture.Build<Products>()
                                .OmitAutoProperties()
                                .Create();
            var expected = new ProductDto
            {
                ProductID = source.ProductID,
                ProductName = source.ProductName,
                CategoryID = source.CategoryID,
                Discontinued = source.Discontinued,
                QuantityPerUnit = source.QuantityPerUnit,
                ReorderLevel = source.ReorderLevel,
                SupplierID = source.SupplierID,
                UnitPrice = source.UnitPrice,
                UnitsInStock = source.UnitsInStock,
                UnitsOnOrder = source.UnitsOnOrder,
               
            };

            ProductRepository.Find(null)
                          .ReturnsForAnyArgs(source);
            //act
            var actual = sut.GetProduct(source.ProductID);

            //assert

            actual.Should().BeEquivalentTo(expected);
        }

        [TestCategory("Productservice")]
        [TestProperty("Productservice", "CreateProduct")]
        [TestMethod]
        public void CreateProduct_輸入ProductDto為空_應ThrowArgumentNullException()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();
            ProductDto dto = null;

            //act
            Action action = () => sut.CreateProduct(dto);

            //assert
            action.Should().Throw<ArgumentNullException>();
        }




        [TestCategory("Productservice")]
        [TestProperty("Productservice", "CreateProduct")]
        [TestMethod]
        public void CreateProduct_新增訂單()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();

            Fixture fixture = new Fixture();
            var dto = fixture.Build<ProductDto>()
                             .Create();

            //act
            Action action = () => sut.CreateProduct(dto);

            //assert
            action.Should().NotThrow<Exception>();
        }


        [TestCategory("Productservice")]
        [TestProperty("Productservice", "EditProduct")]
        [TestMethod]
        public void EditProduct_輸入ProductDto為空_應ThrowArgumentNullException()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();

            Fixture fixture = new Fixture();
            var dto = fixture.Build<ProductDto>()
                             .Create();

            //act
            Action action = () => sut.EditProduct(dto);

            //assert
            action.Should().NotThrow<Exception>();
        }

        [TestCategory("Productservice")]
        [TestProperty("Productservice", "EditProduct")]
        [TestMethod]
        public void EditProduct_修改訂單()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();

            Fixture fixture = new Fixture();
            var dto = fixture.Build<ProductDto>()
                             .Create();

            //act
            Action action = () => sut.EditProduct(dto);

            //assert
            action.Should().NotThrow<Exception>();
        }


        [TestCategory("Productservice")]
        [TestProperty("Productservice", "DeleteProduct")]
        [TestMethod]
        public void DeleteProduct_ProductId為小於零數值_應ThrowArgumentOutOfRangeException()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();
            Fixture fixture = new Fixture();
            fixture.Customizations.Add(new RandomNumericSequenceGenerator(int.MinValue, 0));
            int ProductId = fixture.Create<int>();
            //act
            Action action = () => sut.DeleteProduct(ProductId);

            //assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestCategory("Productservice")]
        [TestProperty("Productservice", "DeleteProduct")]
        [TestMethod]
        public void DeleteProduct_刪除訂單()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();

            Fixture fixture = new Fixture();
            fixture.Customizations.Add(new RandomNumericSequenceGenerator(0, int.MaxValue));
            int ProductId = fixture.Create<int>();

            //act
            Action action = () => sut.DeleteProduct(ProductId);

            //assert
            action.Should().NotThrow<Exception>();
        }
    }
}
