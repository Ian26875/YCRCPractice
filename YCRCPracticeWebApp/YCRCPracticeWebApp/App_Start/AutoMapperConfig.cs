using AutoMapper;
using YCRCPracticeWebApp.Mappings;
using YCRCPracticeWebApp.Service.Mapping;

namespace YCRCPracticeWebApp
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