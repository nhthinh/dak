using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DAK_MVC.Models
{
    public class City
    {
        public string Name { get; set; }
        public string Code { get; set; }


        public  List<City> LoadCity()
        {
            List<City> lst = new List<City>();
            DataAccess dal = new DataAccess();
            DataSet ds = dal.ExecuteDataset("select * from province with(nolock) order by _name");
            if(ds!=null && ds.Tables.Count >0)
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    lst.Add(new City { Code = r["_code"].ToString(), Name = r["_name"].ToString() });
                    
                }
            return lst;
        }
    }
    
}