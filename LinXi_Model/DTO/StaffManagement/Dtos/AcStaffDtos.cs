﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.StaffManagement.Dtos
{
    public class AcStaffDtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sex { get; set; }
        public string No { get; set; }
        public string Tel { get; set; }
        public string Adress { get; set; }
        public int Department_id { get; set; }
        public int Status { get; set; }
        public int User_id { get; set; }
        public string Remark { get; set; }
    }
}
