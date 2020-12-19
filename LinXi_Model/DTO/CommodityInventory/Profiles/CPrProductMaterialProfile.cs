using AutoMapper;
using LinXi_Model.DTO.CommodityInventory.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.CommodityInventory.Profiles
{
   public class CPrProductMaterialProfile : Profile
    {
        public CPrProductMaterialProfile() {
            CreateMap<PrProductMaterial, CPrProductMaterialDtos>()
                    .ForMember(destinationMember: dest => dest.CommodityName,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => $"{ src.Commodity.Name}"))
                    .ForMember(destinationMember: dest => dest.StaffName,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Staff.Name}"))
                    .ForMember(destinationMember: dest => dest.DepatmentName,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Department.Name}"))
                     .ForMember(destinationMember: dest => dest.CommodityPlace,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => $"{ src.Commodity.Place}"))
                      .ForMember(destinationMember: dest => dest.CommodityPrice,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => $"{ src.Commodity.Price}"))
                       .ForMember(destinationMember: dest => dest.CommoditySpec,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => $"{ src.Commodity.Spec}"))
                        .ForMember(destinationMember: dest => dest.CommodityStock,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => $"{ src.Commodity.Stock}"))
                         .ForMember(destinationMember: dest => dest.SupplierName,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => $"{ src.Commodity.Supplier.Name}"));
            CreateMap<CPrProductMaterialDtos, PrProductMaterial>();



        }
    }
}
