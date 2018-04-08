<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Week10.Main" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta charset='utf-8' />
        <title></title>
        
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
        <script src="js/main.js"></script>

        <link href="css/main.css" rel="stylesheet" />
        <link href="css/calendar.css" rel="stylesheet" />
        <link href="css/sidebar.css" rel="stylesheet" />
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="PageDivider">
                <asp:Calendar ID="MainCalendar" runat="server"></asp:Calendar>
                <div id="Sidebar"></div>
            </div>
        </form>
    </body>
</html>
