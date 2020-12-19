using AutoMapper;
using LinXi_Model.DTO.AcNoticeManage.Dtos;

using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.AcNoticeManage.Profiles
{
  public  class ACNoticeProfile: Profile
    {
        public ACNoticeProfile()
        {
            CreateMap<AcNotice, AcNoticeDtos>();//字段替换

            CreateMap<AcNoticeDtos, AcNotice>();
        }
    }
}
