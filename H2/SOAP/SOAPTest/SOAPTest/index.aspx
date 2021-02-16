<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SOAPTest.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Test" />
            <asp:Button ID="Button2" runat="server" CssClass="margin-left: 10px;" OnClick="Button2_Click" Text="Hello" />
        </div>
        <asp:TextBox ID="TextBox1" runat="server">Click the button</asp:TextBox>
    </form>
</body>
</html>
