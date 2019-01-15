﻿Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.Web.UI.DropDownListItem

Partial Class AfricaOC
    Inherits System.Web.UI.Page

    Dim myConn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("FAConnectionString").ConnectionString)
    Dim myConn2 As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("FAConnectionString2").ConnectionString)
    Private Property cmd As SqlCommand
    Dim rdr As SqlDataReader
    '1 = country
    '2 = mine
    '3 = sites

    Protected Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        Response.Redirect("OperationsCatalogue.aspx")
        Session.Clear()
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim query As String
        Dim continent As String

        continent = Request.Cookies("continent").Value
        Session("optionSelected") = continent
        Select Case continent
            Case "Africa"
                'mapframe.Src = "fat/index.html?extent=30.1101777777778,-24.9134194444444,30.1051138888889,30.1051138888889&zoom=true&scale=true&theme=light"
                mapframe.Src = "fat/index.html?extent=-20.742,-36.757,61.172,37.283&amp;zoom=true&amp;scale=true&amp;theme=light"
                mapframe.Visible = True
            Case "Australia"
                mapframe.Src = "fat/index.html?extent=110.039,-44.23,155.742,-8.603&amp;zoom=true&amp;scale=true&amp;theme=light"
                mapframe.Visible = True
            Case "South America"
                mapframe.Src = "fat/index.html?extent=-91.582,-57.622,-31.465,14.073&amp;zoom=true&amp;scale=true&amp;theme=light"
                mapframe.Visible = True
            Case "Europe"
                mapframe.Src = "fat/index.html?extent=-21.27,6.119,110.566,71.124&amp;zoom=true&amp;scale=true&amp;theme=light"
                mapframe.Visible = True
        End Select

        query = "SELECT DISTINCT [Country], [Continent] FROM [STRUCTURE_ALL_CENT] WHERE [Continent] = '" & continent & "' and [Country] IS NOT NULL"
        getList(query, "Country", "Country", 1)
    End Sub

    Protected Sub RadDropDownList1_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.DropDownListEventArgs) Handles RadDropDownList1.SelectedIndexChanged
        Dim query As String
        Dim returnValue As String
        Dim returnData As String
        Dim lat As String
        Dim lng As String

        returnData = RadDropDownList1.DataTextField
        returnValue = RadDropDownList1.SelectedValue
        Request.Cookies("continent").Value = ""
        Session("optionSelected") = returnValue

        query = "SELECT DISTINCT Mine FROM [STRUCTURE_ALL_CENT] WHERE [Country] = '" & returnValue & "' and [Country] IS NOT NULL ORDER BY Mine"
        getList(query, "Mine", "Mine", 2)
        RadDropDownList2.SelectedIndex = -1
        RadDropDownList3.SelectedIndex = -1

        myConn2.Open()
        query = "SELECT DISTINCT longitude, latitude FROM Countries WHERE [Country] = '" & returnValue & "' and [Country] IS NOT NULL"
        cmd = New SqlCommand(query, myConn2)
        rdr = cmd.ExecuteReader()
        If rdr.HasRows Then
            Do While rdr.Read
                lat = rdr.Item("latitude")
                lng = rdr.Item("longitude")
                'mapframe.Visible = False
                mapframe.Visible = True
                mapframe.Src = "fat/index.html?zoom=yes&zoomtype=country&lng=" & lng & "&lat=" & lat
            Loop
        End If
        myConn2.Close()
    End Sub

    Protected Sub RadDropDownList2_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.DropDownListEventArgs) Handles RadDropDownList2.SelectedIndexChanged
        Dim query As String
        Dim returnValue As String
        Dim returnData As String
        Dim minX, maxX, minY, maxY As Double
        Dim lat, lng As String
        Dim tempMinX, tempMaxX, tempMinY, tempMaxY As String
        Dim count As Integer
        Dim e_w, n_s As String

        returnData = RadDropDownList2.DataTextField
        returnValue = RadDropDownList2.SelectedValue
        Session("optionSelected") = returnValue

        myConn.Open()
        query = "SELECT * FROM [STRUCTURE_ALL_CENT] WHERE [Mine] = '" & returnValue & "'"
        cmd = New SqlCommand(query, myConn)
        rdr = cmd.ExecuteReader()
        If rdr.HasRows Then
            count = 1
            Do While rdr.Read
                lat = rdr.Item("Centroid_S_N")
                lat = Val(Left(lat, InStr(lat, " "))) + Val((Mid(lat, InStr(lat, " ") + 1, 2))) / 60 + Val(Right(lat, InStrRev(lat, " "))) / 3600
                lng = rdr.Item("Centroid_E_W")
                lng = Val(Left(lng, InStr(lng, " "))) + Val(Mid(lng, InStr(lng, " ") + 1, 2)) / 60 + Val(Right(lng, InStrRev(lng, " "))) / 3600
                e_w = rdr.Item("SiteCoOrdsCentroid_EorW")
                n_s = rdr.Item("SiteCoOrdsCentroid_S_N")

                'e_wbot = rdr.Item("SiteCoOrdsBottomRight_EorW")
                'e_wtop = rdr.Item("SiteCoOrdsTopLeft_EorW")
                'n_sbot = rdr.Item("SiteCoOrdsBottomRight_SorN")
                'n_stop = rdr.Item("SiteCoOrdsTopLeft_SorN")

                'tempMinX = rdr.Item("BottomRight_E_W")
                'tempMinX = Left(tempMinX, InStr(tempMinX, " ") - 1) + (Mid(tempMinX, InStr(tempMinX, " ") + 1, 2)) / 60 + (Right(tempMinX, InStrRev(tempMinX, " ") - 1)) / 3600
                'tempMinY = rdr.Item("BottomRight_S_N")
                'tempMinY = Left(tempMinY, InStr(tempMinY, " ") - 1) + (Mid(tempMinY, InStr(tempMinY, " ") + 1, 2)) / 60 + (Right(tempMinY, InStrRev(tempMinY, " ") - 1)) / 3600
                'tempMaxX = rdr.Item("TopLeft_E_W")
                'tempMaxX = Left(tempMaxX, InStr(tempMaxX, " ") - 1) + (Mid(tempMaxX, InStr(tempMaxX, " ") + 1, 2)) / 60 + (Right(tempMaxX, InStrRev(tempMaxX, " ") - 1)) / 3600
                'tempMaxY = rdr.Item("TopLeft_S_N")
                'tempMaxY = Left(tempMaxY, InStr(tempMaxY, " ") - 1) + (Mid(tempMaxY, InStr(tempMaxY, " ") + 1, 2)) / 60 + (Right(tempMaxY, InStrRev(tempMaxY, " ") - 1)) / 3600

                'minX = CDbl(tempMinX)
                'minY = CDbl(tempMinY)
                'maxX = CDbl(tempMaxX)
                'maxY = CDbl(tempMaxY)

                'If count = 1 Then
                '    minX = tempMinX
                '    minY = tempMinY
                '    maxX = tempMaxX
                '    maxY = tempMaxY
                'Else
                '    If tempMinX < 0 Then
                '        If minX < 0 Then
                '            If tempMinX < minX Then
                '                minX = tempMinX
                '            End If
                '        End If
                '    ElseIf minX < 0 Then
                '            If tempMinX < minX Then
                '                minX = tempMinX
                '        End If
                '    Else
                '        If tempMinX > minX Then
                '            minX = tempMinX
                '        End If
                '    End If
                '    If tempMinY < 0 Then
                '        If minY < 0 Then
                '            If tempMinY < minY Then
                '                minY = tempMinY
                '            End If
                '        End If
                '    ElseIf minY < 0 Then
                '        If tempMinY < minY Then
                '            minY = tempMinY
                '        End If
                '    Else
                '        If tempMinY > minY Then
                '            minY = tempMinY
                '        End If
                '    End If
                '    If tempMaxX > maxX Then
                '        maxX = tempMaxX
                '    End If
                '    If tempMaxY > maxY Then
                '        maxY = tempMinY
                '    End If
                'End If
                'count = count + 1
            Loop
            'Response.Write("fat/index.html?extent=" & minX & "," & minY & "," & maxX & "," & maxY & "&amp;zoom=true&amp;scale=true&amp;theme=light")
            'mapframe.Src = "fat/index.html?extent=" & minX & "," & minY & "," & maxX & "," & maxY & "&amp;zoom=true&amp;scale=true&amp;theme=light"
            mapframe.Src = "fat/index.html?zoom=yes&zoomtype=mine&lng=" & lng & "&lat=" & lat
        End If
        myConn.Close()
        query = "SELECT DISTINCT Site_TSF_Name FROM [STRUCTURE_ALL_CENT] WHERE [Mine] = '" & returnValue & "' and [Country] IS NOT NULL ORDER BY Site_TSF_Name"
        Session("mineSelected") = returnValue
        getList(query, "Site_TSF_Name", "Site_TSF_Name", 3)


    End Sub

    Protected Sub RadDropDownList3_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.DropDownListEventArgs) Handles RadDropDownList3.SelectedIndexChanged
        Dim returnData As String
        Dim returnValue As String
        Dim query As String
        Dim lat, lng As String
        Dim n_s As String
        Dim e_w As String

        returnData = RadDropDownList3.DataTextField
        returnValue = RadDropDownList3.SelectedValue
        Session("optionSelected") = returnValue

        myConn.Open()
        query = "SELECT * FROM [STRUCTURE_ALL_CENT] WHERE [Site_TSF_Name] = '" & returnValue & "'"
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

        Session("siteSelected") = RadDropDownList3.SelectedValue
    End Sub

    Protected Sub getList(query As String, dataField As String, dataValue As String, sql As Integer)

        If sql = 1 Then
            RadDropDownList1.Visible = True
            'RadDropDownList3.Visible = False
            SqlDataSource1.SelectCommand = query
            RadDropDownList1.DataTextField = dataField
            RadDropDownList1.DataValueField = dataValue
            lblCaption.Text = "Please Select a Country: "
        ElseIf sql = 2 Then
            RadDropDownList2.Visible = True
            'RadDropDownList3.Visible = False
            SqlDataSource2.SelectCommand = query
            RadDropDownList2.Items.Insert(0, New Telerik.Web.UI.DropDownListItem("-"))
            RadDropDownList2.DataTextField = dataField
            RadDropDownList2.DataValueField = dataValue
            lblCaption.Text = "Please Select a Mine: "
            RadDropDownList3.SelectedIndex = -1
        ElseIf sql = 3 Then
            RadDropDownList3.Visible = True
            SqlDataSource3.SelectCommand = query
            RadDropDownList3.Items.Insert(0, New Telerik.Web.UI.DropDownListItem("-"))
            RadDropDownList3.DataTextField = dataField
            RadDropDownList3.DataValueField = dataValue
            lblCaption.Text = "Please Select a Site: "
            btnDamBookOfLife.Visible = True
            RadDropDownList3.SelectedIndex = -1
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
