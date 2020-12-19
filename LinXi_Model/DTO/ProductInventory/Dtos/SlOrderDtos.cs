﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.ProductInventory.Dtos
{
    public class SlOrderDtos
    {
        public int Id { get; set; }
        public string No { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public decimal Nums { get; set; }
        public decimal? Price { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryWay { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? OrderAmount { get; set; }
        public int? HandleId { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperatorTime { get; set; }
        public int? Status { get; set; }
        public string Remark { get; set; }
        public string ProductName { get; set; }
        public string unit { get; set; }
        public decimal? stock { get; set; }
        public decimal? Productprice { get; set; }
        public string spec { get; set; }
        public string OperatorName { get; set; }
        public string HandleName { get;set; }
    }
}
