using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YCRCPracticeWebApp.Repository;
using YCRCPracticeWebApp.Repository.Interface;
using NSubstitute;
using FluentAssertions;

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
            this.ProductRepository=Substitute.For<IGeneralRepository<Products>>();
        }

        

    }
}
