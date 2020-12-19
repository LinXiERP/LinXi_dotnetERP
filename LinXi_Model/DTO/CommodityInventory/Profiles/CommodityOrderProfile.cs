using LinXi_Model.DTO.CommodityInventory.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace LinXi_Model.DTO.CommodityInventory.Profiles
{
   public class CommodityOrderProfile:Profile
    {
        public CommodityOrderProfile()
        {
            CreateMap<PuOrder, CommodityOrderDtos>()
                .ForMember(destinationMember: dest => dest.Commodity_Name,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Commodity.Name}"))
                .ForMember(destinationMember: dest => dest.HandleName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Handle.Name}"))
                .ForMember(destinationMember: dest => dest.Commodity_place,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Commodity.Place}"))
                 .ForMember(destinationMember: dest => dest.Commodity_price,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Commodity.Price}"))
                  .ForMember(destinationMember: dest => dest.Commodity_stock,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Commodity.Stock}"))
               .ForMember(destinationMember: dest => dest.Commodity_spec,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Commodity.Spec}"))
                .ForMember(destinationMember: dest => dest.supplierid,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Commodity.SupplierId}"))
                .ForMember(destinationMember: dest => dest.suppliername,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Commodity.Supplier.Name}"))
                .ForMember(destinationMember: dest => dest.categoryid,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Commodity.CategoryId}"))
                .ForMember(destinationMember: dest => dest.categoryname,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Commodity.Category.Name}"))
      
                ;
            CreateMap<CommodityOrderDtos, PuOrder>();

        }
    }
}
