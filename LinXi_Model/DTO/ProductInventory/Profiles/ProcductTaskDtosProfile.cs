using AutoMapper;
using LinXi_Model.DTO.ProductInventory.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.ProductInventory.Profiles
{
     public class ProcductTaskDtosProfile: Profile
    {
        public ProcductTaskDtosProfile()
        {
            CreateMap<PrProductTask, PrProductStockDtos>();
            CreateMap<PrProductStockDtos, PrProductTask>();
        }
    }
}
