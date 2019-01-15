<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="OperationsCatalogue.aspx.vb" Inherits="Operations" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type="text/javascript">
           function myFunction(val)
            {
                document.cookie = "region=" + val;
                window.location = "BUOC.aspx";
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
    
        <h2 style="text-align: center">OPERATIONS CATALOGUE</h2>
        <hr style="height:3px">

   <div class="jumbotron">
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Silk" SelectedIndex="0" EnableDragToReorder="True" MultiPageID="RadMultiPag1" >
            <Tabs>
                <telerik:RadTab Text="Country" Selected="True"></telerik:RadTab>
                <telerik:RadTab Text="Customer"></telerik:RadTab>
                <telerik:RadTab Text="Product Type"></telerik:RadTab>
                <telerik:RadTab Text="Manager"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPag1" CssClass="RadMultiPage" runat="server" SelectedIndex="0" ScrollBars="Auto">
            <telerik:RadPageView ID="RadPageView1" runat="server" Height="500" Style="overflow: hidden">
                <br />
                <div class="row">
                    <div class="col-md-3" style="text-align: center">
                        <a href="CountryOC.aspx" onclick="myContinent('Africa');return false;">
                            <h3 ><b>Africa</b></h3>
                            <asp:Image class="img-rounded" ID="Image1" ImageUrl="~/Images/Map1.JPG" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
                    <div class="col-md-3" style="text-align: center">
                        <a href="CountryOC.aspx" onclick="myContinent('Australia');return false;">
                            <h3 ><b>Australia</b></h3>
                            <asp:Image class="img-rounded" ID="Image2" ImageUrl="~/Images/Map1.JPG" Width="250" Height="175" runat="server" />
                        </a> 
                    </div>
                    <div class="col-md-3" style="text-align: center">
                        <a href="CountryOC.aspx" onclick="myContinent('South America');return false;">
                            <h3 ><b>South America</b></h3>
                            <asp:Image class="img-rounded" ID="Image3" ImageUrl="~/Images/Map1.JPG" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
                    <div class="col-md-3" style="text-align: center">
                        <a href="CountryOC.aspx" onclick="myContinent('Europe');return false;">                           
                            <h3 ><b>Europe</b></h3>
                            <asp:Image class="img-rounded" ID="Image4" ImageUrl="~/Images/Map1.JPG" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView2" runat="server" Height="500" Style="overflow: hidden">
                <br />
                <div class="row">
                    <div class="col-md-6" style="text-align: center">
                        <a href="CustomerOC.aspx" onclick="Customer('Anglo Gold Ashanti');return false;">
                            <h2>Anglo Gold Ashanti</h2>
                            <asp:Image class="img-rounded" ID="Image5" ImageUrl="~/Images/Customer1.JPG" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
                    <div class="col-md-6" style="text-align: center">
                        <a href="CustomerOC.aspx" onclick="Customer('Northam Platinum');return false;">
                            <h2>Northam Platinum</h2>
                            <asp:Image class="img-rounded" ID="Image6" ImageUrl="~/Images/Customer1.JPG" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView3" runat="server" Height="500" Style="overflow: hidden">
                <br />
                <div class="row">
                    <div class="col-md-4" style="text-align: center">
                        <a href="BUOC.aspx" id="northern" onclick="myFunction('Deposition');return false;">
                            <h3 ><b>Deposition</b></h3>
                            <asp:Image class="img-rounded" ID="Image9" ImageUrl="~/Images/BU1.JPG" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
                    <div class="col-md-4" style="text-align: center">
                        <a href="BUOC.aspx" onclick="myFunction('Hydro');return false;"> 
                            <h3 ><b>Hydro-Mining</b></h3>                        
                            <asp:Image  class="img-rounded" ID="Image10" ImageUrl="~/Images/BU1.JPG" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
                    <div class="col-md-4" style="text-align: center">
                        <a href="BUOC.aspx" onclick="myFunction('Water');return false;"> 
                            <h3 ><b>Water</b></h3>                        
                            <asp:Image class="img-rounded" ID="Image11" ImageUrl="~/Images/BU1.JPG" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView4" runat="server" Height="500" Style="overflow: hidden">
                <br />
                <div class="row">
                    <div class="col-md-12" style="text-align: center">
                        <telerik:RadGrid ClientSettings-EnableRowHoverStyle="true" ID="RadGrid1" runat="server" CellSpacing="-1" DataSourceID="SqlDataSource1" GridLines="Both" GroupPanelPosition="Top" Skin="Office2010Black">
                             <MasterTableView AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                 <Columns>
                                     <telerik:GridBoundColumn DataField="Business_Area_Manager" FilterControlAltText="Filter Business_Area_Manager column" HeaderText="Business Area Manager" SortExpression="Business_Area_Manager" UniqueName="Business_Area_Manager">
                                     </telerik:GridBoundColumn>
                                     <telerik:GridButtonColumn Text="Mines and Sites" HeaderText="Manager"  UniqueName="Manager" CommandName="Manager" ButtonType="PushButton"></telerik:GridButtonColumn>
                                 </Columns>
                             </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </div>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
 
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FAConnectionString %>" SelectCommand="SELECT DISTINCT [Business_Area_Manager] FROM [STRUCTURE_ALL_CENT] WHERE ([Business_Area_Manager] IS NOT NULL)"></asp:SqlDataSource>
    </div>

</asp:Content>

