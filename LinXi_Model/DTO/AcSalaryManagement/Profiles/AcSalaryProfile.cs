using AutoMapper;
using LinXi_Model.DTO.AcSalaryManagement.Dtos;
using LinXi_Model.DTO.StaffManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.AcSalaryManagement.Profiles
{
    public class AcSalaryProfile : Profile
    {
        public AcSalaryProfile()
        {
            CreateMap<AcSalary, AcSalaryDtos>()
                 .ForMember(destinationMember: dest => dest.Name,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Staff.Name}"))
                  .ForMember(destinationMember: dest => dest.sex,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Staff.Sex}"))
                    .ForMember(destinationMember: dest => dest.DepartmentName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Staff.Department.Name}"))
                      .ForMember(destinationMember: dest => dest.tel,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Staff.Tel}"))
                        .ForMember(destinationMember: dest => dest.Address,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Staff.Address}"))
                         .ForMember(destinationMember: dest => dest.RoleName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Staff.User.Role.Name}"))
                          .ForMember(destinationMember: dest => dest.no,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Staff.No}"));//字段替换;//字段替换

            CreateMap<AcSalaryDtos, AcSalary>();
            CreateMap<AcSalaryDtos, AcStaff>();
        }
    }
}