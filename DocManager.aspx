<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="DocManager.aspx.vb" Inherits="DocManager" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <br /><br /><br /><br />

    <div class="jumbotron">
          <h3 ><b>Document Management</b></h3>
        <div class="row">
             <div class="col-md-12" style="text-align:right">
                    <telerik:RadButton ID="RadButton1" runat="server" Text="Back" Skin="Office2010Black" ></telerik:RadButton>
                 </div>
       </div>
        <div class="row">
                <div class="col-md-12" style="text-align: center">
                    <telerik:RadFileExplorer runat="server" ID="RadFileExplorer1" Width="1200" Height="0px" Skin="Vista">
                    
                    </telerik:RadFileExplorer>
                 </div>
         </div>
   </div>
</asp:Content>

