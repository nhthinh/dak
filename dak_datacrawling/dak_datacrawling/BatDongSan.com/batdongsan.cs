using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dak_datacrawling
{
    public partial class batdongsan : Base
    {

        public batdongsan() : base()
        {
            logfileName = "batdongsan" + DateTime.Now.ToString("dd.HH") + ".log";
            baseURL = "https://batdongsan.com.vn/nha-dat-ban";
        }


        public void GetData()
        {
            driver.Url = baseURL;
            driver.Manage().Window.Maximize();
            // a@@b->startwith=a and endwith=b
        
            FillSearchInput("Bán", "Bán Đất", new string[] { "/html/body/form/div/div[6]/div[2]/div[2]/div/div[1]/ul/li[2]", "/html/body/form/div/div[6]/div[2]/div[2]/div/div[1]/ul/li[1]" }, "500@@800 triệu", "50 m²@@80 m²");
            ClickOn(By.Id("btnSearch"), "btnSearch");
            base.WaitForElementPresent(By.ClassName("product-lists-count"));
            //
            List<IWebElement> listPosts = base.GetIWebElementByClass("product-lists").FindElements(By.ClassName("pr-container")).ToList();
            Post post;
            List<Post> lstposts = new List<Post>();
            foreach (IWebElement item in listPosts)
            {
                post = new Post();
                base.MoveToElement(item);
                var maindiv = item.FindElement(By.ClassName("product-main"));
                post.Square_UI = maindiv.FindElement(By.ClassName("area")).Text;
                post.name = maindiv.FindElement(By.ClassName("pr-title")).Text;
                string url = item.FindElement(By.ClassName("product-avatar")).FindElement(By.TagName("img")).GetAttribute("src"); //FindElement(By.TagName("img")).GetAttribute("src");//
                base.DownloadImage(url, post.GUIID + ".jpg");
                post.Img_main = post.GUIID;
                post.Address_UI = maindiv.FindElement(By.ClassName("location")).Text;
                //lstposts.Add(post);

            string sqsl= @"INSERT INTO [dbo].[dak_Post]
           (         
           ,[Address]
         
           ,[CityID]
           ,[WardID]
           ,[StreetID]
           ,[ProjectID]
           ,[Price]
           ,[PriceUnit]
           ,[Square]
           ,[Room]
           ,[Toilet]
           ,[HomeSubTypeID]
           ,[SellOrRent]
           ,[Direction]
           ,[PinkBook]
           ,[IsHost]
           ,[MainImageID]"
            }
            string s = "";
        }

       
    }
}
