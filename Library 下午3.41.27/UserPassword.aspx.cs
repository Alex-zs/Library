using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string password = Session["password"].ToString();
        Response.Write("你的密码是：");
        Response.Write(password);
    }

    protected void Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit.aspx");
    }
}