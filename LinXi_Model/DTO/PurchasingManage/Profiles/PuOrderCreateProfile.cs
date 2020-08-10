using AutoMapper;
using LinXi_Model.DTO.PurchasingManage.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.PurchasingManage.Profiles
{
    public class PuOrderCreateProfile : Profile
    {
        public PuOrderCreateProfile()
        {
            CreateMap<PuCommodity, PuOrderCreateDtos>()
                .ForMember(dto => dto.Name, source => source.MapFrom(u => u.Name))
                .ForMember(dto => dto.Place, source => source.MapFrom(u => u.Place))
                .ForMember(dto => dto.OperatorName, source => source.MapFrom(u => u.Operator.Name))
                .ForMember(dto => dto.CommodityType, source => source.MapFrom(u => u.Category.Name))
                .ForMember(dto => dto.Price, source => source.MapFrom(u => u.Price))
                .ForMember(dto => dto.SupplierName, source => source.MapFrom(u => u.Supplier.Name));
            CreateMap<PuOrderCreateDtos, PuOrder>();
        }
    }
}