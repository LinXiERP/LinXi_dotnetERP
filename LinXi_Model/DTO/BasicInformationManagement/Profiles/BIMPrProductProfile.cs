using AutoMapper;
using LinXi_Model.DTO.BasicInformationManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.BasicInformationManagement.Profiles
{
    public class BIMPrProductProfile : Profile
    {
        public BIMPrProductProfile()
        {
            CreateMap<PrProduct, BIMPrProductDtos>();
            CreateMap<BIMPrProductDtos, PrProduct>();
        }
    }
}
