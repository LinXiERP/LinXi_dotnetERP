using AutoMapper;
using LinXi_Model.DTO.ProductInventory.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.ProductInventory.Profiles
{
   public class PrProductStockDtosStockProfile: Profile
    {
        public PrProductStockDtosStockProfile()
        {
            CreateMap<PrProduct, PrProductStockDtos>();
            CreateMap<PrProductStockDtos, PrProduct>();
        }
    }
}
