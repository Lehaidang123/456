using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class FollowingsControllerController : Controller
    {
          
        private readonly ApplicationDbContext _dbContext;
        public FollowingsControllerController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: FollowingsController
        public ActionResult Index()
        {
            return View();
        }
        [System.Web.Http.HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userid = System.Web.HttpContext.Current.User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userid && f.FollowerId == followingDto.FolloweeId))
                return BadRequest(" Following  already exit");
            var following = new Following
            {
              FollowerId =userid,
              FolloweeId =followingDto.FolloweeId
            };
            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();
            return Ok();
        }

        private IHttpActionResult Ok()
        {
            throw new NotImplementedException();
        }

        private IHttpActionResult BadRequest(string v)
        {
            throw new NotImplementedException();
        }
    }
}