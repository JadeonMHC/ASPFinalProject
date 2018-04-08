<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="Week4_Lab_1.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="InputContainer">
            <div>
                <asp:Label ID="Label1" CssClass="InputLabel" runat="server" Text="First Name:"></asp:Label>
                <asp:TextBox ID="txtFirst" runat="server">Steve</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirst" ErrorMessage="* First name required" Display="Dynamic" Font-Bold="False" Font-Names="Arial" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFirst" ErrorMessage="* Can only contain letters or hyphens" ValidationExpression="^[a-zA-Z-]+$" Display="Dynamic" Font-Bold="False" Font-Names="Arial" Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:Label ID="Label2" CssClass="InputLabel" runat="server" Text="Last Name:"></asp:Label>
                <asp:TextBox ID="txtLast" runat="server">Letkeman</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLast" ErrorMessage="* Last name required" Display="Dynamic" Font-Bold="False" Font-Names="Arial" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLast" ErrorMessage="* Can only contain letters or hyphens" ValidationExpression="^[a-zA-Z-]+$" Display="Dynamic" Font-Bold="False" Font-Names="Arial" Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:Label ID="Label3" CssClass="InputLabel" runat="server" Text="Address:"></asp:Label>
                <asp:TextBox ID="txtAddress" runat="server" MaxLength="40">1234 64th blvd</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAddress" ErrorMessage="* Address required" Display="Dynamic" Font-Bold="False" Font-Names="Arial" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtLast" ErrorMessage="* Can only contain letters or hyphens" ValidationExpression="^[a-zA-Z-]+$" Display="Dynamic" Font-Bold="False" Font-Names="Arial" Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:Label ID="Label4" CssClass="InputLabel" runat="server" Text="Postal Code:"></asp:Label>
                <asp:TextBox ID="txtPostCode" runat="server">T1A 0A0</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPostCode" ErrorMessage="* Postal code required" Display="Dynamic" Font-Bold="False" Font-Names="Arial" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPostCode" Display="Dynamic" ErrorMessage="* Must be in ANA NAN format" ValidationExpression="^(?!.*[DFIOQU])[A-VXY][0-9][A-Z] ?[0-9][A-Z][0-9]$" Font-Bold="False" Font-Names="Arial" Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:Label ID="Label5" CssClass="InputLabel" runat="server" Text="Phone Number:"></asp:Label>
                <asp:TextBox ID="txtPhone" runat="server">(123) 234-3456</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPhone" ErrorMessage="* Phone number required" Display="Dynamic" Font-Bold="False" Font-Names="Arial" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtPhone" ErrorMessage="* Enter a proper phone number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Display="Dynamic" Font-Bold="False" Font-Names="Arial" Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:Label ID="Label6" CssClass="InputLabel" runat="server" Text="Email:"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server">dank@memes.com</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEmail" ErrorMessage="* Email required" Display="Dynamic" Font-Bold="False" Font-Names="Arial" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtEmail" ErrorMessage="* Enter a proper email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*?\.[ca|com|net]{3}" Display="Dynamic" Font-Bold="False" Font-Names="Arial" Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:Label ID="Label7" CssClass="InputLabel" runat="server" Text="Password:"></asp:Label>
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password">I&#39;mALittleTeapot</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPass" ErrorMessage="* Password required" Display="Dynamic" Font-Bold="False" Font-Names="Arial" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtPass" ErrorMessage="* Password must be at least 6 characters long and have one uppercase and lowercase letter" ValidationExpression="^(?=.*[A-Z])(?=.*[a-z]).{6,}$" Display="Dynamic" Font-Bold="False" Font-Names="Arial" Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:Label ID="Label8" CssClass="InputLabel" runat="server" Text="Confirm Password:"></asp:Label>
                <asp:TextBox ID="txtPass2" runat="server" TextMode="Password">I&#39;mALittleTeapot</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPass2" ErrorMessage="* Confirmation required" Display="Dynamic" Font-Bold="False" Font-Names="Arial" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPass" ControlToValidate="txtPass2" Display="Dynamic" ErrorMessage="* Passwords don't match" Font-Bold="False" Font-Names="Arial" Font-Size="Smaller" ForeColor="Red"></asp:CompareValidator>
            </div>
            <div>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </form>
</body>
</html>
