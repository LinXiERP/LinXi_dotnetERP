using AutoMapper;
using LinXi_Model.DTO.SaleManagement.Dtos;

namespace LinXi_Model.DTO.SaleManagement.Profiles
{
    public class SlOrderTwoProfile : Profile
    {
        public SlOrderTwoProfile()
        {
            CreateMap<SlOrder, SlOrderTwoDtos>()
               .ForMember(destinationMember: dest => dest.CustomerName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Customer.Name}"))
                .ForMember(destinationMember: dest => dest.HandleName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Handle.Name}"))
                .ForMember(destinationMember: dest => dest.OperatorName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Operator.Name}"))
                .ForMember(destinationMember: dest => dest.ProductName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.Name}"));
            CreateMap<SlOrderTwoDtos, SlOrder>();
        }
    }
}