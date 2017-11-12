using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : Page
{
    static SqlHelper SqlHelper = new SqlHelper();
    /// <summary>  
    /// 验证码类型(0-字母数字混合,1-数字,2-字母)  
    /// </summary>  
    private string validateCodeType = "0";
    /// <summary>  
    /// 验证码字符个数  
    /// </summary>  
    private int validateCodeCount = 4;
    /// <summary>  
    /// 验证码的字符集，去掉了一些容易混淆的字符  
    /// </summary>  
    char[] character = { '2', '3', '4', '5', '6', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };
    private string GenerateCheckCode()
    {
        char code;
        string checkCode = String.Empty;
        System.Random random = new Random();

        for (int i = 0; i < validateCodeCount; i++)
        {
            code = character[random.Next(character.Length)];

            // 要求全为数字或字母  
            if (validateCodeType == "1")
            {
                if ((int)code < 48 || (int)code > 57)
                {
                    i--;
                    continue;
                }
            }
            else if (validateCodeType == "2")
            {
                if ((int)code < 65 || (int)code > 90)
                {
                    i--;
                    continue;
                }
            }
            checkCode += code;
        }

        Response.Cookies.Add(new System.Web.HttpCookie("CheckCode", checkCode));
        Session["CheckCode"] = checkCode;
        return checkCode;
    }

    static string str = @"server=.;Integrated Security=SSPI;database=Library;";

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnVal_Click(object sender, EventArgs e)
    {
        int flag = 1;
        string emailStr = @"([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,5})+";
        Regex emailReg = new Regex(emailStr);
        if (emailReg.IsMatch(userName.Text.Trim()))
        {
            flag = 1;
        }
        else
        {
            flag = 8;
        }       
        string name = userName.Text;
        string password = userPwd.Text;
        String passwords = userPwds.Text;
        int lenth = name.Length;
        int lenths = password.Length;
        string UserName = userName.Text;
        string selStr = "select * from Readers where name='" + UserName + "'";
        DataSet dt = new DataSet();
        dt = SqlHelper.DataSet(selStr);
        if (dt.Tables[0].Rows.Count != 0)
        {
            flag = 2;
        }
        if (name.IndexOf(" ") > -1 || password.IndexOf(" ") > -1)
        {
            flag = 3;
        }
        if(password != passwords)
        {
            flag = 4;
        }
        if  (lenth < 4 || lenth > 20)
        {
            flag = 6;
        }
        if (lenths < 6 || lenths >20)
        {
            flag = 7;
        }
        if (lenth == 0 || lenths == 0)
        {
            flag = 0;
        }
        Regex reg = new Regex(@"^\w+$");
        if (reg.IsMatch(password))
        {
            
        }

        else
        {
            flag = 9;
        }


        if (flag == 1)
        {
            Session["userName"] = userName.Text;
            Session["userPwd"] = userPwd.Text;
            string txtEmailAddress = userName.Text;
            string validCode = GenerateCheckCode();  //获取系统生成的验证码  
            string smtpServer = "smtp.qq.com"; //SMTP服务器
            string mailFrom = "330953853@qq.com"; //登陆用户名
            string userPassword = "ulldpxudytplcbee";//客户端授权码
            string mailTo = txtEmailAddress;
            string mailSubject = "验证码";
            string mailContent = "你的验证码是" + validCode;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            smtpClient.Host = smtpServer; //指定SMTP服务器
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential(mailFrom, userPassword);//用户名和密码
            MailMessage mailMessage = new MailMessage(mailFrom, mailTo); // 发送人和收件人
            mailMessage.Subject = mailSubject;//主题
            mailMessage.Body = mailContent;//内容
            mailMessage.BodyEncoding = Encoding.UTF8;//正文编码
            mailMessage.IsBodyHtml = false;//设置为HTML格式
            mailMessage.Priority = MailPriority.Normal;//优先级        
            smtpClient.Send(mailMessage); // 发送邮件
            form1.Visible = false;
            form2.Visible = true;
        }
        if (flag == 0)
        {
            Response.Write("<script>alert('请输入后点击！');location='Register.aspx'</script>");
        }
        if (flag == 2)
        {
            Response.Write("<script>alert('用户名已存在！');location='Register.aspx'</script>");
        }
        if (flag == 3)
        {
            Response.Write("<script>alert('请不要输入空格！');location='Register.aspx'</script>");
        }
        if (flag == 4)
        {
            Response.Write("<script>alert('前后密码不一致！');location='Register.aspx'</script>");
        }
        if (flag == 6)
        {
            Response.Write("<script>alert('用户名为4位到16位!');location='Register.aspx'</script>");
        }
        if (flag == 7)
        {
            Response.Write("<script>alert('请输入6到16位的密码！');location='Register.aspx'</script>");
        }
        if (flag == 8)
        {
            Response.Write("<script>alert('请输入正确格式！');Location='Rdgister.aspx'</script>");
        }
        if (flag == 9)
        {
            Response.Write("<script>alert('密码只能为字母、数字和下划线！');Location='Rdgister.aspx'</script>");
        }

    }




    protected void register_Click(object sender, EventArgs e)
    {
        string code = validateCode.Text;
        String codes = Session["CheckCode"].ToString();
        string name = Session["userName"].ToString();
        string password = Session["userPwd"].ToString();

        if (code == codes)
        {
            string sql = "insert into  Readers values(N'" + name + "','" + password + "')";
            SqlHelper.InsertInto(sql);
            string sql2 = "select * from Readers where name = N'" + name + "' "; 
            System.Data.DataTable dt = new DataTable();
            dt = SqlHelper.SqlSelect(sql2);
            Session["username"] = userName.Text;
            string id = dt.Rows[0][0].ToString();
            Session["id"] = id;
            Response.Write("<script>alert('注册成功！');location='Default.aspx'</script>");
        }
        else
        {
            Response.Write("<script>alert('验证码出错！！');Location='Rdgister.aspx'</script>");
        }
    }

    protected void adminRegister_Click(object sender, EventArgs e)
    {
        form1.Visible = false;
        form3.Visible = true;
        
    }

    protected void send_Click(object sender, EventArgs e)
    {
        int flag = 1;
        string emailStr = @"([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,5})+";
        Regex emailReg = new Regex(emailStr);
        if (emailReg.IsMatch(adminEmail.Text.Trim()))
        {
            
        }
        else
        {
            flag = 8;
        }
        string name = adminEmail.Text;
        string password = adminPwd.Text;
        String passwords = adminPwds.Text;
        int lenth = name.Length;
        int lenths = password.Length;
        string selStr = "select * from Readers where name='" + name + "'";
        DataSet ds = new DataSet();
        ds = SqlHelper.DataSet(selStr);
        
        if (ds.Tables[0].Rows.Count != 0)
        {
            flag = 2;
        }
        if (name.IndexOf(" ") > -1 || password.IndexOf(" ") > -1)
        {
            flag = 3;
        }
        if (password != passwords)
        {
            flag = 4;
        }
        if (lenth < 4 || lenth > 16)
        {
            flag = 6;
        }
        if (lenths < 6 || lenths > 16)
        {
            flag = 7;
        }
        if (lenth == 0 || lenths == 0)
        {
            flag = 0;
        }
        Regex reg = new Regex(@"^\w+$");
        if (reg.IsMatch(password))
        {
            flag = 1;
        }

        else
        {
            flag = 9;
        }


        if (flag == 1)
        {
            Session["adminEmail"] = adminEmail.Text;
            Session["adminPwd"] = adminPwd.Text;
            string txtEmailAddress = adminEmail.Text;
            string validCode = GenerateCheckCode();  //获取系统生成的验证码  
            string smtpServer = "smtp.qq.com"; //SMTP服务器
            string mailFrom = "330953853@qq.com"; //登陆用户名
            string userPassword = "ulldpxudytplcbee";//客户端授权码
            string mailTo = txtEmailAddress;
            string mailSubject = "验证码";
            string mailContent = "你的验证码是" + validCode;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            smtpClient.Host = smtpServer; //指定SMTP服务器
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential(mailFrom, userPassword);//用户名和密码
            MailMessage mailMessage = new MailMessage(mailFrom, mailTo); // 发送人和收件人
            mailMessage.Subject = mailSubject;//主题
            mailMessage.Body = mailContent;//内容
            mailMessage.BodyEncoding = Encoding.UTF8;//正文编码
            mailMessage.IsBodyHtml = false;//设置为HTML格式
            mailMessage.Priority = MailPriority.Normal;//优先级        
            smtpClient.Send(mailMessage); // 发送邮件
            form3.Visible = false;
            form4.Visible = true;
        }
        if (flag == 0)
        {
            Response.Write("<script>alert('请输入后点击！');location='Register.aspx'</script>");
        }
        if (flag == 2)
        {
            Response.Write("<script>alert('用户名已存在！');location='Register.aspx'</script>");
        }
        if (flag == 3)
        {
            Response.Write("<script>alert('请不要输入空格！');location='Register.aspx'</script>");
        }
        if (flag == 4)
        {
            Response.Write("<script>alert('前后密码不一致！');location='Register.aspx'</script>");
        }
        if (flag == 6)
        {
            Response.Write("<script>alert('用户名为4位到16位!');location='Register.aspx'</script>");
        }
        if (flag == 7)
        {
            Response.Write("<script>alert('请输入6到16位的密码！');location='Register.aspx'</script>");
        }
        if (flag == 8)
        {
            Response.Write("<script>alert('请输入正确格式！');Location='Rdgister.aspx'</script>");
        }
        if (flag == 9)
        {
            Response.Write("<script>alert('密码只能为字母、数字和下划线！');Location='Rdgister.aspx'</script>");
        }
    }

    protected void adminRegister_Click1(object sender, EventArgs e)
    {
        string code = adminValidateCode.Text;
        String codes = Session["CheckCode"].ToString();
        string name = Session["adminEmail"].ToString();
        string password = Session["adminPwd"].ToString();
        string remark = remarks.Text;

        if (code == codes)
        {
            string sql = "INSERT INTO AdminPass (name,password,remark) VALUES ('" + name + "', '" + password + "','"+remark+"')";
            SqlHelper.InsertInto(sql);
            Response.Write("<script>alert('申请中，请注意查收邮件！');window.location.href='Default.aspx'</script>");
        }
        else
        {
            Response.Write("<script>alert('验证码出错！');Location='Rdgister.aspx'</script>");
        }
    }
}