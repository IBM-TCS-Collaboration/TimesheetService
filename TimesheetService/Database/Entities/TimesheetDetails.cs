using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetService.Database.Entities
{
    public class TimesheetDetails
    {
        [Key]
        public int TimesheetId { get; set; }
        public string DaysofWeek { get; set; }
        public int Hours { get; set; }
        public DateTime Period { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int TimesheetMasterId { get; set; }
        public int TotalHours { get; set; }

    }
}
