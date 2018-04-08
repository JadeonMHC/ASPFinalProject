<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication18.WebForm2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="UserForm">
        <div id="LoginForm">
            <div>
                <asp:Label ID="Label1" runat="server" CssClass="InputLabel" Text="Username"></asp:Label>
                <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label2" runat="server" CssClass="InputLabel" Text="Password"></asp:Label>
                <asp:TextBox ID="txtLoginPass" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div id="LoginMessageArea" runat="server" class="MessageArea">
                </div>
            <div>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </div>
        </div>
        <div id="SignupForm">
            <div>
                <asp:Label ID="Label3" runat="server" CssClass="InputLabel" Text="Username"></asp:Label>
                <asp:TextBox ID="txtSignName" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label4" runat="server" CssClass="InputLabel" Text="Password"></asp:Label>
                <asp:TextBox ID="txtSignPass" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label5" runat="server" CssClass="InputLabel" Text="Confirm"></asp:Label>
                <asp:TextBox ID="txtSignPass2" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div id="SignupMessageArea" runat="server" class="MessageArea">
            </div>
            <div>
                <asp:Button ID="btnSignup" runat="server" Text="Signup" OnClick="btnSignup_Click" />
            </div>
        </div>
    </div>
</asp:Content>
