using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YCRCPracticeWebApp.Models.ViewModels;
using YCRCPracticeWebApp.Service.DataTransferObject;

namespace YCRCPracticeWebApp.Mappings
{
    public class WebProfile:Profile
    {
        public WebProfile()
        {
            ViewModelToDto();
            DtoToViewModel();
        }

        private void ViewModelToDto()
        {
            CreateMap<OrderViewModel, OrderDto>();
        }

        private void DtoToViewModel()
        {
            CreateMap<OrderDto, OrderViewModel>();
        }
    }
}