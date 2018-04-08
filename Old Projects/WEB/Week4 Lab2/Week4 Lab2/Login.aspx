<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Week4_Lab2.Login" MasterPageFile="~/Site1.Master" %>


<script runat="server">
    protected void Authenticate(object sender, AuthenticateEventArgs e)
    {
        if (MainLogin.UserName == "CptAwesome" && MainLogin.Password == "password")
            FormsAuthentication.RedirectFromLoginPage(MainLogin.UserName, MainLogin.RememberMeSet);
    }
</script>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Login ID="MainLogin" runat="server" OnAuthenticate="Authenticate"></asp:Login>
        <b>Password:</b> password
    </div>
</asp:Content>
