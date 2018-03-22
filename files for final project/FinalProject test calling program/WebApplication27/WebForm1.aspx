<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication27.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Bike" />
            <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="333px"></asp:TextBox>
        </div>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Truck" />
        <asp:TextBox ID="TextBox2" runat="server" Height="17px" Width="315px"></asp:TextBox>
    </form>
</body>
</html>
