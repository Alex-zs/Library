<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteBook.aspx.cs" Inherits="DeleteBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" visible="true">
        <div>
            <asp:DropDownList ID="delete" runat="server">
                <asp:ListItem Selected="True">书名</asp:ListItem>
                <asp:ListItem>作者</asp:ListItem>
                <asp:ListItem>类别</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="books" runat="server"></asp:TextBox>
            <asp:Button ID="search" OnClick="search_Click" Text="查找" runat="server" />
            <asp:Button ID="back2" OnClick="back2_Click" Text="返回" runat="server" />
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>书名</th>
                        <th>作者</th>
                        <th>类别</th>
                        <th>出版社</th>
                        <th>出版时间</th>
                        <th>条形码</th>
                        <th>存放地址</th>
                        <th>数量</th>
                        <th>修改</th>
                        <th>删除</th>
                    </tr>
                
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("bookName") %></td>
                    <td><%# Eval("author") %></td>
                    <td><%# Eval("category") %></td>
                    <td><%# Eval("publisher") %></td>
                    <td><%# Eval("publishDate") %></td>
                    <td><%# Eval("stockNumber") %></td>
                    <td><%# Eval("bookAdress") %></td>
                    <td><%# Eval("numbers") %></td>
                    <td><asp:LinkButton ID="change" runat="server" Text="修改" PostBackUrl='<%# "BookChange.aspx?id="+Eval("bookID") %>' CommandName="change"  CommandArgument='<%# Eval("bookID") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="delete" runat="server" Text="删除" CommandName="delete" CommandArgument='<%# Eval("bookID") %>'></asp:LinkButton></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
            <br />
            <asp:Button ID="btnUp" runat="server" OnClick="btnUp_Click" Text="上一页" />
            <asp:Button ID="btnDown" runat="server" Text="下一页" OnClick="btnDown_Click" />
            <asp:Button ID="btnFirst" runat="server" Text="首页" OnClick="btnFirst_Click" />
            <asp:Button ID="btnLast" runat="server" Text="尾页" OnClick="btnLast_Click" />
            页次：
            <asp:Label ID="lbNow" Text="1" runat="server"></asp:Label>
            /<asp:Label ID="lbTotal" Text="1" runat="server"></asp:Label>
            转<asp:TextBox ID="txtJump" Text="1" Width="16px" runat="server"></asp:TextBox>
      <asp:Button ID="btnJump" Text="Go" runat="server" OnClick="btnJump_Click" />
            <asp:Button ID="Button1" runat="server" Text="返回" OnClick="back_Click" />
    
        </div>
    </form>
    <form id="form2" runat="server" visible="false">
        <asp:Repeater ID="deleteBook" runat="server" OnItemCommand="deleteBook_ItemCommand">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>书名</th>
                        <th>作者</th>
                        <th>类别</th>
                        <th>出版社</th>
                        <th>出版时间</th>
                        <th>条形码</th>
                        <th>存放地址</th>
                        <th>数量</th>
                        <th>修改</th>
                        <th>删除</th>
                    </tr>
                
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("bookName") %></td>
                    <td><%# Eval("author") %></td>
                    <td><%# Eval("category") %></td>
                    <td><%# Eval("publisher") %></td>
                    <td><%# Eval("publishDate") %></td>
                    <td><%# Eval("stockNumber") %></td>
                    <td><%# Eval("bookAdress") %></td>
                    <td><%# Eval("numbers") %></td>
                    <td><asp:LinkButton ID="change" runat="server" Text="修改" PostBackUrl='<%# "BookChange.aspx?id="+Eval("bookID") %>' CommandName="change"  CommandArgument='<%# Eval("bookID") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="delete" runat="server" Text="删除" CommandName="delete" CommandArgument='<%# Eval("bookID") %>'></asp:LinkButton></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <br />
        <asp:Button ID="back" Text="返回" OnClick="back_Click" runat="server" />
    </form>
</body>
</html>
