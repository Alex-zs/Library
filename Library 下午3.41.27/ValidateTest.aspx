<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValidateTest.aspx.cs" Inherits="ValidateTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">  
    <div>  
        <input runat="server" id="txtValidate" />  
        <img src="/ValidateCode.aspx?ValidateCodeType=1&0.011150883024061309" onclick="this.src='/ValidateCode.aspx?ValidateCodeType=1&'+Math.random();" id="imgValidateCode" alt="点击刷新验证码" title="点击刷新验证码" style="cursor: pointer;" />
        <asp:Button runat="server" id="btnVal" Text="提交" onclick="btnVal_Click"  />  
    </div>  
    </form>  
</body>
</html>
