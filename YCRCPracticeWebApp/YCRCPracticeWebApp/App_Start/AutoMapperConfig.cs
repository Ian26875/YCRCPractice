using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YCRCPracticeWebApp.Mappings;
using YCRCPracticeWebApp.Service.Mapping;

namespace YCRCPracticeWebApp.App_Start
{
    /// <summary>
    /// Class AutoMapperConfig.
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Registers the profile.
        /// </summary>
        public static void RegisterProfile()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<WebProfile>();
                config.AddProfile<ServiceProfile>();
            });
        }
    }
}