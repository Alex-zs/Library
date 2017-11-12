<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditBook.aspx.cs" Inherits="EditBook" %>

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
            <asp:Button ID="addBook" runat="server" Text="增加图书" OnClick="addBook_Click" />
            <asp:Button ID="deleteBook" runat="server" Text="编辑图书" OnClick="deleteBook_Click" />
            <br />
            <asp:Button ID="back" runat="server" Text="返回" OnClick="back_Click" />
        </div>
    </form>
</body>
</html>
