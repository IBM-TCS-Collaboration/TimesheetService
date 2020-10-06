using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetService.Database.Entities;

namespace TimesheetService.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<TimesheetMaster> timesheetMaster { get; set; }
       
        public DbSet<TimesheetDetails> timesheetDetails { get; set; }
        public DbSet<TimesheetAuditTB> timesheetAuditTB { get; set; }
        public DbSet<DescriptionTB> descriptionTB { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"server=ts-management-db; port=3306; database=timesheetdb; user=root; password=password");
        }
    }
}
