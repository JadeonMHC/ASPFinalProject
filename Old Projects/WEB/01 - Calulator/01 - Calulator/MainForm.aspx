<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="_01___Calulator.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="main.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="MainForm" runat="server">
        <div>
            <asp:TextBox ID="txtInput" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button class="CalcButton" ID="btn7" runat="server" Text="7" OnClick="NumButton_Click" />
            <asp:Button class="CalcButton" ID="btn8" runat="server" Text="8" OnClick="NumButton_Click" />
            <asp:Button class="CalcButton" ID="btn9" runat="server" Text="9" OnClick="NumButton_Click" />
        </div>
        <div>
            <asp:Button class="CalcButton" ID="btn4" runat="server" Text="4" OnClick="NumButton_Click" />
            <asp:Button class="CalcButton" ID="btn5" runat="server" Text="5" OnClick="NumButton_Click" />
            <asp:Button class="CalcButton" ID="btn6" runat="server" Text="6" OnClick="NumButton_Click" />
        </div>
        <div>
            <asp:Button class="CalcButton" ID="btn1" runat="server" Text="1" OnClick="NumButton_Click" />
            <asp:Button class="CalcButton" ID="btn2" runat="server" Text="2" OnClick="NumButton_Click" />
            <asp:Button class="CalcButton" ID="btn3" runat="server" Text="3" OnClick="NumButton_Click" />
        </div>
        <div>
            <asp:Button class="CalcButton" ID="btnSign" runat="server" Text="+/-" />
            <asp:Button class="CalcButton" ID="btn0" runat="server" Text="0" OnClick="NumButton_Click" />
            <asp:Button class="CalcButton" ID="btnDec" runat="server" Text="." OnClick="NumButton_Click" />
        </div>
    </form>
</body>
</html>
