<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="Final_Project.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #Cont {
            padding-top: 25px;
            width: 100vw;
            text-align: center;
        }

        #PageBox {
            display: inline-block;
            width: 600px;
            text-align: left;
        }

        p {
            text-indent: 30px;
        }

        p:not(:last-child) {
            margin-bottom: 15px;
        }

        h3 {
            text-align: center;
            margin-bottom: 15px;
        }

        img {
            width: 300px;
            float: right;

            margin-left: 20px;
            margin-bottom: 20px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="Cont">
        <div id="PageBox">
            <h3>About</h3>
            <img src="img/Jadeon.jpg" />
            <p>This amazing website was developed by the incredible Jadeon Sheppard using mostly jQuery (because ASP is generally not good). Jadeon is a sharp dresser and good at spehlling. He also loves to wake surf, play piano shaped objects, and eat food that doesn't include Apple products. He is also secretly an android.</p>
            <p>jQuery is a library written in javascript that allows for very easy querying and modification of the DOM, as well as sending and receiving data from the server. It is very good and superior to ASP's offerings. It's also a lot easier to use.</p>
            <p>Brother was a joint effort between Jadeon and no one else to create the perfect and easy to use system to track people's mobile devices, cars, and even the microchip implanted in all of us by the one world government. It uses web technologies, it uses the best web technologies. It's tremendous, belive me!</p>
        </div>
    </div>
</asp:Content>
