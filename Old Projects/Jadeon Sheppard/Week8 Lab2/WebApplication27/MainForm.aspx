<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="WebApplication27.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Entry Count</h2>
            <asp:Button ID="btnCount" runat="server" Text="Count Entries" OnClick="btnCount_Click" />
            <div><asp:Label ID="lblNumEntries" runat="server" Text=""></asp:Label></div>
        </div>
        <div>
            <h2>Get Entry</h2>
            Index: <asp:TextBox ID="txtGetBox" runat="server"></asp:TextBox>
            <asp:Button ID="btnGetEntry" runat="server" Text="Get" OnClick="btnGetEntry_Click" />
            <div><asp:Label ID="lblGetValue" runat="server" Text=""></asp:Label></div>
        </div>
        <div>
            <h2>Set Entry</h2>
            <div>Index: <asp:TextBox ID="txtSetIndex" runat="server"></asp:TextBox></div>
            <div>
                Value: <asp:TextBox ID="txtSetValue" runat="server"></asp:TextBox>
                <asp:Button ID="btnSet" runat="server" Text="Button" OnClick="btnSet_Click" />
            </div>
            <div>
                <br />
                <asp:Label ID="lblSetM" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div>
            <h2>Add Entry</h2>
            <div>
                Value: <asp:TextBox ID="txtAdd" runat="server"></asp:TextBox>
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            </div>
            <div>
                <br />
                <asp:Label ID="lblAddM" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
