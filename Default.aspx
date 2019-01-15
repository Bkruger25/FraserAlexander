<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br /><br /><br />
    <div class="jumbotron">        
        <div class="row">
            <div class="col-md-6" style="text-align: center">
                 <a href="OperationsCatalogue.aspx">
                    <h3 ><b>OPERATIONS CATALOGUE</b></h3>
                    <asp:Image ID="Image3" class="img-rounded" ImageUrl="~/Images/Resize/Operations.png" Width="250" Height="175" runat="server" />
                </a>
            </div>
            <div class="col-md-6" style="text-align: center">
                 <a href="OperationsStatus.aspx">
                    <h3 ><b>OPERATIONS STATUS</b></h3>
                    <asp:Image ID="Image4" class="img-rounded" ImageUrl="~/Images/Resize/Status.png" Width="250" Height="175" runat="server" />
                </a>
            </div>
        </div>
    </div>

    </asp:Content>
