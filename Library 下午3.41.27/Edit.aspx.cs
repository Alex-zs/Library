using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
          
        

    }

    protected void Change_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserChange.aspx");
    }

    protected void Find_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserFind.aspx");
    }

    protected void borrow_Click(object sender, EventArgs e)
    {
        Response.Redirect("BorrowBook.aspx");
    }

    protected void logout_Click(object sender, EventArgs e)
    {

        Session.Abandon();
        Response.Write("<script>window.location.href='Default.aspx'</script>");
    }

    protected void search_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReaderLoan.aspx");
    }
}