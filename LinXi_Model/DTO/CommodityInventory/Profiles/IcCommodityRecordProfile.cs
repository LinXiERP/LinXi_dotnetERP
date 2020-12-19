using AutoMapper;
using LinXi_Model.DTO.CommodityInventory.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.CommodityInventory.Profiles
{
    class IcCommodityRecordProfile:Profile
    {
        public IcCommodityRecordProfile() 
        {
            CreateMap<IcCommodityRecord, ICCommodityRecordDtos>()
                .ForMember(destinationMember:dest=>dest.CommodityName,
                memberOptions:opt=>opt.MapFrom(mapExpression :src=> $"{src.Commodity.Name}"))
                .ForMember(destinationMember:dest=>dest.StaffName,
                memberOptions:opt=>opt.MapFrom(mapExpression :src=>$"{src.Staff.Name}"))
                ;
            CreateMap<ICCommodityRecordDtos, IcCommodityRecord>();
        }
    }
}
