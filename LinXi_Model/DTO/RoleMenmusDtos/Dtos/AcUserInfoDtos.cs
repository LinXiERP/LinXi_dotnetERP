using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.RoleMenmusDtos.Dtos
{
   public class AcUserInfoDtos
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Pwd { get; set; }
        public int? RoleId { get; set; }
        public int? StaffId { get; set; }

    }
}
