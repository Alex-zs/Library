using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LendInformation : System.Web.UI.Page
{
    static SqlHelper SqlHelper = new SqlHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Request.UrlReferrer != null)
            {
                DataBindToRepeater(1);
            }
            else
            {
                Response.Write("<script>alert('请不要修改页面！');window.location.href='Edituser.aspx'</script>");
            }

        }

    }
    void DataBindToRepeater(int currentPage)
    {
        string ID = Request.QueryString["readerID"];
        string sql2 = "select * from LoanInformation where ReaderID='" + ID + "'";
        DataTable da = SqlHelper.SqlSelect(sql2);
        int count = Convert.ToInt32(da.Rows.Count);
        if(count == 0)
        {
            Response.Write("<script>alert('该用户没有借书！');window.location.href='Edituser.aspx'</script>");
        }
        else
        {
            readerEmail.Text = da.Rows[0][2].ToString();
            readerID.Text = ID;
            string sql = "select * from LoanInformation where ReaderID='" + ID + "'";
            DataTable dt = SqlHelper.SqlSelect(sql);
            books.DataSource = dt;
            books.DataBind();

        }


    }
   

   
    protected void lendBook_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      
    }

   

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edituser.aspx");
    }

    protected void RptPerson_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //找到外层Repeater的数据项
            DataRowView rowv = (DataRowView)e.Item.DataItem;
            //提取外层Repeater的数据项的ID
            string ID = Request.QueryString["readerID"];
            //找到对应ID下的Book
            string select = "select * from LoanInformation where bookID='" + ID + "'";
            //找到内嵌Repeater
            Repeater rept = (Repeater)e.Item.FindControl("RptBook");
            //数据绑定
            string sql = "select * from LoanInformation where bookID='" + ID + "'";
            DataTable dt = SqlHelper.SqlSelect(sql);
            rept.DataSource = dt;
            rept.DataBind();

        }
    }
    protected void books_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "backBook")
        {
            int loanID = Convert.ToInt32(e.CommandArgument.ToString()); ;

            string sql2 = "select * from LoanInformation where loanID = '" + loanID + "'";

            DataTable dt = SqlHelper.SqlSelect(sql2);

            string bookID = dt.Rows[0][3].ToString();

            string sql4 = "select * from Books where bookID = '" + bookID + "'";

            DataTable da = SqlHelper.SqlSelect(sql4);

            int librarynumber = Convert.ToInt32(da.Rows[0][9].ToString()) + 1;

            string sql3 = "update Books set libraryNumbers = '" + librarynumber + "' where bookID = '" + bookID + "'";

            SqlHelper.Update(sql3);

            string sql = "DELETE FROM LoanInformation WHERE loanID = '" + loanID + "'";

            SqlHelper.Delete(sql);

            Response.Write("<script>alert('归还成功！');window.location.href='Edituser.aspx'</script>");
        }
    }
}