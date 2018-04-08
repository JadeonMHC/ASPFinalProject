﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="_01___Calulator.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="HeadElement" runat="server">
    <script src="https://code.jquery.com/jquery-3.2.1.min.js" integrity="sha256-hwg4gsxgFZhOsEEamdOYGBf13FyQuiTwlAQgxVSNgt4=" crossorigin="anonymous"></script>
    <link href="main.css" rel="stylesheet" />
    <title></title>
</head>
<body id="body" runat="server">
    <form id="MainForm" runat="server">
         <div>
             
            <asp:Image ID="imgBanner" runat="server" />
         </div>
        <div>
            <asp:TextBox ID="txtInput" runat="server">0</asp:TextBox>
        </div>
        <div>
            <asp:Button class="CalcButton" ID="btn7" runat="server" Text="7" OnClick="NumButton_Click" />
            <asp:Button class="CalcButton" ID="btn8" runat="server" Text="8" OnClick="NumButton_Click" />
            <asp:Button class="CalcButton" ID="btn9" runat="server" Text="9" OnClick="NumButton_Click" />
            <asp:Button class="CalcButton" ID="btnAdd" runat="server" Text="+" OnClick="OpButton_Click" />
        </div>
        <div>
            <asp:Button class="CalcButton" ID="btn4" runat="server" Text="4" OnClick="NumButton_Click" />
            <asp:Button class="CalcButton" ID="btn5" runat="server" Text="5" OnClick="NumButton_Click" />
            <asp:Button class="CalcButton" ID="btn6" runat="server" Text="6" OnClick="NumButton_Click" />
            <asp:Button class="CalcButton" ID="btnSub" runat="server" Text="-" OnClick="OpButton_Click" />
        </div>
        <div>
            <asp:Button class="CalcButton" ID="btn1" runat="server" Text="1" OnClick="NumButton_Click" />
            <asp:Button class="CalcButton" ID="btn2" runat="server" Text="2" OnClick="NumButton_Click" />
            <asp:Button class="CalcButton" ID="btn3" runat="server" Text="3" OnClick="NumButton_Click" />
            <asp:Button class="CalcButton" ID="btnMul" runat="server" Text="*" OnClick="OpButton_Click" />
        </div>
        <div>
            <asp:Button class="CalcButton" ID="btnSign" runat="server" Text="+/-" />
            <asp:Button class="CalcButton" ID="btn0" runat="server" Text="0" OnClick="NumButton_Click" />
            <asp:Button class="CalcButton" ID="btnDec" runat="server" Text="." OnClick="NumButton_Click" />
            <asp:Button class="CalcButton" ID="btnDiv" runat="server" Text="/" OnClick="OpButton_Click" />
        </div>
        <div>
            <asp:Button class="CalcButton" ID="btnClear" runat="server" Text="C" OnClick="btnClear_Click" />
            <asp:Button class="CalcButton" ID="btnEqual" runat="server" Text="=" OnClick="btnEqual_Click" />
        </div>
        <div>
            <asp:Button ID="btnBliss" runat="server" Text="Bliss" OnClick="btnBliss_Click" />
            <asp:Button ID="btnCube" runat="server" Text="Cube" OnClick="btnCube_Click" />
            <asp:Button ID="btnBatman" runat="server" Text="BATMAN" OnClick="btnBatman_Click" />
        </div>
    </form>
</body>
</html>
