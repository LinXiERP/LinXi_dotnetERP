using AutoMapper;
using LinXi_Model.DTO.CommodityInventory.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.CommodityInventory.Profiles
{
    public class PuOrderProfile : Profile
    {
        public PuOrderProfile()
        {
            CreateMap<PuOrder, PuOrderDtos>()
                .ForMember(dto => dto.Name, source => source.MapFrom(u => u.Commodity.Name))
                .ForMember(dto => dto.OperatorName, source => source.MapFrom(u => u.Handle.Name))
                .ForMember(dto => dto.CommodityType, source => source.MapFrom(u => u.Commodity.Category.Name))
                .ForMember(dto => dto.Price, source => source.MapFrom(u => u.Commodity.Price))
                           .ForMember(dto => dto.CategoryName, source => source.MapFrom(u => u.Commodity.Category.Name))
                .ForMember(dto => dto.SupplierName, source => source.MapFrom(u => u.Commodity.Supplier.Name));
            CreateMap<PuOrderDtos, PuOrder>();
        }
    }
}