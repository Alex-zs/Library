using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Edituser : System.Web.UI.Page
{
   
    static SqlHelper SqlHelper = new SqlHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string sql = "select * from Readers";
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

        userList.DataSource = pds;

        userList.DataBind();
    }

    protected void UserList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int readerID = Convert.ToInt32(e.CommandArgument.ToString());
        string sql2 = "SELECT * from LoanInformation WHERE ReaderID = '" + readerID + "'";
        DataTable dt = SqlHelper.SqlSelect(sql2);
        int count = Convert.ToInt32(dt.Rows.Count.ToString());

        if (e.CommandName == "userDelete" &&count == 0)
        {
            
            string sql = "DELETE FROM Readers WHERE readerID = '" + readerID + "'";
            SqlHelper.Delete(sql);
            Response.Write("<script>alert('删除成功！');window.location.href='Edituser.aspx'</script>");
        }
        if(e.CommandName == "userDelete" && count != 0)
        {
            Response.Write("<script>alert('删除失败，该用户有书未还！')</script>");
        }
        if(e.CommandName == "lendInformation")
        {
            
            Response.Write("<script>window.location.href='LendInformation.aspx?readerID=" + readerID+"'</script>");
        }
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminEdit.aspx");
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
        string id = usersList.SelectedValue;
        if(id == "编号")
        {
            string readerID =txt.Text;
            if (Regex.IsMatch(readerID, @"(?i)^[0-9]+$"))
            {
                string sql = "select * from Readers where readerID = '" + readerID + "'";
                DataTable dt = SqlHelper.SqlSelect(sql);
                if (dt.Rows.Count != 0)
                {
                    user.DataSource = dt;
                    user.DataBind();
                    form1.Visible = false;
                    form2.Visible = true;
                }
                else
                {
                    Response.Write("<script>alert('查无此人！')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('请输入正确格式！')</script>");
            }
            


        }
        if(id == "邮箱")
        {
            string name = txt.Text;
            string sql = "select * from Readers where name = '" + name + "'";
            DataTable dt = SqlHelper.SqlSelect(sql);
            if(dt.Rows.Count != 0 )
            {
                user.DataSource = dt;
                user.DataBind();
                form1.Visible = false;
                form2.Visible = true;
            }
            else
            {
                Response.Write("<script>alert('查无此人！')</script>");
            }
        }
    }

    protected void user_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "borrow")
        {
            int readerID = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Write("<script>window.location.href='LendInformation.aspx?readerID=" + readerID + "'</script>");
        }
        if(e.CommandName == "delete")
        {
            int readerID = Convert.ToInt32(e.CommandArgument.ToString());
            string sql2 = "SELECT * from LoanInformation WHERE ReaderID = '" + readerID + "'";
            DataTable dt = SqlHelper.SqlSelect(sql2);
            int count = Convert.ToInt32(dt.Rows.Count.ToString());
            if (count == 0)
            {

                string sql = "DELETE FROM Readers WHERE readerID = '" + readerID + "'";
                SqlHelper.Delete(sql);
                Response.Write("<script>alert('删除成功！');window.location.href='Edituser.aspx'</script>");
            }
            if (count != 0)
            {
                Response.Write("<script>alert('删除失败，该用户有书未还！')</script>");
            }
        }
    }

    protected void backtoo_Click(object sender, EventArgs e)
    {
        form2.Visible = false;
        form1.Visible = true;
    }
}