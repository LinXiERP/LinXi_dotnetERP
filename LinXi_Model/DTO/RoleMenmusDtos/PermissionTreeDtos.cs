using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Model.DTO.RoleMenmusDtos
{
       public   class PermissionTreeDtos
    {

        public int value { get; set; }
        public string label { get; set; }
       
        
        public List<PermissionTreeDtos> children { get; set; }
      
    }
}
