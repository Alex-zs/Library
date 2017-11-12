<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv= "Pragma " content= "no-cache " />
<meta http-equiv= "Cache-Control " content= "no-cache " />
<meta http-equiv= "Expires " content= "0 " />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" visible="true">
        <div>
            用户登录<br />
            邮箱：<asp:TextBox ID = "txtUserName" runat="server" ></asp:TextBox><br />
            密码：<asp:TextBox ID ="txtUserPwd" runat="server" TextMode="Password"></asp:TextBox><br />
            验证码:<input runat="server" id="txtValidate" />  
        <img src="/ValidateCode.aspx?ValidateCodeType=1&0.011150883024061309" onclick="this.src='/ValidateCode.aspx?ValidateCodeType=1&'+Math.random();" id="imgValidateCode" alt="点击刷新验证码" title="点击刷新验证码" style="cursor: pointer;" />
            <br />
            <asp:Button ID="login" runat="server" OnClick="login_Click" Text="登录" /><br />
             <asp:Button ID="register" runat="server" OnClick="register_Click" Text="注册" />
            <asp:Button ID="findPwd" runat="server" OnClick="findPwd_Click" Text="忘记密码" />
             <asp:Button ID="adminLogin" runat="server" OnClick="adminLogin_Click" Text="管理员登录" />
           
            
        </div>
    </form>
    <form id="form2" runat="server" visible="false">
        管理员登录<br />
        邮箱：<asp:TextBox ID="adminEmail" runat="server"></asp:TextBox>
        <br />
        密码：<asp:TextBox ID="adminPwd" runat="server" TextMode="Password"></asp:TextBox>
        <br />
         验证码:<input runat="server" id="Text1" />  
        <img src="/ValidateCode.aspx?ValidateCodeType=1&0.011150883024061309" onclick="this.src='/ValidateCode.aspx?ValidateCodeType=1&'+Math.random();" id="imgValidateCode" alt="点击刷新验证码" title="点击刷新验证码" style="cursor: pointer;" />
            <br />
        <asp:Button ID="adminLogins" runat="server" Text="登录" OnClick="adminLogins_Click" />
        <asp:Button ID="back" runat="server" Text="返回" OnClick="back_Click" />
    </form>
</body>
</html>
