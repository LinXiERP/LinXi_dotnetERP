using System;
using System.Collections.Generic;

namespace LinXi_Model
{
    public partial class AcSalary
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string Createdate { get; set; }
        public int Base { get; set; }
        public int? Lunch { get; set; }
        public int? Live { get; set; }
        public int? Hardwork { get; set; }
        public int? Extra { get; set; }
        public int? Forfeit { get; set; }
        public int? Tax { get; set; }
        public int Sum { get; set; }
        public string Grant { get; set; }

        public virtual AcStaff Staff { get; set; }
    }
}
