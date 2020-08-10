using AutoMapper;
using LinXi_Model.DTO.ProductionManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.ProductionManagement.Profiles
{
    public class PrProductMaterialProfile : Profile
    {
        public PrProductMaterialProfile()
        {
            CreateMap<PrProductMaterial, PrProductMaterialDtos>();
            CreateMap<PrProductMaterialDtos, PrProductMaterial>();
        }
    }
}
