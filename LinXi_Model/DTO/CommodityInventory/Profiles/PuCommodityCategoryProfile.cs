using AutoMapper;
using LinXi_Model.DTO.CommodityInventory.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.CommodityInventory.Profiles
{
    class PuCommodityCategoryProfile:Profile
    {
        public PuCommodityCategoryProfile() 
        {

            CreateMap<PuCommodityCategory, PuCommodityCategoryDtos>();
            CreateMap<PuCommodityCategoryDtos, PuCommodityCategory>();

        }

    }
}
