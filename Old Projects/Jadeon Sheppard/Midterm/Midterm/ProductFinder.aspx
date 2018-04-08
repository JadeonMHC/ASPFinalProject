<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="ProductFinder.aspx.cs" Inherits="Midterm.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Title"><h1>Product Finder</h1></div>
    <div class="ProductFinderBox">
        <div>Product ID:</div>
        <div>
            <asp:TextBox ID="txtProductID" runat="server" Width="250px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                runat="server" 
                ControlToValidate="txtProductID" 
                ErrorMessage="ProductID must match form: LLLL-NNNN and can't include D, I, O, or Q." ValidationExpression="^[A-CE-HJ-NPR-Z]{4}[-.][0-9]{4}$"></asp:RegularExpressionValidator>
        </div>
        <div runat="server" id="SubmitArea">
        </div>
    </div>
</asp:Content>
