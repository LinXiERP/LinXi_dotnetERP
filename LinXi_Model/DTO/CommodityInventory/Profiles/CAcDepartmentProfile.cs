using AutoMapper;
using LinXi_Model.DTO.CommodityInventory.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.CommodityInventory.Profiles
{
   public class CAcDepartmentProfile :Profile
    {
        public CAcDepartmentProfile() 
        {
            CreateMap<AcDepartment, CAcDepartmentDtos>();
            CreateMap<CAcDepartmentDtos, AcDepartment>();


        }
    }
}
