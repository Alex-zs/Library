using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class BorrowBook : System.Web.UI.Page
{
    static SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }



    public void search_Click(object sender, EventArgs e)
    {
        Session["search"] = dropList.SelectedValue;
        Session["btnBook"] = btnBook.Text;
        Response.Redirect("BookList.aspx");
        
    }



    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit.aspx");
    }
}