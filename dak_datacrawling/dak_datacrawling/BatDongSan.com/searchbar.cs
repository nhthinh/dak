using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dak_datacrawling
{
    public partial class batdongsan : Base
    {
        public IWebElement SearchBar
        {
            get
            {
                return base.GetIWebElementByClass("search-bar");
            }
        }

        public void FillSearchInput(string ban_chothue, string loai_nha_dat, string[] arr_xapth_khu_vuc, string muc_gia, string dien_tich, string du_an = "")
        {
            // fill ban_or che thue
            IWebElement eBan_chothue = base.GetFirstChildByClass(SearchBar, "search-bar-tab");
            //if (eBan_chothue.FindElements(By.TagName("a"))[0].Text.ToLower() == ban_chothue.ToLower())
            //    ClickOn(eBan_chothue.FindElements(By.TagName("a"))[0], "ban or cho thue");
            //else
            //    ClickOn(eBan_chothue.FindElements(By.TagName("a"))[1], "ban or cho thue");

            // loai nha dat

            ClickOn(base.GetFirstChildByClass(SearchBar, "select-cate"),"Chon loai nha dat");
           //Thread.Sleep(10000);

            List<IWebElement> list_loai_nha_dat = base.GetIWebElementByID("mCSB_3").FindElement(By.Id("divCate")).FindElement(By.TagName("ul")).FindElements(By.TagName("li")).ToList();
            bool isFound = false;
            foreach (var item in list_loai_nha_dat)
            {
                string text = item.FindElement(By.TagName("span")).Text.ToLower();
                if (text == loai_nha_dat)
                {
                    ClickOn(item.FindElement(By.TagName("span")), "Chon loai nha dat item");
                    break;
                }
                else
                {
                    IWebElement ul = base.GetFirstChildByTagName_AcceptNull(item, "ul");
                    if (ul != null)
                    {
                        List<IWebElement> lst = ul.FindElements(By.TagName("li")).ToList();
                        foreach (var ii in lst)
                        {
                            base.MoveToElement(ii);
                             text = ii.FindElement(By.TagName("span")).Text;
                            if (text.ToLower() == loai_nha_dat.ToLower())
                            {
                                ClickOn(ii.FindElement(By.TagName("span")), "Chon loai nha dat item");
                                isFound = true;
                                break;
                            }
                        }
                        if (isFound)
                            break;
                    }
                    //  IWebElement ul = item.FindElements()
                }
            }


            Thread.Sleep(1000);
            // chon khu vuc
            ClickOn(base.GetFirstChildByClass(SearchBar, "city-control"), "Chon khu vuc");

            List<IWebElement> liostTintthanh =  base.GetIWebElementByID("mCSB_3").FindElement(By.Id("divCate")).FindElement(By.TagName("ul")).FindElements(By.TagName("li")).ToList();



            foreach (var item in arr_xapth_khu_vuc)
            {
                base.MoveToElement(By.XPath(item));
                ClickOn(By.XPath(item),"Chon khu vuc item");
            }

          

           // Thread.Sleep(1000);
            // chon muc gia
           // ClickOn(base.GetFirstChildByClass(SearchBar, "custom-value"), "Chon khu vuc");
        }

    }
}
