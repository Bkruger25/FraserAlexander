<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="OperationsStatus.aspx.vb" Inherits="OperationsStatus" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <script type="text/javascript">
           function Flags(val)
            {
                document.cookie = "flags=" + val;
                window.location = "FlaggedDamsOS.aspx";
           };
           function myContinent(val) {
               document.cookie = "continent=" + val;
               window.location = "CountryOC.aspx";
           };
           function Manager(val) {
               document.cookie = "manager=" + val;
               window.location = "ManagerOC.aspx";
           };
           function Customer(val) {
               document.cookie = "customer=" + val;
               window.location = "CustomerOC.aspx";
           };

    </script>
     <br /><br /><br /><br />
     
          <h2 style="text-align: center">OPERATIONS STATUS</h2>
        <hr style="height:3px">

        <div class="jumbotron">

         <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Silk" SelectedIndex="0" EnableDragToReorder="True" MultiPageID="RadMultiPag1" >
            <Tabs>
                <telerik:RadTab Text="Flagged Dams" Selected="True"></telerik:RadTab>
                <telerik:RadTab Text="Incidents"></telerik:RadTab>
                <telerik:RadTab Text="Risk Levels"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>

         <telerik:RadMultiPage ID="RadMultiPag1" CssClass="RadMultiPage" runat="server" SelectedIndex="0" ScrollBars="Auto">
            <telerik:RadPageView ID="RadPageView1" runat="server" Height="500" Style="overflow: hidden">
                <br />
                <div class="row">
                    <div class="col-md-3" style="text-align: center">
                         <a href="FlaggedDamsOS.aspx" onclick="Flags('1');return false;">
                            <h3 ><b>A - F</b></h3>
                            <asp:Image class="img-rounded" ID="Image1" ImageUrl="~/Images/Land1.JPG" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
                    <div class="col-md-3" style="text-align: center">
                        <a href="FlaggedDamsOS.aspx" onclick="Flags('2');return false;">
                            <h3 ><b>G - L</b></h3>
                            <asp:Image  class="img-rounded" ID="Image2" ImageUrl="~/Images/Land2.JPG" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
                    <div class="col-md-3" style="text-align: center">
                        <a href="FlaggedDamsOS.aspx" onclick="Flags('3');return false;">
                            <h3 ><b>M - S</b></h3>
                            <asp:Image  class="img-rounded" ID="Image3" ImageUrl="~/Images/Land3.JPG" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
                    <div class="col-md-3" style="text-align: center">
                        <a href="FlaggedDamsOS.aspx" onclick="Flags('4');return false;">
                            <h3 ><b>T - Z</b></h3>
                            <asp:Image class="img-rounded" ID="Image4" ImageUrl="~/Images/Land4.JPG" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView2" runat="server" Height="500" Style="overflow: hidden">
                <br />
                <div class="row">
                    <div class="col-md-4" style="text-align: center">
                        <a href="Incidents.aspx">
                            <h3 ><b>Severe</b></h3>
                            <asp:Image ID="Image5" ImageUrl="~/Images/red.JPG" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
                    <div class="col-md-4" style="text-align: center">
                        <a href="Incidents.aspx">
                            <h3 ><b>Moderate</b></h3>
                            <asp:Image ID="Image6" ImageUrl="~/Images/yellow.JPG" Width="250" Height="175" runat="server" />
                        </a> 
                    </div>
                    <div class="col-md-4" style="text-align: center">
                        <a href="Incidents.aspx">
                            <h3 ><b>Good</b></h3>
                            <asp:Image ID="Image7" ImageUrl="~/Images/green.JPG" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView3" runat="server" Height="500" Style="overflow: hidden">
                <br />
                <div class="row">
                    <div class="col-md-4" style="text-align: center">
                        <a href="Risks.aspx">
                            <h3 ><b>Critical</b></h3>
                            <asp:Image ID="Image8" ImageUrl="~/Images/red.JPG" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
                    <div class="col-md-4" style="text-align: center">
                        <a href="Risks.aspx">
                            <h3 ><b>Alert</b></h3>
                            <asp:Image ID="Image9" ImageUrl="~/Images/yellow.JPG" Width="250" Height="175" runat="server" />
                        </a> 
                    </div>
                    <div class="col-md-4" style="text-align: center">
                        <a href="Risks.aspx">
                            <h3 ><b>Acceptable</b></h3>
                            <asp:Image ID="Image10" ImageUrl="~/Images/green.JPG" Width="250" Height="175" runat="server" />
                        </a> 
                    </div>
                </div>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
     </div>
</asp:Content>

