using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.CommodityInventory.Dtos
{
    public class PuCommodityDtos
    {
        public int Id { get; set; }
        public int Icategory_id { get; set; }
        public int supplier_id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public double stock { get; set; }

        public string place { get; set; }
        public string spec { get; set; }
        public string license_no { get; set; }
        public int operator_id { get; set; }

        public DateTime operate_time { get; set; }

        public string remark { get; set; }

        public string Icategory_name { get; set; }
        public string supplie_name { get; set; }
        public string operator_name { get; set; }



    }
}
