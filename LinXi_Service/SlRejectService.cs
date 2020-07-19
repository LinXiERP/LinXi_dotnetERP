using LinXi_IRepository;
using LinXi_IService;
using LinXi_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Service
{
    public class SlRejectService : BaseService<SlReject>, ISlRejectService
    {
        public SlRejectService(ISlRejectRepository SlRejectRepository) : base(SlRejectRepository)
        {
        }
    }
}