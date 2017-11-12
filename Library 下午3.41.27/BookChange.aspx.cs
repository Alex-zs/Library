using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookChange : System.Web.UI.Page
{
    static SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string bookID = Request.QueryString["id"];
            string sql = "select * from Books where bookID ='" + bookID + "'";
            DataTable dt = SqlHelper.SqlSelect(sql);
            if(Request.UrlReferrer != null)
            {
                bookName.Text = dt.Rows[0][1].ToString();
                author.Text = dt.Rows[0][2].ToString();
                category.Text = dt.Rows[0][3].ToString();
                publisher.Text = dt.Rows[0][4].ToString();
                publishDate.Text = dt.Rows[0][5].ToString();
                stockNumber.Text = dt.Rows[0][6].ToString();
                bookAdress.Text = dt.Rows[0][7].ToString();
                numbers.Text = dt.Rows[0][8].ToString();
            }
            else
            {
                Response.Write("<script>alert('请不要修改页面！');window.location.href='AdminEdit.aspx'</script>");
            }
                
            
        }
        
        
    }



    protected void submit_Click(object sender, EventArgs e)
    {
        string bookID = Request.QueryString["id"];
        string sql2 = "select * from Books where bookID = '" + bookID + "'";
        DataTable dt = SqlHelper.SqlSelect(sql2);
        int bookNumber = Convert.ToInt32(dt.Rows[0][8]);
        int bookNumbers = Convert.ToInt32(dt.Rows[0][9]);
        int borrowNumber = bookNumber - bookNumbers;
        int books = Convert.ToInt32(numbers.Text) - borrowNumber;
        if(books >= 0)
        {
            string bookName1 = bookName.Text;
            string author1 = author.Text;
            string category1 = category.Text;
            string publisher1 = publisher.Text;
            string publishDate1 = publishDate.Text;
            string stockNumber1 = stockNumber.Text;
            string bookAdress1 = bookAdress.Text;
            string numbers1 = numbers.Text;
            string numbers2 = Convert.ToString(Convert.ToUInt32(numbers1) - borrowNumber);
            string libraryNumber = Convert.ToString(Convert.ToUInt32(numbers1));
            string sql = "update Books set bookName = '" + bookName1 + "',author = '" + author1 + "',category = '" + category1 + "',publisher = '" + publisher1 + "',publishDate = '" + publishDate1 + "',stockNumber = '" + stockNumber1 + "',bookAdress = '" + bookAdress1 + "',numbers = '" + numbers1 + "',libraryNumbers ='"+numbers2+"' where bookID = '" + bookID + "'";
            SqlHelper.Update(sql);
            Response.Write("<script>alert('修改成功！');window.location.href='AdminEdit.aspx'</script>");
        }
        else
        {
            Response.Write("<script>alert('修改失败，数量少于借书数！')</script>");
        }

    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("DeleteBook.aspx");
    }
}