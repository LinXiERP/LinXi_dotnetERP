﻿using LinXi_IRepository;
using LinXi_IService;
using LinXi_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Service
{
    public class AuRecordService : BaseService<AuRecord>, IAuRecordService
    {
        public AuRecordService(IAuRecordRepository AuRecordRepository) : base(AuRecordRepository)
        {
        }
    }
}