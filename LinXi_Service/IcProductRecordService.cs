using LinXi_IRepository;
using LinXi_IService;
using LinXi_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Service
{
    public class IcProductRecordService : BaseService<IcProductRecord>, IIcProductRecordService
    {
        public IcProductRecordService(IIcProductRecordRepository IcProductRecordRepository) : base(IcProductRecordRepository)
        {
        }
    }
}
