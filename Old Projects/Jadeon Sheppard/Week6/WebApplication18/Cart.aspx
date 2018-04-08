<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebApplication18.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <asp:GridView ID="GridView1" runat="server" Width="538px">
            </asp:GridView>
        </div>
        <div class="GTL">
            <asp:Label ID="Label1" runat="server" Text="GRAND TOTAL: "></asp:Label>
            <asp:Label ID="lblGrandTotal" runat="server" Text="0"></asp:Label>
            <img src="img/emerald.png" height="20" style="margin-left: -5px;" />
        </div>
    </div>
</asp:Content>
