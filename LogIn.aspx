<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="LogIn.aspx.vb" Inherits="LogIn" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <br /><br /><br /><br />
    <div class="jumbotron">
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
            </div>
            <div class="col-md-9">
                <telerik:RadTextBox ID="txtUname" Skin="Silk" runat="server"></telerik:RadTextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
            </div>
            <div class="col-md-9">
                <telerik:RadTextBox ID="txtPass"  runat="server" Skin="Silk" TextMode="Password"></telerik:RadTextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <telerik:RadButton ID="btnLogin" runat="server" Text="Login" Skin="Silk"></telerik:RadButton>
            </div>
            <div class="col-md-9">
                 <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

