using LinXi_IRepository;
using LinXi_IService;
using LinXi_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Service
{
    public class AcPermissionService : BaseService<AcPermission>, IAcPermissionService
    {
        public AcPermissionService(IAcPermissionRepository AcPermissionRepository) : base(AcPermissionRepository)
        {
        }
    }
}