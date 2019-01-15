<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="DamBookOfLife.aspx.vb" Inherits="DamBookOfLife" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type="text/javascript">
           function myClicked(val)
            {
                document.cookie = "dbo=" + val;
                window.location = "DocManager.aspx";
           };

    </script>

        <br /><br /><br /><br />

         <h2 style="text-align: center">DAM BOOK OF LIFE</h2>
         <hr style="height:3px">
   
    <div class="jumbotron">
        <h2 style="text-align: center;"><%= Session("siteSelected") %></h2>
         <div class="row">
                    <div class="col-md-3" style="text-align: center">
                         <a href="CountryOC.aspx" onclick="myClicked('1. Introduction');return false;">
                            <h3 ><b>Site Details</b></h3>
                            <asp:Image class="img-rounded" ID="Image9" ImageUrl="~/Images/DamBookOfLife/Site_Details.JPG" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
                    <div class="col-md-3" style="text-align: center">
                        <a href="CountryOC.aspx" onclick="myClicked('2. Client, Personnel and Appointments');return false;">
                            <h3 ><b>Personnel</b></h3>                        
                            <asp:Image  class="img-rounded" ID="Image10" ImageUrl="~/Images/DamBookOfLife/Personnel.png" Width="250" Height="175" runat="server" />
                        
                    </div>
                    <div class="col-md-3" style="text-align: center">
                        <a href="CountryOC.aspx" onclick="myClicked('3. Documentation');return false;">
                            <h3 ><b>Documentation</b></h3>                        
                            <asp:Image class="img-rounded" ID="Image11" ImageUrl="~/Images/Operations2.png" Width="250" Height="175" runat="server" />
                       </a>
                    </div>
                    <div class="col-md-3" style="text-align: center">
                        <a href="CountryOC.aspx" onclick="myClicked('4. Operating Plan');return false;">
                        <h3 ><b>Operating Plans</b></h3>                        
                            <asp:Image class="img-rounded" ID="Image12" ImageUrl="~/Images/DamBookOfLife/Operating_Plans.png" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
            <//div>
         <div class="row">
        </div>
         <div class="row">
                    <div class="col-md-3" style="text-align: center">
                        <a href="CountryOC.aspx" onclick="myClicked('5. Risk Control Measures');return false;">
                            <h3 ><b>Risk Control</b></h3>
                            <asp:Image class="img-rounded" ID="Image1" ImageUrl="~/Images/DamBookOfLife/Risk_Control.png" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
                    <div class="col-md-3" style="text-align: center">
                        <a href="CountryOC.aspx" onclick="myClicked('6. Management Control Measures');return false;">
                            <h3 ><b>Management Reviews</b></h3>                        
                            <asp:Image  class="img-rounded" ID="Image2" ImageUrl="~/Images/DamBookOfLife/Management.JPG" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
                    <div class="col-md-3" style="text-align: center">
                        <a href="CountryOC.aspx" onclick="myClicked('7. Potential Risk');return false;">
                            <h3 ><b>Potential Risks</b></h3>                        
                            <asp:Image class="img-rounded" ID="Image3" ImageUrl="~/Images/DamBookOfLife/Potential_Risks.JPG" Width="250" Height="175" runat="server" />
                       
                    </div>
                    <div class="col-md-3" style="text-align: center">
                        <a href="CountryOC.aspx" onclick="myClicked('8. SHEQ');return false;">
                        <h3 ><b>Sheq</b></h3>                        
                            <asp:Image class="img-rounded" ID="Image4" ImageUrl="~/Images/DamBookOfLife/Sheq.JPG" Width="250" Height="175" runat="server" />
                        </a>
                    </div>
            <//div>
    </div>
</asp:Content>

