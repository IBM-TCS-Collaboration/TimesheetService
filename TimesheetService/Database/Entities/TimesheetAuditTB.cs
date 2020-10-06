using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TimesheetService.Database.Entities
{
    public class TimesheetAuditTB
    {
        [Key]
        public int ApprovalTimesheetLogID { get; set; }
        public int ApprovalUser { get; set; }
        public DateTime ProcessedDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Comment { get; set; }
        public int Status { get; set; }
        public int TimesheetID { get; set; }
        public int UserID { get; set; }

    }
}
