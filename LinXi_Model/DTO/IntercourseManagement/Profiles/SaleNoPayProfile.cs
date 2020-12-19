using AutoMapper;
using LinXi_Model.DTO.IntercourseManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.IntercourseManagement.Profiles
{
    public class SaleNoPayProfile : Profile
    {
        public SaleNoPayProfile()
        {
            CreateMap<SlSaleOrder, SaleNoPayDtos>()
                .ForMember(dto => dto.CustomerName, source => source.MapFrom(u => u.Customer.Name))
                .ForMember(dto => dto.ProductName, source => source.MapFrom(u => u.Product.Name))
                .ForMember(dto => dto.DeliveryDate, source => source.MapFrom(u => u.Order.DeliveryDate))
                .ForMember(dto => dto.DeliveryWay, source => source.MapFrom(u => u.Order.DeliveryWay))
                .ForMember(dto => dto.Price, source => source.MapFrom(u => u.AmountReceivable));
            CreateMap<SaleNoPayDtos, SlSaleOrder>();
        }
    }
}