using LinXi_IRepository;
using LinXi_IService;
using LinXi_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Service
{
    public class SlOrderService : BaseService<SlOrder>, ISlOrderService
    {
        public SlOrderService(ISlOrderRepository ISlOrderRepository) : base(ISlOrderRepository)
        {

        }
    }
}