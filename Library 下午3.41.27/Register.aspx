<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

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
    <form id="form1" runat="server" visible ="true">
        <div>
            使用邮箱注册<br />
            邮箱：<asp:TextBox ID ="userName" runat="server" ></asp:TextBox><br />
            密码：<asp:TextBox ID ="userPwd" runat="server" TextMode="Password"></asp:TextBox><br />
            确认密码：<asp:TextBox ID ="userPwds" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button runat="server" id="btnVal" Text="发送验证码" onclick="btnVal_Click"  />  
            <asp:Button ID="adminRegister" runat="server" Text="管理员注册" OnClick="adminRegister_Click" />

                  </div>
    </form>
    <form id="form2" runat="server" visible="false">
        验证码：
        <asp:TextBox ID="validateCode" runat="server"></asp:TextBox>
        <asp:Button ID="register" runat="server" Text="注册" OnClick="register_Click" />      
    </form>
    <form id="form3" runat="server" visible="false">
        管理员注册<br />
            邮箱：<asp:TextBox ID ="adminEmail" runat="server" ></asp:TextBox><br />
            密码：<asp:TextBox ID ="adminPwd" runat="server" TextMode="Password"></asp:TextBox><br />
            确认密码：<asp:TextBox ID ="adminPwds" runat="server" TextMode="Password"></asp:TextBox><br />
            备注:<asp:TextBox ID="remarks" runat="server" ></asp:TextBox><br />
             <asp:Button ID="send" runat="server" Text="发送验证码" OnClick="send_Click" />
    </form>
    <form id="form4" runat="server" visible="false" >
        验证码：
        <asp:TextBox ID="adminValidateCode" runat="server"></asp:TextBox>
        <asp:Button ID="adminApplication" runat="server" Text="申请" OnClick="adminRegister_Click1" />
    </form>
</body>
</html>
