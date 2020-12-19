using LinXi_IRepository;
using LinXi_IService;
using LinXi_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Service
{
   public class AcNoticeService: BaseService<AcNotice>, IAcNoticeService
    {
        public AcNoticeService(IAcNoticeRepository AcNoticeRepository) : base(AcNoticeRepository)
        {
        }
    }
}
