using AutoMapper;
using LinXi_Model.DTO.AcUserInfo.Dtos;
using LinXi_Model.DTO.StaffManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.AcUserInfo.Profiles
{
   public  class AcUserInfoProfile: Profile
    {
        public AcUserInfoProfile() {
        CreateMap<AcUserinfo, AcUserInfoManageDtos>()
                .ForMember(destinationMember: dest => dest.Name,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Staff.Name}"))
                 .ForMember(destinationMember: dest => dest.DepartmentName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Staff.Department.Name}"))
                  .ForMember(destinationMember: dest => dest.Sex,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Staff.Sex}"))
                   .ForMember(destinationMember: dest => dest.RoleName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Role.Name}"));//字段替换
            CreateMap<AcUserInfoManageDtos, AcUserinfo>();
               
        }
    }
}
