<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BorrowBook.aspx.cs" Inherits="BorrowBook" %>

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
    <form id="form1" runat="server" >
        <div>
          
       
        <asp:DropDownList ID="dropList" runat="server">
            <asp:ListItem Selected="True">书名</asp:ListItem>
            <asp:ListItem>作者</asp:ListItem>
            <asp:ListItem>类别</asp:ListItem>
        </asp:DropDownList>
            <asp:TextBox ID="btnBook" runat="server"></asp:TextBox>
            <asp:Button ID="search" runat="server" Text="查找" OnClick="search_Click" />
            <br />
            <asp:Button ID="back" runat="server" OnClick="back_Click" Text="返回" />
             </div>
    </form>
   
   
</body>
</html>
