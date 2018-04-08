<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListBox ID="ListBox1" runat="server" Height="254px" OnLoad="ListBox1_Load" Width="295px"></asp:ListBox>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Application" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Viewstate" />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Session" />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </form>
</body>
</html>
