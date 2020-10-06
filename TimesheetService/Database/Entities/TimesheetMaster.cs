using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetService.Database.Entities
{
    public class TimesheetMaster
    {
        [Key]
        public int TimesheetMasterId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int TotalHours { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Comment { get; set; }
        public int TimesheetStatus { get; set; }
    }
}
