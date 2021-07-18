﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAK_MVC.Controllers
{
    public class DAKController : Controller
    {
        // GET: DAK
        public ActionResult homepage()
        {
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