using AutoMapper;
using LinXi_Model.DTO.IntercourseManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.IntercourseManagement.Profiles
{
    public class PurchasingNoPayProfile : Profile
    {
        public PurchasingNoPayProfile()
        {
            CreateMap<PuOrder, PurchasingNoPayDtos>();
        }
    }
}