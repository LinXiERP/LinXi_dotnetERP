using LinXi_Model.DTO.ProductionManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.ProductInventory.Dtos
{
    public class ProductinfoAndWarehouseDtos
    {
        public IEnumerable<ProcductTaskDtos> Product { get; set; }
        public IEnumerable<IcWarehouse> Warehouse { get; set; }
    }
}
