using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.ProductInventory.Dtos
{
    public class ProcductTaskDtos
    {
        public int Id { get; set; }
        public string No { get; set; }
        public int? ProductId { get; set; }
        public decimal? Nums { get; set; }
        public DateTime? ProductDate { get; set; }
        public string Batch { get; set; }
        public int? DepartmentId { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public int? Status { get; set; }
        public string Remark { get; set; }
        public int? QmId { get; set; }
        public string Spec { get; set; }
        public string Category { get; set; }
        public string Unit { get; set; }
        public decimal Stock { get; set; }
        public string LicenseNo { get; set; }
        public string BarCode { get; set; }
        public string Name { get; set; }
        public string StatusName { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
        public string OperationName { get; set; }
    }
}
