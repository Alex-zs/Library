using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReaderLoan : System.Web.UI.Page
{
    static SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string readerID = Session["readerID"].ToString();

            string sql = "select * from LoanInformation where readerID = N'" + readerID + "'";

            DataTable dt = new DataTable();

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

        MyBook.DataSource = pds;

        MyBook.DataBind();

    }
    protected void MyBook_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "loanAgain")
        {
            int loanID = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "select * from LoanInformation where loanID = N'" + loanID + "'";

            DataTable dt = new DataTable();

            dt = SqlHelper.SqlSelect(sql);

            DateTime loanDate = Convert.ToDateTime(dt.Rows[0][5].ToString());

            string backDate =  loanDate.AddMonths(+2).ToLongDateString().ToString();

            string sql2 = "UPDATE LoanInformation SET backDate = '"+backDate+"' WHERE loanID = '"+loanID+"' ";

            SqlHelper.Update(sql2);

            if(backDate == dt.Rows[0][6].ToString())
            {
                Response.Write("<script>alert('只能续借一次！')</script>");
            }
            else
            {
                Response.Write("<script>alert('续借成功！');window.location.href='ReaderLoan.aspx'</script>");
            }
            



        }
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit.aspx");
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
}