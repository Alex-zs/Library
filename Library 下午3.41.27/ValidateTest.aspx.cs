using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ValidateTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnVal_Click(object sender, EventArgs e)
    {
        bool result = false;   //验证结果  
        string userCode = this.txtValidate.Value; //获取用户输入的验证码  
        if (String.IsNullOrEmpty(userCode))
        {
            //请输入验证码  
            return;
        }

        string validCode = this.Session["CheckCode"] as String;  //获取系统生成的验证码  
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
    }
}