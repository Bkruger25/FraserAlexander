
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.Web.UI.DropDownListItem


Partial Class CustomerOC
    Inherits System.Web.UI.Page


    Dim myConn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("FAConnectionString").ConnectionString)
    Dim myConn2 As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("FAConnectionString2").ConnectionString)
    Private Property cmd As SqlCommand
    Dim rdr As SqlDataReader


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim query As String
        Dim customer As String

        customer = Request.Cookies("customer").Value
        Session("optionSelected") = customer

        query = "select distinct [Business_Area_Manager], Mine from [STRUCTURE_ALL_CENT] where [Business_Area_Manager] IS NOT NULL and Client = '" & customer & "' ORDER BY Mine"
        getList(query, "Mine", "Mine", 1)
        mapframe.Src = "fat/index.html"

    End Sub

    Protected Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        Session.Clear()
        Response.Redirect("OperationsCatalogue.aspx")
    End Sub


    Protected Sub RadDropDownList1_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.DropDownListEventArgs) Handles RadDropDownList1.SelectedIndexChanged
        Dim query As String
        Dim customer As String
        Dim lat, lng As String
        Dim e_w, n_s As String

        myConn.Open()
        query = "SELECT * FROM [STRUCTURE_ALL_CENT] WHERE [Mine] = '" & RadDropDownList1.SelectedValue & "'"
        cmd = New SqlCommand(query, myConn)
        rdr = cmd.ExecuteReader()
        If rdr.HasRows Then
            Do While rdr.Read
                lat = rdr.Item("Centroid_S_N")
                lat = Val(Left(lat, InStr(lat, " "))) + Val((Mid(lat, InStr(lat, " ") + 1, 2))) / 60 + Val(Right(lat, InStrRev(lat, " "))) / 3600
                lng = rdr.Item("Centroid_E_W")
                lng = Val(Left(lng, InStr(lng, " "))) + Val(Mid(lng, InStr(lng, " ") + 1, 2)) / 60 + Val(Right(lng, InStrRev(lng, " "))) / 3600
                e_w = rdr.Item("SiteCoOrdsCentroid_EorW")
                n_s = rdr.Item("SiteCoOrdsCentroid_S_N")
            Loop
            mapframe.Src = "fat/index.html?zoom=yes&zoomtype=mine&lng=" & lng & "&lat=" & lat
        End If
        myConn.Close()

        Session("mineSelected") = RadDropDownList1.SelectedValue
        Session("optionSelected") = RadDropDownList1.SelectedValue
        customer = Request.Cookies("customer").Value
        query = "select distinct  Mine, Site_TSF_Name from [STRUCTURE_ALL_CENT] where [Business_Area_Manager] IS NOT NULL and Client = '" & customer & "' ORDER BY Site_TSF_Name"
        getList(query, "Site_TSF_Name", "Site_TSF_Name", 2)
    End Sub

    Protected Sub RadDropDownList2_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.DropDownListEventArgs) Handles RadDropDownList2.SelectedIndexChanged

        Dim returnData As String
        Dim returnValue As String
        Dim query As String
        Dim lat, lng As String
        Dim n_s As String
        Dim e_w As String

        returnData = RadDropDownList2.DataTextField
        returnValue = RadDropDownList2.SelectedValue
         Session("optionSelected") = returnValue 

        myConn.Open()
        query = "SELECT  * FROM [STRUCTURE_ALL_CENT] WHERE Site_TSF_Name = '" & returnValue & "'"
        cmd = New SqlCommand(query, myConn)
        rdr = cmd.ExecuteReader()
        If rdr.HasRows Then
            Do While rdr.Read
                e_w = Right(rdr.Item("DDLon"), 1)
                If e_w = "W" Then
                    lng = "-" & Left(rdr.Item("DDLon"), Len(rdr.Item("DDLon")) - 1)
                Else
                    lng = Left(rdr.Item("DDLon"), Len(rdr.Item("DDLon")) - 1)
                End If
                'lng = Left(lng, InStr(lng, " ") - 1) + (Mid(lng, InStr(lng, " ") + 1, 2)) / 60 + (Right(lng, InStrRev(lng, " ") - 1)) / 3600
                n_s = Right(rdr.Item("DDLat"), 1)
                If n_s = "S" Then
                    lat = "-" & Left(rdr.Item("DDLat"), Len(rdr.Item("DDLat")) - 1)
                Else
                    lat = Left(rdr.Item("DDLat"), Len(rdr.Item("DDLat")) - 1)
                End If
                'lat = Left(lat, InStr(lat, " ") - 1) + (Mid(lat, InStr(lng, " ") + 1, 2)) / 60 + (Right(lat, InStrRev(lat, " ") - 1)) / 3600
                mapframe.Src = "fat/index.html?zoom=yes&zoomtype=site&lng=" & lng & "&lat=" & lat
                Exit Do
            Loop
        End If
        myConn.Close()

        Session("siteSelected") = RadDropDownList2.SelectedValue
        btnDamBookOfLife.Visible = True

        'Response.Redirect("DamBookOfLife.aspx")

    End Sub

    Protected Sub getList(query As String, dataField As String, dataValue As String, sql As Integer)

        If sql = 1 Then
            RadDropDownList1.Visible = True
            'RadDropDownList3.Visible = False
            SqlDataSource1.SelectCommand = query
            RadDropDownList1.DataTextField = dataField
            RadDropDownList1.DataValueField = dataValue
            lblCaption.Text = "Please Select a Mine: "
        ElseIf sql = 2 Then
            RadDropDownList2.Visible = True
            'RadDropDownList3.Visible = False
            SqlDataSource2.SelectCommand = query
            RadDropDownList2.Items.Insert(0, New Telerik.Web.UI.DropDownListItem("-"))
            RadDropDownList2.DataTextField = dataField
            RadDropDownList2.DataValueField = dataValue
            lblCaption.Text = "Please Select a Site: "
            RadDropDownList2.SelectedIndex = -1
        End If
    End Sub


    Protected Sub btnDamBookOfLife_Click(sender As Object, e As EventArgs) Handles btnDamBookOfLife.Click
        If Session("siteSelected") = "" Then
            MsgBox("Please Select a Site!")
            Exit Sub
        End If
        Response.Redirect("DamBookOfLife.aspx")
    End Sub

End Class
