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
            baseURL = "https://batdongsan.com.vn/";
        }


        public void GetData()
        {
            driver.Url = baseURL;
            // a@@b->startwith=a and endwith=b

            FillSearchInput("Bán", "Bán Đất", "Hồ Chí Minh", "500@@800 triệu", "50 m²@@80 m²");

        }

       
    }
}
