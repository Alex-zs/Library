<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edituser.aspx.cs" Inherits="Edituser" %>

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
             查询
            <asp:DropDownList ID="usersList" runat="server" >
                <asp:ListItem Selected="True">编号</asp:ListItem>
                <asp:ListItem>邮箱</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txt" runat="server" ></asp:TextBox>
            <asp:Button ID="search" OnClick="search_Click" runat="server" Text="查找" />
            <br />  <br />  <br />  <br />
            <asp:Repeater ID="userList" runat="server" OnItemCommand="UserList_ItemCommand">
                <HeaderTemplate>
                    <table >
                        <tr>
                            <th>编号</th>
                            <th>邮箱</th>
                            <th>借书详情</th>
                            <th>删除</th>
                        </tr>

                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td> <%# Eval("readerID")%></td>
                        <td><%# Eval("name")%></td>
                        <td><asp:LinkButton ID="lendInformation" runat="server" Text="借书详情" CommandArgument='<%# Eval("readerID") %>' CommandName="lendInformation"></asp:LinkButton></td>
                        <td><asp:LinkButton ID="userDelete" runat="server" Text="删除用户"  CommandName="userDelete" CommandArgument='<%# Eval("readerID") %>'></asp:LinkButton></td>
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
            <asp:Button ID="back" runat="server" Text="返回" OnClick="back_Click" />
    
           
        </div>
    </form>
    <form id="form2" runat="server" visible="false">
        <asp:Repeater ID="user" runat="server" OnItemCommand="user_ItemCommand">
            <HeaderTemplate>
                <table>
                    <tr>
                      <th>编号</th>
                            <th>用户名</th>
                            <th>借书详情</th>
                            <th>删除</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                     <td> <%# Eval("readerID")%></td>
                        <td><%# Eval("name")%></td>
                    <td><asp:LinkButton ID="borrow" runat="server" Text="借书详情" CommandArgument='<%# Eval("readerID") %>' CommandName="borrow"></asp:LinkButton></td>
                    <td><asp:LinkButton ID="delete" runat="server" Text="删除" CommandArgument='<%# Eval("readerID") %>' CommandName="delete"></asp:LinkButton> </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        
        </asp:Repeater>
        <asp:Button ID="backtoo" runat="server" Text="返回" OnClick="backtoo_Click" />
    </form>
</body>
</html>
