using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimesheetService.Database;
using TimesheetService.Database.Entities;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimesheetService.Controllers
{
   

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TimesheetController : ControllerBase
    {
        DatabaseContext db;

        // GET: api/<UserController>


        public TimesheetController()
        {
            db = new DatabaseContext();

        }
        
        [ActionName("TimesheetSubmittedCount")]
        [HttpGet]
        public IActionResult GetTimesheetSubmittedCount()
        {
            var TimesheetSubmittedCount = db.timesheetMaster.Count();
            return Ok(TimesheetSubmittedCount);
        }

        [ActionName("TimesheetSubmittedCount")]
        [HttpGet("{UserID}")]
        public IActionResult GetTimesheetSubmittedCount(int UserID)
        {


            var TimesheetSubmittedCount = db.timesheetMaster.Where(a => a.UserID == UserID).Count();

            return Ok(TimesheetSubmittedCount);
        }

        [ActionName("TimesheetSubmittedApprovedCount")]
        [HttpGet("{UserID}")]
        public IActionResult TimesheetSubmittedApprovedCount(int UserID)
        {
            var ExpenseSubmittedApprovedCount = (from e in db.timesheetMaster
                                                 where e.UserID == UserID && e.TimesheetStatus == 1
                                                 select e.UserID).Count();



            // string json = JsonConvert.SerializeObject(ExpenseSubmittedApprovedCount, Formatting.Indented);
            return Ok(ExpenseSubmittedApprovedCount);

        }

        [ActionName("TimesheetSubmittedRejectedCount")]
        [HttpGet("{UserID}")]
        public IActionResult TimesheetSubmittedRejectedCount(int UserID)
        {
            var TimesheetSubmittedRejectedCount = (from e in db.timesheetMaster
                                                 where e.UserID == UserID && e.TimesheetStatus == 2
                                                 select e.UserID).Count();

            return Ok(TimesheetSubmittedRejectedCount);

        }

        [ActionName("TimesheetSubmittedApprovedCount")]
        [HttpGet]
        public IActionResult TimesheetSubmittedApprovedCount()
        {
            var TimesheetSubmittedApprovedCount = (from e in db.timesheetMaster
                                                 where e.TimesheetStatus == 1
                                                 select e.UserID).Count();



            return Ok(TimesheetSubmittedApprovedCount);
        }

        [ActionName("TimesheetSubmittedRejectedCount")]
        [HttpGet]
        public IActionResult TimesheetSubmittedRejectedCount()
        {
            var TimesheetSubmittedRejectedCount = (from e in db.timesheetMaster
                                                 where e.TimesheetStatus == 2
                                                 select e.UserID).Count();



            return Ok(TimesheetSubmittedRejectedCount);
        }
        // GET: api/<TimesheetController>

        [ActionName("getTimesheetMaster")]
        [HttpGet("{UserID}")]
        public IEnumerable<TimesheetMaster> GetTimesheetMaster(int UserID)
        {
            return db.timesheetMaster.FromSql("SELECT * FROM timesheetdb.timesheetMaster where userID={0}",UserID);
        }

        [ActionName("getAllTimesheetMaster")]
        [HttpGet]
        public IEnumerable<TimesheetMaster> getAllTimesheetMaster()
        {
            return db.timesheetMaster.FromSql("SELECT * FROM timesheetdb.timesheetMaster");
        }


        [ActionName("getTimesheetDetails")]
        [HttpGet("{TimesheetMasterID}")]
        public IEnumerable<TimesheetDetails> GetTimesheetDetails(int TimesheetMasterID)
        {
            return db.timesheetDetails.FromSql("SELECT * FROM timesheetdb.timesheetDetails where TimesheetMasterID={0}", TimesheetMasterID);
        }

        [ActionName("insertTimesheetMaster")]
        // POST api/<TimesheetController>
        [HttpPost]
        public IActionResult Post([FromBody] TimesheetMaster m1)
        {
            db.timesheetMaster.Add(m1);
            
            db.SaveChanges();

            var query = db.timesheetMaster.FromSql("SELECT * FROM timesheetdb.timesheetMaster order by TimesheetMasterID desc limit 1");

            return Ok(query);
        }

        [ActionName("insertTimesheetDetail")]
        [HttpPost]
        public IActionResult Post([FromBody] TimesheetDetails m2)
        {
            db.timesheetDetails.Add(m2);
            db.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [ActionName("insertDescriptionTB")]
        [HttpPost]
        public IActionResult Post([FromBody] DescriptionTB m3)
        {
            db.descriptionTB.Add(m3);
            db.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [ActionName("getTimesheetExport")]
        [HttpGet]
        public IActionResult getTimesheetExport()
        {
            var students = new List<Timesheet>() {
               new Timesheet(){ ProjectName = null, Sunday= "05-01-2020", Monday = "06-01-2020", Tuesday = "07-01-2020", Wednesday ="08-01-2020",Thursday="09-01-2020",Friday="10-01-2020",Saturday="11-01-2020", Description = null},

                new Timesheet(){ ProjectName = "Apollo Hospital", Sunday= "5", Monday = "3", Tuesday = "5", Wednesday ="5",Thursday="8",Friday="5",Saturday="5", Total=36, Description = null}
                
            };

            return Ok(students);
        }


        

        [ActionName("deleteTimesheetMaster")]
        // DELETE api/<TimesheetController>/5
        [HttpDelete("{TimesheetMasterID}")]
        public IActionResult Delete(int TimesheetMasterID)
        {
            var recordToDelete = db.timesheetMaster.SingleOrDefault(x => x.TimesheetMasterId == TimesheetMasterID);

            if (recordToDelete == null)
            {
                return NotFound("No record found");
            }

            db.timesheetMaster.Remove(recordToDelete);
            db.SaveChanges();

            return Ok();
        }
        
         [ActionName("TimesheetApproval")]
        [HttpPut("{TimesheetMasterID}")]
        public IActionResult TimesheetApproval([FromBody] TimesheetMaster n)
        {
            var existingTs = db.timesheetMaster.Where(s => s.TimesheetMasterId == n.TimesheetMasterId).FirstOrDefault<TimesheetMaster>();


            if (existingTs != null)
            {
                existingTs.TimesheetStatus = n.TimesheetStatus;
                db.SaveChanges();

            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
