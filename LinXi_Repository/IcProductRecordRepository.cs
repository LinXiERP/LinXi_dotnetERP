using LinXi_IRepository;
using LinXi_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Repository
{
    public class IcProductRecordRepository : BaseRepository<IcProductRecord>, IIcProductRecordRepository
    {
        public IcProductRecordRepository(DbContext db) : base(db)
        {
        }
    }
}
