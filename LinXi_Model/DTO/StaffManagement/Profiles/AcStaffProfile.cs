using AutoMapper;
using LinXi_Model.DTO.StaffManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.StaffManagement.Profiles
{
    public class AcStaffProfile : Profile
    {
        public AcStaffProfile()
        {
            CreateMap<AcStaff, AcStaffDtos>();
            CreateMap<AcStaffDtos, AcStaff>();
        }
    }
}
