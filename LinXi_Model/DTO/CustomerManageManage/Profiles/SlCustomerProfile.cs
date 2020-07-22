using AutoMapper;
using LinXi_Model.DTO.CustomerManageManage.Dtos;

namespace LinXi_Model.DTO.CustomerManageManage.Profiles
{
    public class SlCustomerProfile: Profile
    {
        public SlCustomerProfile()
        {
            CreateMap<SlCustomer,SlCustomerDtos>();
            CreateMap< SlCustomerDtos,SlCustomer>();
        }
    }
}
