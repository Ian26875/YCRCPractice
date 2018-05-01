using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YCRCPracticeWebApp.Repository;
using YCRCPracticeWebApp.Service.DataTransferObject;

namespace YCRCPracticeWebApp.Service.Mapping
{
    /// <summary>
    /// Class ServiceProfile.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ServiceProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceProfile"/> class.
        /// </summary>
        public ServiceProfile()
        {
            DbModelToDto();
            DtoToDbModel();
        }

        /// <summary>
        /// Databases the model to dto.
        /// </summary>
        private void DbModelToDto()
        {
            CreateMap<Orders,OrderDto>();
        }


        /// <summary>
        /// Dtoes to database model.
        /// </summary>
        private void DtoToDbModel()
        {
            CreateMap<OrderDto, Orders>();
        }
    }
}
