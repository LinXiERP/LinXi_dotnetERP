using AutoMapper;
using LinXi_Model.DTO.AcDeparmentManage.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.AcDeparmentManage.Profiles
{
    public class AcDepartmentProfile : Profile
    {
        public AcDepartmentProfile()
        {
            CreateMap<AcDepartment, AcDeparmentDtos>();
            CreateMap<AcDeparmentDtos, AcDepartment>();
        }
    }
}
