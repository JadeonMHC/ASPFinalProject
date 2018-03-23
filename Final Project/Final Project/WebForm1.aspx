<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Final_Project.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="MainMap"></div>
    <script src="js/map.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCia_eDb7tJFSsjrKDZlMpHn9JGb7IIlm4&callback=initMap" type="text/javascript"></script>
    
    <div id="SideBar">
        <div id="OptionsBar">
            <!--h2>Options</!--h2-->
            <h3>Line Style</h3>
            <p>
                <input type="radio" name="lineStyle" id="solid" />
                <label for="solid">Solid</label>
            </p>
            <p>
                <input type="radio" name="lineStyle" id="dotted" />
                <label for="dotted">Dotted</label>
            </p>
        </div>
    </div>
</asp:Content>
