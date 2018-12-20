using Microsoft.EntityFrameworkCore;
using RdlNet2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RdlNet2018.Data
{
    public class RDL2018Context : DbContext
    {
        public RDL2018Context(DbContextOptions<RDL2018Context> options) : base(options)
        {
            //woop woop
        }

        public DbSet<CareerInfo> CareerInfo { get; set; }
        public DbSet<JobSkill> JobSkill { get; set; }
        public DbSet<WorkHistory> WorkHistory { get; set; }
        public DbSet<WorkHistoryDetail> WorkHistoryDetail { get; set; }
    }
}
