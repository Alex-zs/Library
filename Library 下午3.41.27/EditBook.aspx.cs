using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void addBook_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddBooks.aspx");
    }

    protected void deleteBook_Click(object sender, EventArgs e)
    {
        Response.Redirect("DeleteBook.aspx");
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminEdit.aspx");
    }
}