using AutoMapper;
using LinXi_Model.DTO.ProductInventory.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LinXi_Model.DTO.ProductInventory.Profiles
{
   public class PrProductStockProfile: Profile
    {
       public PrProductStockProfile()
        {
            CreateMap<PrProduct, PrProductStockDtos>()
                .ForMember(destinationMember: dest => dest.CategoryName,
                memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.Category.Name}"));
        }
    }
}
