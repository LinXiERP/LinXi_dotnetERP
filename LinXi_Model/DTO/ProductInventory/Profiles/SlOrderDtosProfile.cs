using AutoMapper;
using LinXi_Model.DTO.ProductInventory.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.ProductInventory.Profiles
{
    public class SlOrderDtosProfile:Profile
    {
        public SlOrderDtosProfile()
        {
            CreateMap<SlOrder, SlOrderDtos>();
            CreateMap<SlOrderDtos, SlOrder>();
        }
    }
}
