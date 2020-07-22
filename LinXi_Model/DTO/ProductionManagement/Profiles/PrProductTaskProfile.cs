using AutoMapper;
using LinXi_Model.DTO.ProductionManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.ProductionManagement.Profiles
{
    public class PrProductTaskProfile : Profile
    {
        public PrProductTaskProfile()
        {
            CreateMap<PrProductTask, PrProductTaskDtos>();
            CreateMap<PrProductTaskDtos,PrProductTask>();
        }
    }
}
