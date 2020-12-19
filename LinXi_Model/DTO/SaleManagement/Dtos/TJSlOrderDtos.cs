using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.SaleManagement.Dtos
{
    public class TJSlOrderDtos
    {
        public int Id { get; set; }
        public string No { get; set; }
        public string CommodityType { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public decimal Nums { get; set; }
        public decimal? Price { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryWay { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? OrderAmount { get; set; }
        public int? HandleId { get; set; }
        //public int? OperatorId { get; set; }
        public string OperatorName { get; set; }
        //public DateTime? OperatorTime { get; set; }
        public int? Status { get; set; }
        public string Remark { get; set; }
        public string SupplierName { get; set; }

        //public virtual SlCustomer Customer { get; set; }
        //public virtual AcStaff Handle { get; set; }
        //public virtual AcStaff Operator { get; set; }
        //public virtual PrProduct Product { get; set; }
        //public virtual ICollection<SlReject> SlReject { get; set; }
        //public virtual ICollection<SlSaleOrder> SlSaleOrder { get; set; }
    }
}
