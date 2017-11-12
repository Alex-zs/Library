<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SuperAdmin.aspx.cs" Inherits="SuperAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>管理员申请</h2>
            <asp:Repeater ID="admin" runat="server" OnItemCommand="admin_ItemCommand">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>邮箱</th>
                            <th>密码</th>
                            <th>备注</th>
                            <th>操作</th>
                            <th>操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("name") %></td>
                        <td><%# Eval("password") %></td>
                        <td><%# Eval("remark") %></td>
                        <td>
                            <asp:LinkButton ID="agree" runat="server" Text="同意" CommandName="agree" CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="disagree" runat="server" Text="拒绝" CommandArgument='<%# Eval("id") %>' CommandName="disagree" ></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <br />
            <asp:Button ID="logout" runat="server" Text="注销" OnClick="logout_Click" />

        </div>
    </form>
</body>
</html>
