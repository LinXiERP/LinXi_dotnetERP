using AutoMapper;
using LinXi_Model.DTO.RoleMenmusDtos.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.RoleMenmusDtos.Profiles
{
    public class AcUserInfoProfile :Profile
    {
        public AcUserInfoProfile() {
        CreateMap<AcUserinfo, AcUserInfoDtos>();
        CreateMap<AcUserInfoDtos, AcUserinfo>();

        }
    }
}
