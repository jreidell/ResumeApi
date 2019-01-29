﻿using Microsoft.EntityFrameworkCore;
using RdlNet2018.Common.Models;


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
        public DbSet<AuthUser> AuthUser { get; set; }
    }
}
