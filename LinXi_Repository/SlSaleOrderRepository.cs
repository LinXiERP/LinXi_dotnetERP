﻿using LinXi_IRepository;
using LinXi_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LinXi_Repository
{
    public class SlSaleOrderRepository : BaseRepository<SlSaleOrder>, ISlSaleOrderRepository
    {
        public SlSaleOrderRepository(DbContext db) : base(db)
        {

        }
    }
}