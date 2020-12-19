using AutoMapper;
using LinXi_Model.DTO.SaleManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.SaleManagement.Profiles
{
    public class TJSlOrderProfile : Profile
    {
        public TJSlOrderProfile()
        {
            CreateMap<SlOrder, TJSlOrderDtos>()
                .ForMember(dto => dto.Name, source => source.MapFrom(u => u.Product.Name))
                .ForMember(dto => dto.OperatorName, source => source.MapFrom(u => u.Handle.Name))
                .ForMember(dto => dto.CommodityType, source => source.MapFrom(u => u.Product.Category.Name))
                .ForMember(dto => dto.Price, source => source.MapFrom(u => u.Product.Price))
                .ForMember(dto => dto.CategoryName, source => source.MapFrom(u => u.Product.Category.Name));
            CreateMap<TJSlOrderDtos, SlOrder>();
        }
    }
}