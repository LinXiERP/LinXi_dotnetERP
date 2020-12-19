using AutoMapper;
using LinXi_Model.DTO.QualityManagement.Dtos;

namespace LinXi_Model.DTO.QualityManagement.Profiles
{
    public class QmProductProfile : Profile
    {
        public QmProductProfile()
        {
            CreateMap<QmProduct, QmProductDtos>()
               .ForMember(destinationMember: dest => dest.HandleName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Handle.Name}"))
               .ForMember(destinationMember: dest => dest.OperatorName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Operator.Name}"));
            CreateMap<QmProductDtos, QmProduct>();
            // .ForMember(destinationMember: dest => dest.HandleId,
            // memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.HandleId}"))
            //.ForMember(destinationMember: dest => dest.OperatorId,
            // memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.OperatorId}")); ;
        }
    }
}