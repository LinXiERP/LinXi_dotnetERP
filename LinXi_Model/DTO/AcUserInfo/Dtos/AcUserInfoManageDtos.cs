using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.AcUserInfo.Dtos
{
  public  class AcUserInfoManageDtos
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public int Sex { get; set; }
        public string SexName { get; set; }
        public string Statustr { get; set; }
        public int Status { get; set; }
        public string RoleName { get; set; }
        public string  Pwd { get; set; }
        public int RoleId { get; set; }
        public int StaffId { get; set; }
    }
}
