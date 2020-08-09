using AutoMapper;
using LinXi_Model.DTO.BasicInformationManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.BasicInformationManagement.Profiles
{
    public class PuCommodityProfile : Profile
    {
        public PuCommodityProfile()
        {
            CreateMap<PuCommodity, PuCommodityDtos>();
            CreateMap<PuCommodityDtos, PuCommodity>();
        }
    }
}
