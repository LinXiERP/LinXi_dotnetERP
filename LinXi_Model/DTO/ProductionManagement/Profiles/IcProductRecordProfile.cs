using AutoMapper;
using LinXi_Model.DTO.ProductionManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.ProductionManagement.Profiles
{
    public class IcProductRecordProfile : Profile
    {
        public IcProductRecordProfile()
        {
            CreateMap<IcProductRecord, IcProductRecordDtos>();
            CreateMap<IcProductRecordDtos, IcProductRecord>();
        }
    }
}
