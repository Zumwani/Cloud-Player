Imports YouTube.Net.Misc
Imports System.Web
Imports System.Collections.Specialized

Public Class AuthenticateDialog

    Public AccessToken As String = ""

    Private Url As String

    Public Overloads Function ShowDialog(ClientID As String, Scope As YouTubeClient.Scope) As String

        Url = Res.AuthenticateString + "?client_id=" + ClientID + _
            "&redirect_uri=" + Res.Redirect_Uri + _
            "&response_type=code" + _
            "&scope=" + YouTubeClient.GetScopeString(Scope)

        WebBrowser1.Navigate(Url)

        MyBase.ShowDialog()

        Return Me.AccessToken

    End Function

    Private Sub WebBrowser1_Navigated(sender As Object, e As Windows.Forms.WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated

        'Redirect url is set to 'urn:ietf:wg:oauth:2.0:oob', which means that token is returned in web page title
        For Each q As String In WebBrowser1.DocumentTitle.Split(" ").Last.Split("&")

            If q.Split("=").First = "code" Then
                AccessToken = q.Split("=").Last
                Close()
            ElseIf q.Split("=").First = "error" Then
                Close()
            End If

        Next

    End Sub
End Class