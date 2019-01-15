
Partial Class Risks
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim query As String

        query = "select distinct Mine from STRUCTURE_ALL_CENT where Mine is not null group by Mine"

        getList(query, "Mine", "Mine", 1)
        lblCaption.Text = "Please Select a Mine: "
        MapViewer.Visible = True
        mapframe.Src = "fat/index.html"
    End Sub

    Protected Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        Session.Clear()
        Response.Redirect("OperationsStatus.aspx")
    End Sub

    Protected Sub RadDropDownList1_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.DropDownListEventArgs) Handles RadDropDownList1.SelectedIndexChanged
        Dim query As String

        RadDropDownList1.Visible = False
        RadDropDownList2.Visible = True
        Session("mineSelected") = RadDropDownList1.SelectedValue
        query = "select distinct Site_TSF_Name from STRUCTURE_ALL_CENT where Mine = '" & RadDropDownList1.SelectedValue & "'"

        getList(query, "Site_TSF_Name", "Site_TSF_Name", 2)
        lblCaption.Text = "Please Select a Site: "
        MapViewer.Visible = True
        mapframe.Src = "fat/index.html"

    End Sub

    Protected Sub RadDropDownList2_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.DropDownListEventArgs) Handles RadDropDownList2.SelectedIndexChanged

        Session("siteSelected") = RadDropDownList1.SelectedValue
        mapframe.Src = "fat/index.html"
        btnDamBookOfLife.Visible = True
    End Sub


    Protected Sub btnDamBookOfLife_Click(sender As Object, e As EventArgs) Handles btnDamBookOfLife.Click
        Response.Redirect("DamBookOfLife.aspx")
    End Sub

    Protected Sub getList(query As String, dataField As String, dataValue As String, sql As Integer)

        If sql = 1 Then
            SqlDataSource1.SelectCommand = query
            RadDropDownList1.DataTextField = dataField
            RadDropDownList1.DataValueField = dataValue
        ElseIf sql = 2 Then
            SqlDataSource2.SelectCommand = query
            RadDropDownList2.DataTextField = dataField
            RadDropDownList2.DataValueField = dataValue
        End If
    End Sub

End Class
