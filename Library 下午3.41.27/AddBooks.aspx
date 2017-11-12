<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddBooks.aspx.cs" Inherits="AddBooks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            书名
            <asp:TextBox ID="bookName" runat="server" ></asp:TextBox>
            <br />
            作者
            <asp:TextBox ID="author" runat="server"></asp:TextBox>
            <br />
            类别
            <asp:DropDownList ID="category" runat="server">
                <asp:ListItem >小说</asp:ListItem>
                <asp:ListItem>文学</asp:ListItem>
                <asp:ListItem>传记</asp:ListItem>
                <asp:ListItem>书法</asp:ListItem>
                <asp:ListItem>励志与成功</asp:ListItem>
                <asp:ListItem>经济</asp:ListItem>
                <asp:ListItem>娱乐</asp:ListItem>
                <asp:ListItem>历史</asp:ListItem>
                <asp:ListItem>哲学</asp:ListItem>
                <asp:ListItem>科普读物</asp:ListItem>
                <asp:ListItem>计算机与互联网</asp:ListItem>
                <asp:ListItem>教辅</asp:ListItem>
                <asp:ListItem>字典词典</asp:ListItem>
                <asp:ListItem>杂志</asp:ListItem>
            </asp:DropDownList>
            <br />
            出版社
            <asp:TextBox ID="publisher" runat="server"></asp:TextBox>
            <br />
            出版日期
            <asp:TextBox ID="publishDate" runat="server"></asp:TextBox>
            <br />
            条形码
            <asp:TextBox ID="stockNumber" runat="server"></asp:TextBox>
            <br />
            存放地址
            <asp:TextBox ID="bookAdress" runat="server"></asp:TextBox>
            <br />
            数量
            <asp:TextBox ID="numbers" runat="server"></asp:TextBox>
            <br />
            
            <asp:Button ID="submit" runat="server" Text="提交" OnClick="submit_Click" />
            <asp:Button ID="back" runat="server" Text="返回" OnClick="back_Click" />
        </div>
    </form>
</body>
</html>
