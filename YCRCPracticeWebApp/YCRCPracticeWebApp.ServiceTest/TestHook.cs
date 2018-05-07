using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YCRCPracticeWebApp.Service.Mapping;

namespace YCRCPracticeWebApp.ServiceTest
{
    /// <summary>
    /// Class TestHook.
    /// </summary>
    [TestClass]
    public class TestHook
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            //Resets the mapper configuration. Not intended for production use, but for testing scenarios.
            Mapper.Reset();

            Mapper.Initialize(config =>
            {
                config.AddProfile<ServiceProfile>();
            });
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
           
        }
    }
}
