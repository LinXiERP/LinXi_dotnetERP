using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.ProductionManagement.Dtos
{
    public class PrProductMaterialDtos
    {
        public int Id { get; set; }
        public int? TaskId { get; set; }
        public int? CommodityId { get; set; }
        public int? Nums { get; set; }
        public string Uses { get; set; }
        public int? DepartmentId { get; set; }
        public int? StaffId { get; set; }
        public decimal? ReceiptDate { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public int? Status { get; set; }
        public string Remark { get; set; }
        public string DepartmentName { get; set; }
        public string StaffName { get; set; }
        public string CommodityName { get; set; }
        public string OperatorName { get; set; }
    }
}
