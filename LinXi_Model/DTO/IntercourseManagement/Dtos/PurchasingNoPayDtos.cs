using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.IntercourseManagement.Dtos
{
    public class PurchasingNoPayDtos
    {
        public string No { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public decimal Nums { get; set; }
        public decimal Price { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int? Status { get; set; }
        public string Batch { get; set; }
        public decimal? Amount { get; set; }
        public int? AmountWay { get; set; }
        public decimal? AmountReceivable { get; set; }
        public decimal? AmountReceived { get; set; }
        public string OperatorName { get; set; }
    }
}