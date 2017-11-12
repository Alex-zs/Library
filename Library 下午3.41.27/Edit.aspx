<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Edit" %>

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
    <form id="form1" runat="server">
        <div>
            你好，欢迎你的到来。
            <asp:Button ID="Change" runat="server" OnClick="Change_Click" Text="修改密码" />
            <asp:Button ID="Find" runat="server" OnClick="Find_Click" Text="找回密码" />
            <asp:Button ID="borrow" runat="server" OnClick="borrow_Click" Text="借阅图书" />
            <asp:Button ID="search" runat="server" OnClick="search_Click" Text="我的图书" />
            <asp:Button ID="logout" runat="server" OnClick="logout_Click" Text="注销" />
        </div>
    </form>
</body>
</html>
