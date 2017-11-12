using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddBooks : System.Web.UI.Page
{
    static SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        string bookNames = bookName.Text;
        string authors = author.Text;
        string categorys = category.SelectedValue;
        string publishers = publisher.Text;
        string publishDates = publishDate.Text;
        string stockNumbers = stockNumber.Text;
        string bookAdresss = bookAdress.Text;
        string numberss = numbers.Text;
        string sql = "insert into Books values('" + bookNames + "','" + authors + "','" + categorys + "','" + publishers+ "','" + publishDates + "','" + stockNumbers + "','"+ bookAdresss +"','"+ numberss +"','"+ numberss +"' )";
        SqlHelper.InsertInto(sql);
        Response.Write("<script>alert('增加成功！');window.location.href='AdminEdit.aspx'</script>");



    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditBook.aspx");
    }
}