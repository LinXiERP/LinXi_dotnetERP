using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.IntercourseManagement.Dtos
{
    public class SaleNoPayDtos
    {
        public int Id { get; set; }
        public string No { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public int? OrderId { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal Nums { get; set; }
        public decimal? Price { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryWay { get; set; }
    }
}