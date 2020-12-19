using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.QualityManagement.Dtos
{
    public class QmProductDtos
    {
        public int Id { get; set; }
        public string No { get; set; }
        public int? TaskId { get; set; }
        public DateTime? QmDate { get; set; }
        public string Result { get; set; }
        //public int? HandleId { get; set; }
        //public int? OperatorId { get; set; }
        public string HandleName { get; set; }
        public string OperatorName { get; set; }
        public DateTime? OperateTime { get; set; }
        public string Pic { get; set; }
        public string Remark { get; set; }
    }
}
