using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp31.Models
{
    public class VodafoneExceptionDbContext: DbContext
    {
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }

        /// <summary>
        /// DbContextOptions<DbContext> will resolve all the dependencies on DbContext class e.g. Connection, DbSet, Command, etc
        /// </summary>
        public VodafoneExceptionDbContext(DbContextOptions<VodafoneExceptionDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }


    }
}
