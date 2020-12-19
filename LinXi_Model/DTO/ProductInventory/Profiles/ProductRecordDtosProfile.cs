using AutoMapper;
using LinXi_Model.DTO.ProductInventory.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.ProductInventory.Profiles
{
    public class ProductRecordDtosProfile : Profile
    {
        public ProductRecordDtosProfile()
        {
            CreateMap<IcProductRecord, ProductRecordDtos>();
            CreateMap<ProductRecordDtos, IcProductRecord>();
        }
    }
}
