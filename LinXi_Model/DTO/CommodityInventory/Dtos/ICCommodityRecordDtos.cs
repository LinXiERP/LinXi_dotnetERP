using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.CommodityInventory.Dtos
{
   public class ICCommodityRecordDtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public sbyte? Isin { get; set; }
        public int? Sourcecategory { get; set; }
        public int? Sourceid { get; set; }
        public string Sourceno { get; set; }
        public int? Commodityid { get; set; }
        public string Batch { get; set; }
        public decimal? Nums { get; set; }
        public string Reason { get; set; }
        public int? Departmentid { get; set; }
        public int? Staffid { get; set; }
        public int? Warehouseid { get; set; }
        public int? Operatorid { get; set; }
        public DateTime? OperateTime { get; set; }
        public int? Status { get; set; }
        public string Remark { get; set; }

        public string StaffName { get; set; }
        public string CommodityName { get; set; }


       
    }
}
