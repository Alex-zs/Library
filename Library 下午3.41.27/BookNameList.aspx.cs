using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookNameList : System.Web.UI.Page
{
    static SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Session["bookName"].ToString();
        string sql = "select * from Books where bookName = N'" + name + "' ";
        DataTable dt = new DataTable();
        dt = SqlHelper.SqlSelect(sql);
        bookNameList.DataSource = dt;
        bookNameList.DataBind();
    }


    protected void BookNameList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       
        if(e.CommandName == "borrowBook")
        {
            int bookId = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Write("<script>alert('你即将跳转到另一个页面');location='BookList.aspx?id=" + bookId + "'</script>");
        }
    }
}