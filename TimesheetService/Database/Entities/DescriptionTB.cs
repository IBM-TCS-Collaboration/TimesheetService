using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetService.Database.Entities
{
    public class DescriptionTB
    {
        [Key]
        public int DescriptionId { get; set; }
        public string Description { get; set; }

        public int ProjectId { get; set; }
        public int TimesheetMasterId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UserId { get; set; }
    }
}
