using DAK_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAK_MVC.Controllers
{
    public class DAKController : Controller
    {
        // GET: DAK
        public ActionResult homepage(DAKSearchInput input)
        {
            // 
            List<Post> lstPosts = new List<Post>();
            ViewBag.Message = lstPosts;
            return View("homepage");
        }
        public ActionResult addpost()
        {
            return View("addpost");
        }
        public ActionResult profile()
        {
            return View("profile");
        }
        public ActionResult searchreturn()
        {
            // 
            List<Post> lstPosts = new List<Post>();
            for (int i = 0; i < 20; i++)
            {
                lstPosts.Add(new Post());
            }
            ViewBag.Message = lstPosts;
            return View("searchreturn");
        }
        public ActionResult alert()
        {
            return View("alert");
        }
        public ActionResult message()
        {
            return View("message");
        }
    }
}