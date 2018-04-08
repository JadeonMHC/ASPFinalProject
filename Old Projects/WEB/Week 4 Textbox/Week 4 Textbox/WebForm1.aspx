<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Week_4_Textbox.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Enter your name"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Age: "></asp:Label>
            <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtAge" ErrorMessage="Must be 18 or over" MaximumValue="200" MinimumValue="18" Type="Integer" Display="Dynamic"></asp:RangeValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAge" ErrorMessage="You must enter your age" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Phone: "></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPhone" ErrorMessage="Must match format (###) ###-####" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
        </div>
        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
        </div>
    </form>
</body>
</html>
