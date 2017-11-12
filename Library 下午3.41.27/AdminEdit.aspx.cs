using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void editReader_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edituser.aspx");
    }

    protected void editBook_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditBook.aspx");
    }



    protected void back_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Write("<script>window.location.href='Default.aspx'</script>");
    }
}