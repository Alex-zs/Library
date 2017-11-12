<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookList.aspx.cs" Inherits="BookList" %>

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
      <asp:Repeater ID="bookNameList" runat="server" OnItemCommand="bookNameList_ItemCommand1">
          <HeaderTemplate>
              <table>
                  <tr>
                       <th>书名</th>
                       <th>作者</th>
                       <th>类别</th>
                       <th>出版社</th>
                       <th>出版时间</th>
                       <th>条形码</th>
                       <th>存放位置</th>
                      <th>在库数</th>
                       <td>操作</td>
                   </tr>

          </HeaderTemplate>
          <ItemTemplate>
              <tr>
                   <td> <%# Eval("bookName")%></td>
                   <td><%# Eval("author") %></td>
                   <td><%# Eval("category") %></td>
                   <td><%# Eval("publisher") %></td>
                   <td><%# Eval("publishDate") %></td>
                   <td><%# Eval("stockNumber") %></td>
                   <td><%# Eval("bookAdress") %></td>
                  <td><%# Eval("libraryNumbers") %></td>
                   <td><asp:LinkButton ID="lendBook" runat="server" Text="借阅" CommandName="lendBook"  CommandArgument='<%# Eval("bookID") %>' ></asp:LinkButton>
              </td> </tr>
          </ItemTemplate>
          <FooterTemplate>
              </table>
          </FooterTemplate>
      </asp:Repeater>
      <br />
      <asp:Button ID="btnUp" Text="上一页" runat="server" OnClick="btnUp_Click" />
      <asp:Button ID="btnDown" Text="下一页" runat="server" OnClick="btnDown_Click" />
      <asp:Button ID="btnFirst" Text="首页" runat="server" OnClick="btnFirst_Click" />
      <asp:Button ID="btnLast" Text="尾页" runat="server" OnClick="btnLast_Click" />
      页次：<asp:Label ID="lbNow" Text="1" runat="server"></asp:Label>
      / <asp:Label ID="lbTotal" Text="1" runat="server"></asp:Label>
        转<asp:TextBox ID="txtJump" Text="1" Width="16px" runat="server"></asp:TextBox>
      <asp:Button ID="btnJump" Text="Go" runat="server" OnClick="btnJump_Click" />
      <asp:Button ID="back" runat="server" OnClick="back_Click" Text="返回" />

  </form>
    
</body>
</html>
