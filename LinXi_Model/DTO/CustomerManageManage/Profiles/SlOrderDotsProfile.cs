using AutoMapper;
using LinXi_Model.DTO.CustomerManageManage.Dtos;

namespace LinXi_Model.DTO.CustomerManageManage.Profiles
{
    public class SlOrderDotsProfile : Profile
    {
        public SlOrderDotsProfile()
        {
<<<<<<< HEAD
            CreateMap<SlOrder, SlOrderTDtos>()
=======
            CreateMap<SlOrder, SlOrderDtos>()
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557
                .ForMember(destinationMember: dest => dest.CustomerName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Customer.Name}"))//字段替换
                .ForMember(destinationMember: dest => dest.HandleName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Handle.Name}"))
                .ForMember(destinationMember: dest => dest.OperatorName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Operator.Name}"))
                .ForMember(destinationMember: dest => dest.ProductName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.Name}"));

<<<<<<< HEAD
            CreateMap<SlOrderTDtos, SlOrder>();
=======
            CreateMap<SlOrderDtos, SlOrder>();
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557
            CreateMap<SlOrderAddDtos, SlOrder>();

        }
    }
}
