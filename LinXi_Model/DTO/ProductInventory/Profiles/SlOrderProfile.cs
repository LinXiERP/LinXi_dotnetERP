using AutoMapper;
using LinXi_Model.DTO.ProductInventory.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.ProductInventory.Profiles
{
    public class SlOrderProfile:Profile
    {
        public SlOrderProfile()
        {
            CreateMap<SlOrder, SlOrderDtos>()
          .ForMember(destinationMember: dest => dest.ProductName,
               memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.Name}"))
          .ForMember(destinationMember: dest => dest.unit,
               memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.Unit}"))
          .ForMember(destinationMember: dest => dest.stock,
               memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.Stock}"))
          .ForMember(destinationMember: dest => dest.Productprice,
               memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.Price}"))
          .ForMember(destinationMember: dest => dest.spec,
               memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.Spec}"))
          .ForMember(destinationMember: dest => dest.OperatorName,
               memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Operator.Name}"))
          .ForMember(destinationMember: dest => dest.unit,
               memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Handle.Name}"));
        }
    }
}
