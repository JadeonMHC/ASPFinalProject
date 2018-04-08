 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication19.WebForm1" %>

<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <cc1:GMap ID="GMap1" runat="server" Height="600px" Width="800px" />
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Part 1" />
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Part 2" />
        </p>
    </form>
</body>
</html>
