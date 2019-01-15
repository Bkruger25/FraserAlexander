Imports Telerik.Web.UI

Partial Class Operations
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("BU") = ""
    End Sub



    Protected Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
        Session("manager") = item("Business_Area_Manager").Text
        Response.Redirect("ManagerOC.aspx")
    End Sub
End Class
