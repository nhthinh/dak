using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dak_datacrawling
{
    public class Post
    {
        public int ID { get; set; }
        public string GUIID { get; set; }
        public string Square_UI { get;  set; }
        public string name { get; set; }
        public string Like_UI { get; set; }
        public string Price_UI { get; set; }
        public string BedRoom_UI { get;  set; }
        public string Toilet_UI { get;  set; }
        public string Spuare_UI_Detail { get;  set; }
        public string Legal { get;  set; }
        public string Bank { get;  set; }
        public string Address_UI { get;  set; }
        public string Author { get;  set; }
        public string PostedDayAgo { get;  set; }
        public string Img_main { get;  set; }

        public Post()
        {
            GUIID = Guid.NewGuid().ToString();
              Square_UI = "50 m2";
            Price_UI = "1 Tỷ";
            BedRoom_UI = "2";
            Toilet_UI = "3";
            Spuare_UI_Detail = " <span class=\"kich - thuoc\">     < br />(ngang 5m x dọc 10m) </span>";
            Legal = "Sổ Hồng";
            Bank = "Techcombank";
            Address_UI = " 167 Trần Trọng Cung, P.Tân Thuận Đông, Q.7, HCM";
            Author = "Hoang Quan";
            PostedDayAgo = "1 Ngày trước";
            Img_main = "../images/house.png";
        }
    }
}