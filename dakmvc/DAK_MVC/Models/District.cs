using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DAK_MVC.Models
{
    public class District
    {
        public int ID { get; set; }
        public int CityID { get; set; }
        public string Name { get; set; }
        public static List<District> GetListDistrictBycityID(int CityID)
        {
            List<District> lst = new List<District>();
            DataAccess dal = new DataAccess();
            DataSet ds = dal.ExecuteDataset("select * from [dak_District] with(nolock) where  [_province_id] = @cityID order by _name",
                new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@cityID",CityID)
                }
                );
            if (ds != null && ds.Tables.Count > 0)
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    lst.Add(new District { ID = (int)r["Id"], Name = r["_prefix"].ToString() + " " + r["_name"].ToString() });

                }
            return lst;
        }
    }
}