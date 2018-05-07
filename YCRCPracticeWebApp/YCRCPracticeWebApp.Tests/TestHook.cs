using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using YCRCPracticeWebApp.Mappings;

namespace YCRCPracticeWebApp.Tests
{
    [TestClass]
    public class TestHook
    {

        /// <summary>
        /// Assemblies the initialize.
        /// </summary>
        /// <param name="context">The context.</param>
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            //Resets the mapper configuration. Not intended for production use, but for testing scenarios.
            Mapper.Reset();

            Mapper.Initialize(config =>
            {
                config.AddProfile<WebProfile>();
            });
        }

        /// <summary>
        /// Assemblies the cleanup.
        /// </summary>
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {

        }
    }
}
