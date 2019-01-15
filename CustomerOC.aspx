<%@ Page Title="" Language="VB" AutoEventWireup="false" CodeFile="CustomerOC.aspx.vb" Inherits="CustomerOC" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="x-ua-compatible" content="IE=11">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - Frasier Alexander</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
</head>
<body >
<form runat="server">
     <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see http://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="respond" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>

 <script>
     $(document).ready(function () {
         $(document).scrollTop(180);
     });
 </script>
<div class="container body-content">
     <div class="jumbotron">
         <h2 style="text-align: center">CUSTOMER OPERATIONS CATALOGUE</h2>
         <h3 style="text-align: center"><%= Session("optionSelected") %></h3>
           <div class="row">
            <div class="col-md-9">
                <asp:Label ID="lblCaption" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" ></asp:Label>
                <telerik:RadDropDownList DefaultMessage="Select an item" ID="RadDropDownList1" AutoPostBack="true" runat="server" DataSourceID="SqlDataSource1" Skin="Office2010Black">
                </telerik:RadDropDownList>
                 <telerik:RadDropDownList DefaultMessage="Select an item" Visible="false"  ID="RadDropDownList2" AutoPostBack="true" runat="server" DataSourceID="SqlDataSource2" Skin="Office2010Black">
                </telerik:RadDropDownList>
                <telerik:RadButton style="line-height:23px;" height="23" ID="btnDamBookOfLife" Visible="false" runat="server" Text="Dam Book Of Life" Skin="Office2010Black" ></telerik:RadButton>                
            </div>
            <div class="col-md-3" style="text-align:right">
                <telerik:RadButton ID="RadButton1" runat="server" Text="Back" Skin="Office2010Black" ></telerik:RadButton>
            </div>
         </div>
         
        <div id="MapViewer" runat="server" style="text-align:center">
                 <iframe runat="server" id="mapframe" class="mapClass"  frameborder="0" scrolling="no" marginheight="0" marginwidth="0">
                </iframe>  
         </div>

    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FAConnectionString %>" >
    </asp:SqlDataSource>
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:FAConnectionString %>" >
    </asp:SqlDataSource>
</div>
</form>
</body>

