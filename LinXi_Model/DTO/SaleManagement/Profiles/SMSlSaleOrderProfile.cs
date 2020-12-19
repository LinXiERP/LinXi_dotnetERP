using AutoMapper;
using LinXi_Model.DTO.SaleManagement.Dtos;

namespace LinXi_Model.DTO.SaleManagement.Profiles
{
    public class SMSlSaleOrderProfile : Profile
    {
        public SMSlSaleOrderProfile()
        {
            CreateMap<SlSaleOrder, SMSlSaleOrderDtos>()
               .ForMember(destinationMember: dest => dest.CustomerId,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Customer.Id}"))
                .ForMember(destinationMember: dest => dest.ProductId,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.Id}"));
            CreateMap<SMSlSaleOrderDtos, SlSaleOrder>();
        }
    }
}