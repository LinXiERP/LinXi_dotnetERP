using LinXi_IRepository;
using LinXi_IService;
using LinXi_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Service
{
    public class IcCommodityRecordService : BaseService<IcCommodityRecord>, IIcCommodityRecordService
    {
        public IcCommodityRecordService(IIcCommodityRecordRepository IcCommodityRecordRepository) : base(IcCommodityRecordRepository)
        {
        }
    }
}