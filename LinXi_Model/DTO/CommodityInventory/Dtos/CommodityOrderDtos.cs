using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.CommodityInventory.Dtos
{
    public class CommodityOrderDtos
    {
        public int Id { get; set; }
        public string No { get; set; }
        public int? CommodityId { get; set; }
        public decimal? Nums { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string Batch { get; set; }
        public decimal? Amount { get; set; }
        public int? AmountWay { get; set; }
        public decimal? AmountReceivable { get; set; }
        public decimal? AmountReceived { get; set; }
        public int? HandleId { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public int? Status { get; set; }
        public int? QmId { get; set; }
        public string Remark { get; set; }

        public string Commodity_Name { get; set; }
    
        public string HandleName { get; set; }
        public string Commodity_place { get; set; }
        public double Commodity_price { get; set; }
        public string Commodity_stock { get; set; }
      
        public string Commodity_spec { get; set; }


        public string categoryid { get; set; }
        public string categoryname { get; set; }

        public string supplierid { get; set; }
        public string suppliername { get; set; }

    }



}
