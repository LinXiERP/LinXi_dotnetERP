using LinXi_IRepository;
using LinXi_IService;
using LinXi_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Service
{
    public class IcWarehouseService : BaseService<IcWarehouse>, IIcWarehouseService
    {
        public IcWarehouseService(IIcWarehouseRepository IcWarehouseRepository) : base(IcWarehouseRepository)
        {
        }
    }
}
