using LinXi_IRepository;
using LinXi_IService;
using LinXi_Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LinXi_Service
{
    public class SlSaleOrderService : BaseService<SlSaleOrder>, ISlSaleOrderService
    {
        public SlSaleOrderService(ISlSaleOrderRepository SlSaleOrderRepository) : base(SlSaleOrderRepository)
        {
        }
    }
}