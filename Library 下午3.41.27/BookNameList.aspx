<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookNameList.aspx.cs" Inherits="BookNameList" %>

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
    <form id="bookNamePage" runat="server" >
        <asp:Repeater ID="bookNameList" runat="server" OnItemCommand="BookNameList_ItemCommand">
            <HeaderTemplate>
                <table>
                   <tr>
                       <th>图书名称</th>
                       <th>作者</th>
                       <th>类别</th>
                       <th>出版社</th>
                       <th>出版时间</th>
                       <th>条形码</th>
                       <th>存放位置</th>
                       <th>借阅</th>
                   </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td> <%# Eval("bookName")%></td>
                    <td> <%# Eval("author")%></td>
                    <td><%# Eval("category") %></td>
                    <td><%# Eval("publisher") %></td>
                    <td><%# Eval("publishDate") %></td>
                    <td><%# Eval("stockNumber") %></td>
                    <td><%# Eval("bookAdress") %></td>
                    <td><asp:LinkButton ID="borrowBook" runat="server" Text="借阅" PostBackUrl='<%# "BookList.aspx?id="+Eval("BookID") %>' CommandName="borrowBook" CommandArgument='<%# Eval("BookID") %>'></asp:LinkButton></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
