Imports System.IO.DirectoryInfo

Partial Class DocManager
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim section As String
        Dim site As String

        section = Request.Cookies("dbo").Value
        site = Session("mineSelected")

        For Each Dir As String In System.IO.Directory.GetDirectories(MapPath("~/Dam_Book_of_Life"))
            Dim dirInfo As New System.IO.DirectoryInfo(Dir)
            If site = dirInfo.Name Then
                For Each dir2 As String In System.IO.Directory.GetDirectories(MapPath("~/Dam_Book_of_Life/") & dirInfo.Name)
                    Dim dirInfo2 As New System.IO.DirectoryInfo(dir2)
                    If section = dirInfo2.Name Then
                        Dim paths As String() = New String() {"~/Dam_Book_of_Life/" & dirInfo.Name & "/" & dirInfo2.Name}
                        'This code sets RadFileExplorer's paths
                        RadFileExplorer1.Configuration.ViewPaths = paths
                        RadFileExplorer1.Configuration.UploadPaths = paths
                        RadFileExplorer1.Configuration.DeletePaths = paths

                        'Sets Max file size
                        RadFileExplorer1.Configuration.MaxUploadFileSize = 10485760

                        ' Enables Paging on the Grid
                        RadFileExplorer1.AllowPaging = True
                        ' Sets the page size
                        RadFileExplorer1.PageSize = 20

                        'Load the default FileSystemContentProvider
                        RadFileExplorer1.Configuration.ContentProviderTypeName = GetType(Telerik.Web.UI.Widgets.FileSystemContentProvider).AssemblyQualifiedName
                        Exit For
                    End If
                Next
            End If
        Next

    End Sub

    Protected Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        Response.Redirect("DamBookOfLife.aspx")
    End Sub
End Class
