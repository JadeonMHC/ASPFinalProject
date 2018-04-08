<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Final_Project.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/graph.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="MainMap"></div>
    <script src="js/map.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCia_eDb7tJFSsjrKDZlMpHn9JGb7IIlm4&callback=initMap" type="text/javascript"></script>
    
    <div id="SideBar">
        <div id="OptionsBar">
            <h3>Line Style</h3>
            <p>
                <input type="radio" name="lineStyle" value="solid" checked="checked" />
                <label for="solid">Solid</label>
            </p>
            <p>
                <input type="radio" name="lineStyle" value="dashed" />
                <label for="dashed">Dashed</label>
            </p>
        </div>
        <div id="DBList">
            <h3>Live Data</h3>
            <div>
                <input type="text" id="txtLiveAddr" value="localhost:28183" />
            </div>
            <div>
                <input type="button" id="btnLive" value="Connect" />
            </div>
            <h3>Current Data</h3>
            <div id="txtCurr"></div>
            <h3>Uploaded Files</h3>
            <div id="pnlFiles"></div>
        </div>
        <div id="gphHolder">
            <canvas id="gphMain"></canvas>
            <canvas id="gphOverlay"></canvas>
        </div>
    </div>
</asp:Content>
