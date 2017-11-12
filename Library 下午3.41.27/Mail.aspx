<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mail.aspx.cs" Inherits="Mail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>输入邮箱地址：
            <asp:TextBox ID="txtEmailAddress" runat="server"></asp:TextBox>
            <asp:Button ID="send" runat="server" OnClick="send_Click" Text="发送验证码" />
        </div>
    </form>
</body>
</html>
