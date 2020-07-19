using LinXi_IRepository;
using LinXi_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Repository
{
    public class PuCommodityRepository : BaseRepository<PuCommodity>, IPuCommodityRepository
    {
        public PuCommodityRepository(DbContext db) : base(db)
        {
        }
    }
}