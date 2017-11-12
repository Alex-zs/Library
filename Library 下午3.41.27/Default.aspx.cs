using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    static SqlHelper SqlHelper = new SqlHelper();
    

    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void login_Click(object sender, EventArgs e)
    {
        string name = txtUserName.Text;
        string pwd = txtUserPwd.Text;
        string sql = "select * from Readers where name = '" + name + "' and password = '" + pwd + "'";
        System.Data.DataTable dt = new DataTable();
        dt = SqlHelper.SqlSelect(sql);
        int count = dt.Rows.Count;
        bool result = false;   //验证结果  
        string userCode = txtValidate.Value; //获取用户输入的验证码  
        if (String.IsNullOrEmpty(userCode))
        {
            //请输入验证码  
            return;
        }

        string validCode = Session["CheckCode"] as String;  //获取系统生成的验证码  
        if (!string.IsNullOrEmpty(validCode))
        {
            if (userCode.ToLower() == validCode.ToLower())
            {
                //验证成功  
                result = true;
            }
            else
            {
                //验证失败  
                result = false;
            }
        }
        Regex reg = new Regex(@"^\w+$");
        if (reg.IsMatch(pwd))
        {
           
        }
        else
        {
            count = 3;
        }
        if (result == false)
        {
            count = 2;
        }
        if (count == 0)
            Response.Write("<script>alert('用户名或密码错误！');location='Default.aspx'</script>");
        else if (count == 2)
        {
            Response.Write("<script>alert('验证码错误！');location='Default.aspx'</script>");
        }

        else if (count == 3)
        {
            Response.Write("<script>alert('密码只能为字母、数字和下划线！！');location='Default.aspx'</script>");
        }
        else       
        {
           
            
            string id = dt.Rows[0][0].ToString();
            Session["readerID"] = id;
            Session["userName"] = name;
            Response.Write("<script>alert('登录成功！');location='Edit.aspx'</script>");
        }

    }

    protected void register_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }

    protected void findPwd_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserFind.aspx");
    }

    protected void adminLogin_Click(object sender, EventArgs e)
    {
        form1.Visible = false;
        form2.Visible = true;
    }

    protected void adminLogins_Click(object sender, EventArgs e)
    {
        string name = adminEmail.Text;
        string pwd = adminPwd.Text;
        string sql = "select * from Admins where AdminName = N'" + name + "' and AdminPassword = '" + pwd + "'";
        System.Data.DataTable dt = new DataTable();
        dt = SqlHelper.SqlSelect(sql);
        int count = dt.Rows.Count;
        Session["userName"] = name;
        bool result = false;   //验证结果  
        string userCode = Text1.Value; //获取用户输入的验证码  
        string validCode = Session["CheckCode"] as String;  //获取系统生成的验证码  
        if (!string.IsNullOrEmpty(validCode))
        {
            if (userCode.ToLower() == validCode.ToLower())
            {
                //验证成功  
                result = true;
            }
            else
            {
                //验证失败  
                result = false;
            }
            Regex reg = new Regex(@"^\w+$");
            if (reg.IsMatch(pwd))
            {

            }
            else
            {
                count = 3;
            }
            if (count == 0)
            {
                Response.Write("<script>alert('用户名或密码错误！');location='Default.aspx'</script>");
            }
            else if (count == 3)
            {
                Response.Write("<script>alert('密码只能为字母、数字和下划线！');location='Default.aspx'</script>");
            }
            else if(result == true)
            {
                if (name == "alex-zs@foxmail.com")
                {
                    Response.Redirect("SuperAdmin.aspx");
                }
                else
                {
                    Response.Write("<script>alert('登录成功！');location='AdminEdit.aspx'</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('验证码错误！');location='Default.aspx'</script>");
            }
        }
    }

    protected void back_Click(object sender, EventArgs e)
    {
        form2.Visible = false;
        form1.Visible = true;
    }
}