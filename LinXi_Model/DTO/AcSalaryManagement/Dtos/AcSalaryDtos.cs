using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.AcSalaryManagement.Dtos
{
  public  class AcSalaryDtos
    {
        public int Id { get; set; }
       
        public int StaffId { get; set; }
        public string no { get; set; }
        public string Name { get; set; }
        public string SexName { get; set; }
        public int sex { get; set; }
        public string DepartmentName { get; set; }
        public string tel { get; set; }
        public string Address { get; set; }
        public string RoleName { get; set; }
        public string Createdate { get; set; }
        public int Base { get; set; }
        public int Lunch { get; set; }
        public int Live { get; set; }
        public int Hardwork { get; set; }
        public int Extra { get; set; }
        public int Forfeit { get; set; }
        public int Tax { get; set; }
        public int Sum { get; set; }
        public string Grant { get; set; }
    }
}
