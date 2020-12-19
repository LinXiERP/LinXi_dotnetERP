using AutoMapper;
using LinXi_Model.DTO.ProductInventory.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.ProductInventory.Profiles
{
    public class ProductRecordProfile: Profile
    {
        public ProductRecordProfile()
        {
            CreateMap<IcProductRecord, ProductRecordDtos>()
           .ForMember(destinationMember: dest => dest.StaffName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Staff.Name}"))
           .ForMember(destinationMember: dest => dest.DepartentName, 
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Department.Name}"))
           .ForMember(destinationMember: dest => dest.OperatorName, 
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Staff.Name}"))
            .ForMember(destinationMember: dest => dest.ProductName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.Name}"));
        }
    }
}
