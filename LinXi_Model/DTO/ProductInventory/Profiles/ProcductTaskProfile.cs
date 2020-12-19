using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.ProductInventory.Dtos
{
    public class ProcductTaskProfile : Profile
    {
        public ProcductTaskProfile()
        {
            CreateMap<PrProductTask, ProcductTaskDtos>()
               .ForMember(destinationMember: dest => dest.Spec,
               memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.Spec}"))
                .ForMember(destinationMember: dest => dest.Category,
               memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.Category.Name}"))
                 .ForMember(destinationMember: dest => dest.Unit,
               memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.Unit}"))
                 .ForMember(destinationMember: dest => dest.Stock,
               memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.Stock}"))
                  .ForMember(destinationMember: dest => dest.LicenseNo,
               memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.LicenseNo}"))
                  .ForMember(destinationMember: dest => dest.BarCode,
               memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.BarCode}"))
                  .ForMember(destinationMember: dest => dest.Name,
               memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.Name}"))
                   .ForMember(destinationMember: dest => dest.Price,
               memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.Price}"))
                   .ForMember(destinationMember: dest => dest.Address,
               memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.Manufacturer}"))
                    .ForMember(destinationMember: dest => dest.OperationName,
               memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Operator.Name}"));
        }
    }
}