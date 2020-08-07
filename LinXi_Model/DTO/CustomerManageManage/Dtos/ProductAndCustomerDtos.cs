using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.CustomerManageManage.Dtos
{
    public class ProductAndCustomerDtos
    {
        public IEnumerable<PrProductDtos> Product { get; set; }
        public IEnumerable<SlCustomerDtos> Customer { get; set; }
    }
}
