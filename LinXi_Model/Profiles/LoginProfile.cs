using AutoMapper;
using LinXi_Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.Profiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<AcUserinfo, LoginDTO>()
                .ForMember(dto => dto.Name, option => option.MapFrom(m => m.Account))
                .ForMember(dto => dto.Password, option => option.MapFrom(m => m.Pwd));

            CreateMap<LoginDTO, AcUserinfo>()
                .ForMember(m => m.Account, option => option.MapFrom(dto => dto.Name))
                .ForMember(m => m.Pwd, option => option.MapFrom(dto => dto.Password));
        }
    }
}