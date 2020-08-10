using AutoMapper;
using LinXi_Model.DTO.CustomerManageManage.Dtos;

namespace LinXi_Model.DTO.CustomerManageManage.Profiles
{
    public class PrProductProfile : Profile
    {
        public PrProductProfile()
        {
            CreateMap<PrProduct, PrProductDtos>();
        }
    }
}
