<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReaderLoan.aspx.cs" Inherits="ReaderLoan" %>

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
            <asp:Repeater runat="server" ID="MyBook" OnItemCommand="MyBook_ItemCommand">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>编号</th>
                            <th>图书</th>
                            <th>借阅日期</th>
                            <th>归还日期</th>
                            <th>续借</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("bookID") %></td>
                        <td><%# Eval("bookName") %></td>
                        <td><%# Eval("loanDate") %></td>
                        <td><%# Eval("backDate") %></td>
                        <td><asp:LinkButton ID="loanAgain" runat="server" Text="续借" CommandArgument='<%# Eval("loanID") %>' CommandName="loanAgain"></asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
                </asp:Repeater>
            <br />
            <asp:Button ID="btnUp" runat="server" Text="上一页" OnClick="btnUp_Click" />
            <asp:Button ID="btnDown" runat="server" Text="下一页" OnClick="btnDown_Click" />
            <asp:Button ID="btnFirst" runat="server" Text="首页" OnClick="btnFirst_Click" />
            <asp:Button ID="btnLast" runat="server" Text="尾页" OnClick="btnLast_Click" />
            页次：
            <asp:Label ID="lbNow" runat="server" Text="1"></asp:Label>
            /<asp:Label ID="lbTotal" runat="server" Text="1"></asp:Label>
           转<asp:TextBox ID="txtJump" Text="1" Width="16px" runat="server"></asp:TextBox>
      <asp:Button ID="btnJump" Text="Go" runat="server" OnClick="btnJump_Click" />
            <asp:Button ID="back" runat="server" Text="返回" OnClick="back_Click" />
        </div>
    </form>
</body>
</html>
