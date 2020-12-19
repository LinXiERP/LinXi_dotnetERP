using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.CustomerManageManage.Dtos
{
    public class OrderTraceDtos
    {
        public SlOrderTDtos Order { get; set; }
        public SlSaleOrderDtos Sale { get; set; }
        public PrProductDtos Product { get; set; }
               
        public SlOrderTDtos BalanceDue { get; set; }
    }
}
