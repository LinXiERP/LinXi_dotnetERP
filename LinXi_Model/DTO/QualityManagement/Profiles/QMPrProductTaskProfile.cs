using AutoMapper;
using LinXi_Model.DTO.QualityManagement.Dtos;

namespace LinXi_Model.DTO.QualityManagement.Profiles
{
    public class QMPrProductTaskProfile : Profile
    {
        public QMPrProductTaskProfile()
        {
            CreateMap<PrProductTask, QMPrProductTaskDtos>()
               .ForMember(destinationMember: dest => dest.ProductName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Product.Name}"));
            CreateMap<QMPrProductTaskDtos, PrProductTask>();
        }
    }
}