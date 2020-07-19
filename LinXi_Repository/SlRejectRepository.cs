using LinXi_IRepository;
using LinXi_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Repository
{
    public class SlRejectRepository : BaseRepository<SlReject>, ISlRejectRepository
    {
        public SlRejectRepository(DbContext db) : base(db)
        {
        }
    }
}