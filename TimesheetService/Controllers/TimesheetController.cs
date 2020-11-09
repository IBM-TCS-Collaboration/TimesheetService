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
        // GET: api/<TimesheetController>

        [ActionName("getTimesheetMaster")]
        [HttpGet("{UserID}")]
        public IEnumerable<TimesheetMaster> GetTimesheetMaster(int UserID)
        {
            return db.timesheetMaster.FromSql("SELECT * FROM timesheetdb.timesheetmaster where userID={0}",UserID);
        }

        [ActionName("getAllTimesheetMaster")]
        [HttpGet]
        public IEnumerable<TimesheetMaster> getAllTimesheetMaster()
        {
            return db.timesheetMaster.FromSql("SELECT * FROM timesheetdb.timesheetmaster");
        }


        [ActionName("getTimesheetDetails")]
        [HttpGet("{TimesheetMasterID}")]
        public IEnumerable<TimesheetDetails> GetTimesheetDetails(int TimesheetMasterID)
        {
            return db.timesheetDetails.FromSql("SELECT * FROM timesheetdb.timesheetdetails where TimesheetMasterID={0}", TimesheetMasterID);
        }

        [ActionName("insertTimesheetMaster")]
        // POST api/<TimesheetController>
        [HttpPost]
        public IActionResult Post([FromBody] TimesheetMaster m1)
        {
            db.timesheetMaster.Add(m1);
            
            db.SaveChanges();

            var query = db.timesheetMaster.FromSql("SELECT * FROM timesheetdb.timesheetmaster order by TimesheetMasterID desc limit 1");

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
    }
}
