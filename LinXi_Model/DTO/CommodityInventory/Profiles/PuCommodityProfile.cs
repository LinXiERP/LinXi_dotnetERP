using AutoMapper;
using LinXi_Model.DTO.CommodityInventory.Dtos;
using LinXi_Model.DTO.CustomerManageManage.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.CommodityInventory.Profiles
{
    public class PuCommodityProfile : Profile
    {
        public PuCommodityProfile()
        {
            CreateMap<PuCommodity, PuCommodityDtos>()
                .ForMember(destinationMember: dest => dest.Icategory_name,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Category.Name}"))
                .ForMember(destinationMember:dest=>dest.operator_name,
                memberOptions:opt=>opt.MapFrom(mapExpression:src=>$"{src.Operator.Name}"))
                .ForMember(destinationMember: dest => dest.supplie_name,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Supplier.Name}"))
                ;
            CreateMap<PuCommodityDtos, SlCustomer>();

        }
    }
}
