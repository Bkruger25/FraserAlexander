<%@ Page Language="VB" AutoEventWireup="false" CodeFile="deleteMe.aspx.vb" Inherits="deleteMe" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="x-ua-compatible" content="IE=11">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - Frasier Alexander</title>
    <style>
    /* unvisited link */
    a:link {
    color: #000000;
    }

    /* visited link */
    a:visited {
    color: #808080;
    }

    /* mouse over link */
    a:hover {
    color: #ff0000;
    }

    /* selected link */
    a:active {
    color: #9d3838;
    }
</style>
</head>
<body >
<form runat="server">
    <a runat="server" href="Default.aspx"><h3  style="margin-left:375px" >Home</h3></a>
    <br />
    <div style="text-align:center">
     <iframe width="1175" height="800" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" 
        src="http://giscoe1.maps.arcgis.com/apps/webappviewer/index.html?id=5321aa2d3bac46daa954b03140d2805b&amp;extent=6.4121,-39.2315,52.3789,-16.8878&amp;zoom=true&amp;scale=true&amp;theme=light">
    </iframe>
    </div>
</form>
</body>
</html>
