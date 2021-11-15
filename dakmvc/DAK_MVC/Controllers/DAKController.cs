using DAK_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace DAK_MVC.Controllers
{
    public class DAKController : Controller
    {
        // GET: DAK
        public ActionResult homepage(DAKSearchInput input)
        {
            
            List<Post> lstPosts = new List<Post>();
            for (int i = 0; i < 20; i++)
            {
                lstPosts.Add(new Post());
            }
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

        public ActionResult ListCity()
        {
            //    return View("_ListCheckbox");
            //   return PartialView();
          

            List<City> lstCity = City.LoadCity();
            
        //    ViewBag.Message = lstCity.Select(x => new ListItem(x.Code, x.Name)).ToList();
            return PartialView("~/Views/Modules/_ListCheckbox.cshtml", lstCity.Select(x => new ListItem(x.Code, x.Name)).ToList());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public void NewPost(Post post)
        {
            //    return View("_ListCheckbox");
            //   return PartialView();
            PartialView("~/Views/Modules/_DropDownbox.cshtml", "City");
        }

        public ActionResult ListDistrict(int CityID)
        {
            List<District> lst = District.GetListDistrictBycityID(CityID);
         //   ViewBag.Message = lst.Select(x => new ListItem(x.ID.ToString(), x.Name)).ToList();
            return PartialView("~/Views/Modules/_DropDownbox2.cshtml", CityID.ToString());
        }

    }
}