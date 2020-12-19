using AutoMapper;
using LinXi_Model.DTO.QualityManagement.Dtos;

namespace LinXi_Model.DTO.QualityManagement.Profiles
{
    public class QMPuOrderProfile : Profile
    {
        public QMPuOrderProfile()
        {
            CreateMap<PuOrder, QMPuOrderDtos>()
               .ForMember(destinationMember: dest => dest.CommodityName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Commodity.Name}"));
            CreateMap<QMPuOrderDtos, PuOrder>();
        }
    }
}