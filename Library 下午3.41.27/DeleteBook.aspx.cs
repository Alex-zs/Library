using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteBook : System.Web.UI.Page
{
    static SqlHelper SqlHelper = new SqlHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string sql = "select * from Books";
            Session["dt"] = SqlHelper.SqlSelect(sql);
            DataBindToRepeater(1);
        }
    }
    void DataBindToRepeater(int currentPage)
    {

        DataTable dt = (DataTable)Session["dt"];

        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;

        pds.PageSize = 2;

        pds.DataSource = dt.DefaultView;

        lbTotal.Text = pds.PageCount.ToString();

        pds.CurrentPageIndex = currentPage - 1;//当前页数从零开始，故把接受的数减一

        Repeater1.DataSource = pds;

        Repeater1.DataBind();
    }
    protected void btnUp_Click(object sender, EventArgs e)
    {
        string nowPage = lbNow.Text;

        int toPage = Convert.ToInt32(nowPage) - 1;

        if (toPage != 0)
        {
            lbNow.Text = Convert.ToString(toPage);

            DataBindToRepeater(toPage);
        }
        else
        {
            Response.Write("<script>alert('这是第一页！')</script>");
        }
    }

    protected void btnDown_Click(object sender, EventArgs e)
    {
        string nowPage = lbNow.Text;

        int toPage = Convert.ToInt32(nowPage) + 1;

        if (toPage <= Convert.ToInt32(lbTotal.Text))
        {
            lbNow.Text = Convert.ToString(toPage);

            DataBindToRepeater(toPage);
        }
        else
        {
            Response.Write("<script>alert('已到最后一页！')</script>");
        }
    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {
        lbNow.Text = "1";

        DataBindToRepeater(1);
    }

    protected void btnLast_Click(object sender, EventArgs e)
    {
        lbNow.Text = lbTotal.Text;

        DataBindToRepeater(Convert.ToInt32(lbTotal.Text));
    }
    protected void btnJump_Click(object sender, EventArgs e)
    {

        int jump = Convert.ToInt32(txtJump.Text);
        int pageNumbers = Convert.ToInt32(lbTotal.Text);
        if (jump <= pageNumbers)
        {
            lbNow.Text = txtJump.Text;
            DataBindToRepeater(jump);
        }
        else
        {

            Response.Write("<script>alert('没有此页！')</script>");
        }
    }
        protected void search_Click(object sender, EventArgs e)
        {
            string category = delete.SelectedValue;
            string btnBook = books.Text;
            if (category == "书名")
            {
                string sql = "select * from Books where bookName='" + btnBook + "'";
                DataTable dt = new DataTable();
                dt = SqlHelper.SqlSelect(sql);

                if (dt.Rows.Count == 0)
                {
                    Response.Write("<script>alert('书籍不存在！');window.location.href='DeleteBook.aspx'</script>");

                }
                if (dt.Rows.Count != 0)
                {
                    Session["bookID"] = dt.Rows[0][0].ToString();
                    deleteBook.DataSource = dt;
                    deleteBook.DataBind();
                    form1.Visible = false;
                    form2.Visible = true;

                }
            }
        

        if (category == "作者")
        {
            string sql = "select * from Books where author='" + btnBook + "'";
            DataTable dt = new DataTable();
            dt = SqlHelper.SqlSelect(sql);
            if (dt.Rows.Count == 0)
            {
                Response.Write("<script>alert('书籍不存在！');window.location.href='DeleteBook.aspx'</script>");

            }
            if (dt.Rows.Count != 0)
            {
                Session["bookID"] = dt.Rows[0][0].ToString();
                deleteBook.DataSource = dt;
                deleteBook.DataBind();
                form1.Visible = false;
                form2.Visible = true;
            }
        }
        if (category == "类别")
        {
            string sql = "select * from Books where category='" + btnBook + "'";
            DataTable dt = new DataTable();
            dt = SqlHelper.SqlSelect(sql);
            if (dt.Rows.Count == 0)
            {
                Response.Write("<script>alert('书籍不存在！');window.location.href='DeleteBook.aspx'</script>");

            }
            if (dt.Rows.Count != 0)
            {
                Session["bookID"] = dt.Rows[0][0].ToString();
                deleteBook.DataSource = dt;
                deleteBook.DataBind();
                form1.Visible = false;
                form2.Visible = true;
            }
        }
    }

    protected void deleteBook_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "delete")
        {
            string bookID = Session["bookID"].ToString();
            string sql = "select * from LoanInformation where bookID = '" + bookID + "'";
            DataTable dt = SqlHelper.SqlSelect(sql);
            int count = dt.Rows.Count;
            if(count == 0)
            {
                string sql2 = "delete from Books where bookID = '" + bookID + "'";
                SqlHelper.Delete(sql2);
                Response.Write("<script>alert('删除成功！');window.location.href='DeleteBook.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('该图书正在被借，无法删除！')</script>");
            }
        }
        if(e.CommandName == "change")
        {
            Response.Redirect("BookChange.aspx");
        }
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminEdit.aspx");
    }

    protected void back2_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminEdit.aspx");
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}