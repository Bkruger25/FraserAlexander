Imports Excel
Imports System.IO
Imports Telerik
Imports Telerik.Web.UI
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Converters
Imports Newtonsoft.Json.Serialization
Imports System.Net

Partial Class Profile
    Inherits System.Web.UI.Page

    Dim myConn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("FAConnectionString").ConnectionString)
    Dim myConn2 As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("FAConnectionString2").ConnectionString)
    Private Property cmd As SqlCommand
    Dim rdr As SqlDataReader

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim site As String
        Dim contractnumber As String
        Dim complex As String
        Dim plant As String
        Dim mine As String
        Dim client As String
        Dim parent As String
        Dim country As String
        Dim Business_Unit As String
        Dim Business_Area As String
        Dim Business_Unit_Manager As String
        Dim Business_Area_Manager As String
        Dim Contracts_ProductionManager As String
        Dim SieManager_OpsSupervisor As String
        Dim DamOwner As String
        Dim Product_Type As String
        Dim PlannedTonnage_WaterTreatmentVo As String
        Dim DDLat As String
        Dim DDLon As String
        Dim Continent As String
        Dim rateOfRise As String
        Dim Freeboard_Requirements As String
        Dim Freeboard_Status As String
        Dim Toras_Score As String

        For Each f As UploadedFile In RadAsyncUpload1.UploadedFiles
            Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateOpenXmlReader(f.InputStream)
            'file dataset with excel spreadsheet
            excelReader.IsFirstRowAsColumnNames = True
            Dim result As DataSet = excelReader.AsDataSet()
            'create data table from data set
            Dim dt As DataTable = result.Tables(0)

            For Each row As DataRow In dt.Rows
                If row.IsNull(0) Then
                    site = ""
                Else
                    site = row(0)
                End If
                If row.IsNull(1) Then
                    contractnumber = ""
                Else
                    contractnumber = row(1)
                End If
                If row.IsNull(2) Then
                    complex = ""
                Else
                    complex = row(2)
                End If
                If row.IsNull(3) Then
                    plant = ""
                Else
                    plant = row(3)
                End If
                If row.IsNull(4) Then
                    mine = ""
                Else
                    mine = row(4)
                End If
                If row.IsNull(5) Then
                    client = ""
                Else
                    client = row(5)
                End If
                If row.IsNull(6) Then
                    parent = ""
                Else
                    parent = row(6)
                End If
                If row.IsNull(7) Then
                    country = ""
                Else
                    country = row(7)
                End If
                If row.IsNull(8) Then
                    Business_Unit = ""
                Else
                    Business_Unit = row(8)
                End If
                If row.IsNull(9) Then
                    Business_Area = ""
                Else
                    Business_Area = row(9)
                End If
                If row.IsNull(10) Then
                    Business_Unit_Manager = ""
                Else
                    Business_Unit_Manager = row(10)
                End If
                If row.IsNull(11) Then
                    Business_Area_Manager = ""
                Else
                    Business_Area_Manager = row(11)
                End If
                If row.IsNull(12) Then
                    Contracts_ProductionManager = ""
                Else
                    Contracts_ProductionManager = row(12)
                End If
                If row.IsNull(13) Then
                    SieManager_OpsSupervisor = ""
                Else
                    SieManager_OpsSupervisor = row(13)
                End If
                If row.IsNull(14) Then
                    DamOwner = ""
                Else
                    DamOwner = row(14)
                End If
                If row.IsNull(15) Then
                    Product_Type = ""
                Else
                    Product_Type = row(15)
                End If
                If row.IsNull(16) Then
                    PlannedTonnage_WaterTreatmentVo = 0
                Else
                    PlannedTonnage_WaterTreatmentVo = row(16)
                End If
                If row.IsNull(17) Then
                    DDLat = ""
                Else
                    DDLat = row(17)
                End If
                If row.IsNull(18) Then
                    DDLon = ""
                Else
                    DDLon = row(18)
                End If
                If row.IsNull(19) Then
                    Continent = ""
                Else
                    Continent = row(19)
                End If
                If row.IsNull(20) Then
                    rateOfRise = 0
                Else
                    rateOfRise = row(20)
                End If
                If row.IsNull(21) Then
                    Freeboard_Requirements = 0
                Else
                    Freeboard_Requirements = row(21)
                End If
                If row.IsNull(22) Then
                    Freeboard_Status = 0
                Else
                    Freeboard_Status = row(22)
                End If
                If row.IsNull(23) Then
                    Toras_Score = 0
                Else
                    Toras_Score = row(23)
                End If

                'create json file
                Dim jObject As String = "Features=[" & _
                          "{" & _
                            """geometry""" & ":" & "{""x"" : " & DDLon & ", ""y"" : " & DDLat & "}," & _
                            """attributes"" : {" & _
                            """Site_TSF_Name"" :  """ & site & """," & _
                            """ContractNumber"" :  """ & contractnumber & """," & _
                            """Complex"" :  """ & complex & """," & _
                            """Plant"" :  """ & plant & """," & _
                            """Mine"" :  """ & mine & """," & _
                            """Client"" :  """ & client & """," & _
                            """Parent"" :  """ & parent & """," & _
                            """Country"" :  """ & country & """," & _
                            """Business_Unit"" :  """ & Business_Unit & """," & _
                            """Business_Area"" :  """ & Business_Area & """," & _
                            """Business_Unit_Manager"" :  """ & Business_Unit_Manager & """," & _
                            """Business_Area_Manager"" :  """ & Business_Area_Manager & """," & _
                            """Contracts_ProductionManager"" :  """ & Contracts_ProductionManager & """," & _
                            """SieManager_OpsSupervisor"" :  """ & SieManager_OpsSupervisor & """," & _
                            """DamOwner"" :  """ & DamOwner & """," & _
                            """Product_Type"" :  """ & Product_Type & """," & _
                            """PlannedTonnage_WaterTreatmentVo"" :  """ & PlannedTonnage_WaterTreatmentVo & """," & _
                            """DDLat"" :  """ & DDLat & """," & _
                            """DDLon"" :  """ & DDLon & """," & _
                            """Rate_of_Rise"" :  """ & rateOfRise & """," & _
                            """Freeboard_Requirements"" :  """ & Freeboard_Requirements & """," & _
                            """Freeboard_Status"" :  """ & Freeboard_Status & """," & _
                            """Toras_Score"" :  """ & Toras_Score & """," & _
                            """Continent"" : """ & Continent & _
                            """}" & _
                          "}" & _
                        "]&f=pjson&gdbVersion=&rollbackOnFailure=true"
                'post to map service
                Label1.text = jObject

                Dim data = Encoding.UTF8.GetBytes(jObject)
                Dim uri As Uri = New Uri("http://209.203.0.234/arcgis/rest/services/FraserAlexanderTailings/FAT_TailingsSites_OperationalLayers_20150413/FeatureServer/2/addFeatures?f=pjson")
                SendRequest(uri, data, "application/x-www-form-urlencoded; charset=UTF-8", "POST")
            Next row
        Next

    End Sub

    Private Function SendRequest(uri As Uri, jsonDataBytes As Byte(), contentType As String, method As String) As String
        Dim req As HttpWebRequest = WebRequest.Create(uri)
        req.ContentType = contentType
        req.Method = method
        req.ContentLength = jsonDataBytes.Length


        Dim stream = req.GetRequestStream()
        stream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
        stream.Close()

        Dim response = req.GetResponse().GetResponseStream()

        Dim reader As New StreamReader(response)
        Dim res = reader.ReadToEnd()
        Label3.Text = res
        reader.Close()
        response.Close()

        Return res
    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("loggenIn") = 0 Then
            Response.Redirect("Default.aspx")
        End If
    End Sub
End Class
