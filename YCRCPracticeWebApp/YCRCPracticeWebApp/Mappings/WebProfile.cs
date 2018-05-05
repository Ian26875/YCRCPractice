using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YCRCPracticeWebApp.Models.ViewModels;
using YCRCPracticeWebApp.Service.DataTransferObject;

namespace YCRCPracticeWebApp.Mappings
{
    /// <summary>
    /// Class WebProfile.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class WebProfile:Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebProfile"/> class.
        /// </summary>
        public WebProfile()
        {
            ViewModelToDto();
            DtoToViewModel();
        }

        /// <summary>
        /// Views the model to dto.
        /// </summary>
        private void ViewModelToDto()
        {
            CreateMap<OrderViewModel, OrderDto>();
            CreateMap<OrderCreateViewModel, OrderDto>();
            CreateMap<OrderEditViewModel, OrderDto>();
        }

        /// <summary>
        /// Dtoes to view model.
        /// </summary>
        private void DtoToViewModel()
        {
            CreateMap<OrderDto, OrderViewModel>();
            CreateMap<OrderDto, OrderCreateViewModel>();
            CreateMap<OrderDto, OrderEditViewModel>();
        }
    }
}