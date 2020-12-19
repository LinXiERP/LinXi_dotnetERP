using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.ProductInventory.Dtos
{
   public class PrProductStockDtos
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string BarCode { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? Stock { get; set; }
        public string LicenseNo { get; set; }
        public string Spec { get; set; }
        public string Unit { get; set; }
        public string Place { get; set; }
        public string Manufacturer { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperatorTime { get; set; }
        public string Remark { get; set; }
        public string CategoryName { get; set; }
    }
}
