using Microsoft.EntityFrameworkCore;
using Sysplan.Agrimaldo.Domain.Entities;
using Sysplan.Agrimaldo.Infra.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sysplan.Agrimaldo.Infra.Context
{
    public class SysplanAgrimaldoDatabase : DbContext
    {
        public SysplanAgrimaldoDatabase(DbContextOptions<SysplanAgrimaldoDatabase> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Client> Client { get; set; }
    }
}
