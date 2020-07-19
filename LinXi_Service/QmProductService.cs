using LinXi_IRepository;
using LinXi_IService;
using LinXi_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Service
{
    public class QmCommodityService : BaseService<QmCommodity>, IQmCommodityService
    {
        public QmCommodityService(IQmCommodityRepository IQmCommodityRepository) : base(IQmCommodityRepository)
        {

        }
    }
}