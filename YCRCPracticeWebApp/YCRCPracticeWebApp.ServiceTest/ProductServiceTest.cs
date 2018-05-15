using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    [DeploymentItem(@"TestData\Product_TestData.csv")]
    public class ProductServiceTest
    {

        /// <summary>
        /// Gets or sets the product repository.
        /// </summary>
        /// <value>The product repository.</value>
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

        /// <summary>
        /// Gets the test data from CSV.
        /// </summary>
        /// <returns>System.Collections.Generic.IList&lt;YCRCPracticeWebApp.Repository.Products&gt;.</returns>
        private IList<Products> GetTestDataFromCsv()
        {
            IList<Products> source = new List<Products>();
            
            return source;
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
        public void GetProduct_輸入ProductId為小於零_應ThrowArgumentOutOfRangeException()
        {

            //arrange         
            Fixture fixture = new Fixture();
            fixture.Customizations.Add(new RandomNumericSequenceGenerator(int.MinValue, 0));
            int productId = fixture.Create<int>();

            var sut = this.GetSystemUnderTest();

            //act
            Action action = () => sut.GetProduct(productId);

            //assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestCategory("Productservice")]
        [TestProperty("Productservice", "GetProduct")]
        [TestMethod]
        public void GetProduct_輸入ProductId_應取得該筆產品資料()
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
        public void CreateProduct_新增產品()
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
        public void EditProduct_修改產品()
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
            int productId = fixture.Create<int>();
            //act
            Action action = () => sut.DeleteProduct(productId);

            //assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestCategory("Productservice")]
        [TestProperty("Productservice", "DeleteProduct")]
        [TestMethod]
        public void DeleteProduct_輸入產品代號_刪除產品()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();

            Fixture fixture = new Fixture();
            fixture.Customizations.Add(new RandomNumericSequenceGenerator(0, int.MaxValue));
            int productId = fixture.Create<int>();

            //act
            Action action = () => sut.DeleteProduct(productId);

            //assert
            action.Should().NotThrow<Exception>();
        }

        [TestCategory("Productservice")]
        [TestProperty("Productservice", "DeleteProduct")]
        [TestMethod]
        public void DeleteProduct_輸入為Null_應ThrowArgumentNullException()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();
            ProductDto dto = null;
            //act
            Action action = () => sut.DeleteProduct(dto);

            //assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestCategory("Productservice")]
        [TestProperty("Productservice", "DeleteProduct")]
        [TestMethod]
        public void DeleteProduct_輸入產品資料_應刪除產品()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();

            Fixture fixture = new Fixture();
            var dto = fixture.Build<ProductDto>()
                             .Create();

            //act
            Action action = () => sut.DeleteProduct(dto);

            //assert
            action.Should().NotThrow<Exception>();
        }

        [TestCategory("Productservice")]
        [TestProperty("Productservice", "GetAllProducts")]
        [TestMethod]
        public void GetAllProducts_取得所有產品()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();


            Fixture fixture = new Fixture();
            var source = fixture.Build<Products>()
                                .OmitAutoProperties()
                                .CreateMany(30)
                                .AsQueryable();

            this.ProductRepository.GetAll()
                                  .Returns(source);
            //act
            var actual = sut.GetAllProducts();

            //assert
            actual.Should().HaveCount(30);
        }

        [TestCategory("Productservice")]
        [TestProperty("Productservice", "GetProductsByProductName")]
        [TestMethod]
        public void GetProductsByProductName_輸入產品名稱為Null_應ThrowArgumentNullException()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();

            string productName = null;

            //act
            Action action = () => sut.GetProductsByProductName(productName);

            //assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestCategory("Productservice")]
        [TestProperty("Productservice", "GetProductsByProductName")]
        [TestMethod]
        public void GetProductsByProductName_輸入產品名稱為空字串_應ThrowArgumentNullException()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();

            string productName = "";

            //act
            Action action = () => sut.GetProductsByProductName(productName);

            //assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestCategory("Productservice")]
        [TestProperty("Productservice", "GetProductsByProductName")]
        [TestMethod]
        public void GetProductsByProductName_輸入產品名稱為空白字串_應ThrowArgumentNullException()
        {
            //arrange         
            var sut = this.GetSystemUnderTest();

            string productName = "    ";

            //act
            Action action = () => sut.GetProductsByProductName(productName);

            //assert
            action.Should().Throw<ArgumentNullException>();
        }
    }
}
