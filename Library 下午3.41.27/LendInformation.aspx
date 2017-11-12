<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LendInformation.aspx.cs" Inherits="LendInformation" %>

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
           
            <h2>
            用户编号：
           <asp:Label ID="readerID" runat="server"></asp:Label>
                </h2>
            <h2>
                邮箱：
               <asp:Label ID="readerEmail" runat="server"></asp:Label>
            </h2>
            <h3>拥有的书籍:</h3>

        <asp:Repeater ID="books" runat="server" OnItemCommand="books_ItemCommand">

                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>书名</th>
                            <th>操作</th>
                        </tr>
                   
                </HeaderTemplate>
                <ItemTemplate>
                   <tr> 
                       <td><%# Eval("bookName") %></td>
                       <td><asp:LinkButton ID="backBook" runat="server" Text="归还" CommandName="backBook" CommandArgument='<%# Eval("loanID") %>' ></asp:LinkButton></td>
                       </tr>
                </ItemTemplate>
                <FooterTemplate>
                     </table>
                </FooterTemplate>
            </asp:Repeater>
              
            <asp:Button ID="back" runat="server" OnClick="back_Click" Text="返回" />
        </div>
    </form>
</body>
</html>
