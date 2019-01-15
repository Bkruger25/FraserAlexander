<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Profile.aspx.vb" Inherits="Profile" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <br /><br /><br /><br />
    <h2 style="text-align: center">Bulk Upload</h2>
    <hr style="height:3px">
    <div class="jumbotron">
        <div class="row">
            <h5>How to use:</h5>
            <div class="col-md-6">                
                <ul>
                    <li><h6>Download the Excel File.</h6></li>
                    <li><h6>Fill out the columns provided in the excel table.</h6></li>
                    <li><h6>Upload the excel spreadsheet back to the system.</h6></li>
                    <li><h6>The data will be extraced and added to the map.</h6></li>
                </ul>
            </div>
            <div class="col-md-6">
                <a href="Bulk%20Data.xlsx">Excel Data Template</a> <br />
                <asp:Label ID="Label2" runat="server" Text="Please Select a file to upload:"></asp:Label>
                <telerik:RadAsyncUpload ID="RadAsyncUpload1" TemporaryFolder="~/Temp" runat="server" Skin="Silk"></telerik:RadAsyncUpload>
                <telerik:RadButton ID="btnUpload" runat="server" Text="Upload File and Add data to map" Skin="Silk"></telerik:RadButton>
            </div>
        </div>
        <asp:Label ID="Label3" ForeColor="Green" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label1" ForeColor="Green" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

