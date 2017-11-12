using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdmin : System.Web.UI.Page
{
    static SqlHelper SqlHelper = new SqlHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "select * from AdminPass";
        DataTable dt = SqlHelper.SqlSelect(sql);
        admin.DataSource = dt;
        admin.DataBind();

    }

    protected void admin_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "agree")
        {
            string id = e.CommandArgument.ToString();
            string sql = "select * from AdminPass where id = '" + id + "'";
            DataTable dt = SqlHelper.SqlSelect(sql);
            string name = dt.Rows[0][1].ToString();
            string password = dt.Rows[0][2].ToString();
            string sql2 = "INSERT INTO Admins (AdminName,AdminPassword) VALUES ('" + name + "', '" + password + "')";
            SqlHelper.InsertInto(sql2);
            string sql3 = "DELETE FROM AdminPass WHERE id = '" + id + "'";
            SqlHelper.Delete(sql3);
            string smtpServer = "smtp.qq.com"; //SMTP服务器
            string mailFrom = "330953853@qq.com"; //登陆用户名
            string userPassword = "ulldpxudytplcbee";//客户端授权码
            string mailTo = name;
            string mailSubject = "图书馆管理员申请";
            string mailContent = "恭喜，您已经成为图书馆管理员。";
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
            Response.Write("<script>alert('已通过！');window.location.href='SuperAdmin.aspx'</script>");
        }
        if(e.CommandName == "disagree")
        {

            string id = e.CommandArgument.ToString();
            string sql2 = "select * from AdminPass where id = '" + id + "'";
            DataTable dt = SqlHelper.SqlSelect(sql2);
            string name = dt.Rows[0][1].ToString();
            string sql = "DELETE FROM AdminPass WHERE id = '" + id + "'";
            SqlHelper.Delete(sql);
            string smtpServer = "smtp.qq.com"; //SMTP服务器
            string mailFrom = "330953853@qq.com"; //登陆用户名
            string userPassword = "ulldpxudytplcbee";//客户端授权码
            string mailTo = name;
            string mailSubject = "图书馆管理员申请";
            string mailContent = "抱歉，您的申请未通过，您可以继续尝试申请，或者联系图书馆负责人！";
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
            Response.Write("<script>alert('已拒绝！');window.location.href='SuperAdmin.aspx'</script>");
        }
    }

    protected void logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Write("<script>window.location.href='Default.aspx'</script>");
    }
}