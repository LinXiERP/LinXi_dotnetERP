using LinXi_IRepository;
using LinXi_IService;
using LinXi_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Service
{
    public class IcProductStockService : BaseService<IcProductStock>, IIcProductStockService
    {
        public IcProductStockService(IIcProductStockRepository IcProductStockRepository) : base(IcProductStockRepository)
        {
        }
    }
}
