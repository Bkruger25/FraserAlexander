
Partial Class LogIn
    Inherits System.Web.UI.Page

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim uname, pass As String

        uname = txtUname.Text
        pass = txtPass.Text

        If uname <> LCase("admin") And pass <> LCase("admin") Then
            lblError.Text = "Incorrect Username or Password."
            Session("loggenIn") = 0
        Else
            Session("loggenIn") = 1
            Response.Redirect("profile.aspx")
        End If
    End Sub
End Class
