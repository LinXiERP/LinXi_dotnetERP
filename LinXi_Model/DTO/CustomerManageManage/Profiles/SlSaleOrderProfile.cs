using AutoMapper;
using LinXi_Model.DTO.CustomerManageManage.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.CustomerManageManage.Profiles
{
    public class SlSaleOrderProfile:Profile
    {
        public SlSaleOrderProfile()
        {
            CreateMap<SlSaleOrderDtos, SlSaleOrder>();
            CreateMap<SlSaleOrder, SlSaleOrderDtos>();
        }
    }
}
