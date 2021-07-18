using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LayoutHTML_NewPost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ClearContent(); string content = "";
        string sstep = Request.QueryString["step"] ?? "0";
        int step = int.Parse(sstep);
        string type = Request.QueryString["type"] ?? "0";
        if (step == 0)
            content = divNewPost.InnerHtml.Trim().Trim('\n').Trim('\r');
        else if (step == 2)
        {
            content = divNewPostStep2.InnerHtml.Trim().Trim('\n').Trim('\r');
        }
  
            Response.Write(content);
        Response.End();
    }
}