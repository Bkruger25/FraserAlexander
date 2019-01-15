<%@ Page Title="About" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.vb" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>

    <iframe width="500" height="400" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" 
        src="fat/index.html"
    </iframe>
     <script type="text/javascript" src="brett.js"></script>
</asp:Content>
