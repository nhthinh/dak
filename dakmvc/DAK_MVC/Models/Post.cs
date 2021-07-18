using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAK_MVC.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string name { get; set; }
        public Post(int v)
        {
            ID = v;
            name = "Day la nha so " + v
;        }
    }
}