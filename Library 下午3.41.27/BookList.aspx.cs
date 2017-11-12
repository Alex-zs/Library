using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookList : System.Web.UI.Page
{
    static SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string search = Session["search"].ToString();
            string btnBook = Session["btnBook"].ToString();
            if (search == "书名")
            {
                string sql = "select * from Books where bookName='" + btnBook + "'";
                DataTable dt = new DataTable();
                dt = SqlHelper.SqlSelect(sql);
                if (dt.Rows.Count == 0)
                {
                    Response.Write("<script>alert('书籍不存在！');window.location.href='BorrowBook.aspx'</script>");

                }
                if (dt.Rows.Count != 0)
                {
                    bookNameList.DataSource = dt;
                    Session["dt"] = dt;
                    DataBindToRepeater(1);
                }
            }

            if (search == "作者")
            {
                string sql = "select * from Books where author='" + btnBook + "'";
                DataTable dt = new DataTable();
                dt = SqlHelper.SqlSelect(sql);
                if (dt.Rows.Count == 0)
                {
                    Response.Write("<script>alert('书籍不存在！');window.location.href='BorrowBook.aspx'</script>");

                }
                if (dt.Rows.Count != 0)
                {
                    Session["btnBook"] = dt.Rows[0][1].ToString();
                    Session["dt"] = dt;
                    DataBindToRepeater(1);
                }
            }
            if (search == "类别")
            {
                string sql = "select * from Books where category='" + btnBook + "'";
                DataTable dt = new DataTable();
                dt = SqlHelper.SqlSelect(sql);
                if (dt.Rows.Count == 0)
                {
                    Response.Write("<script>alert('书籍不存在！');window.location.href='BorrowBook.aspx'</script>");

                }
                if (dt.Rows.Count != 0)
                {
                    Session["btnBook"] = dt.Rows[0][1].ToString();
                    Session["dt"] = dt;
                    DataBindToRepeater(1);
                }
            }
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

        bookNameList.DataSource = pds;

        bookNameList.DataBind();
    }

    protected void bookNameList_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "lendBook")
        {
            string readerID = Session["readerID"].ToString();
            int bookId = Convert.ToInt32(e.CommandArgument.ToString());
            string sql2 = "select * from LoanInformation where bookID ='" + bookId + "' and ReaderID ='"+readerID+"'";
            DataTable dt = SqlHelper.SqlSelect(sql2);
            int count = Convert.ToInt32(dt.Rows.Count.ToString());
            string sql3 = "select * from Books where bookID = '" + bookId + "'";
            DataTable da = SqlHelper.SqlSelect(sql3);
            int numbers = Convert.ToInt32(da.Rows[0][9].ToString());
            int number = numbers - 1;

            if(count == 0 && numbers != 0)
            {
                string userName = Session["userName"].ToString();
                string bookName = Session["btnBook"].ToString();
                string lendTime = DateTime.Now.ToLongDateString().ToString();
                string backTime = DateTime.Now.AddMonths(+1).ToLongDateString().ToString();
                string sql = "insert into LoanInformation(ReaderID,ReaderName,bookID,bookName,loanDate,backDate) values('" + readerID + "','" + userName + "','" + bookId + "','" + bookName + "','" + lendTime + "','" + backTime + "' )";
                SqlHelper.InsertInto(sql);
                string sql4 = "update Books set libraryNumbers = '" + number + "' where bookID = '" + bookId + "'";
                SqlHelper.Update(sql4);
                Response.Write("<script>alert('借阅成功！');window.location.href='Edit.aspx'</script>");
            }
            if(count != 0)
            {
                Response.Write("<script>alert('只能借阅一本！');window.location.href='Edit.aspx'</script>");
            }
            if(numbers == 0)
            {
                Response.Write("<script>alert('该图书已全部被借！')</script>");
            }
           
        }
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("BorrowBook.aspx");
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
        if(jump <= pageNumbers)
        {
            lbNow.Text = txtJump.Text;
            DataBindToRepeater(jump);
        }
        else
        {
            
            Response.Write("<script>alert('没有此页！')</script>");
        }


    }
}