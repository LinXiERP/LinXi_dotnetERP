using LinXi_IRepository;
using LinXi_IService;
using LinXi_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Service
{
    public class PrProductTaskService : BaseService<PrProductTask>, IPrProductTaskService
    {
        public PrProductTaskService(IPrProductTaskRepository IPrProductTaskRepository) : base(IPrProductTaskRepository)
        {
        }
    }
}