using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.CustomerManageManage.Dtos
{
    public class OrderTraceDtos
    {
        public SlOrderDtos Order { get; set; }
        public SlSaleOrderDtos Sale { get; set; }
        public PrProductDtos Product { get; set; }
               
        public SlOrderDtos BalanceDue { get; set; }
    }
}
