using LinXi_IRepository;
using LinXi_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXi_Repository
{
    public class QmProductRepository : BaseRepository<QmProduct>, IQmProductRepository
    {
        public QmProductRepository(DbContext db) : base(db)
        {
        }
    }
}