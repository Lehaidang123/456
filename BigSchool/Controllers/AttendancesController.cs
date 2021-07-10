using BigSchool.Models;
using Microsoft.AspNet.Identity;
using BigSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Security.Principal;
using System.Web.Http;
using BigSchool.DTOs;

namespace BigSchool.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
       public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userid = System.Web.HttpContext.Current.User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.Attendeeid == userid && a.CourseID == attendanceDto.CourseId))
                return BadRequest(" the attendance already exit");
            var attendance = new Attendance
            {
                CourseID = attendanceDto.CourseId,
                Attendeeid = userid
            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
            return Ok();

        }

        [HttpPost]
        public IHttpActionResult Attend([FromBody] int courseId)
        {

            var userid = System.Web.HttpContext.Current.User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.Attendeeid == userid && a.CourseID == courseId))
                return BadRequest(" the attendance already exit");
            var attendance = new Attendance
            {
                CourseID = courseId,
                Attendeeid = userid
            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
            return Ok();
        }

        private IHttpActionResult BadRequest(string v)
        {
            throw new NotImplementedException();
        }

        private IHttpActionResult Ok()
        {
            throw new NotImplementedException();
        }
    }
}
