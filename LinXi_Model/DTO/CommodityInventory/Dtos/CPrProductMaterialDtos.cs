using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.CommodityInventory.Dtos
{
    public class CPrProductMaterialDtos
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
        public string StaffName { get; set; }
        public string DepatmentName { get; set; }
        public string CommodityName {get;set;}
        public string CommodityPrice { get; set; }
        public string CommodityStock { get; set; }
        public string CommoditySpec { get; set; }
        public string SupplierName { get; set; }
        public string CommodityPlace{ get; set; }







    }
}
