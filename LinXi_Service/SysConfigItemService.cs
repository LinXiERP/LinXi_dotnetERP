using LinXi_IRepository;
using LinXi_IService;
using LinXi_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Service
{
    public class SysConfigItemService : BaseService<SysConfigItem>, ISysConfigItemService
    {
        public SysConfigItemService(ISysConfigItemRepository SysConfigItemRepository) : base(SysConfigItemRepository)
        {
        }
    }
}