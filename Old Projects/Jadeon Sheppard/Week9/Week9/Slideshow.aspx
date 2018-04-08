<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Slideshow.aspx.cs" Inherits="Week9.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <script src="slideshow.js"></script>
    <div class="Slideshow">
        <div class="Content"></div>
        <div class="Controls">
            <div>
                <div class="Fill"></div>
                <div class="Button Prev">Previous</div>
                <div class="Button Next">Next</div>
                <div class="Fill"></div>
            </div>
        </div>
    </div>

</asp:Content>
