<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminEdit.aspx.cs" Inherits="AdminEdit" %>

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
            <asp:Button ID="editReader" runat="server" OnClick="editReader_Click" Text="读者管理" />
            <asp:Button ID="editBook" runat="server" OnClick="editBook_Click" Text="图书管理" />
            <asp:Button ID="back" runat="server" OnClick="back_Click" Text="注销" />
            
        </div>
    </form>
</body>
</html>
