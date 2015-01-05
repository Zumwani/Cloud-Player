Public Class ViewVideoDialog
    Inherits Zumwani.CommonLibrary.Templates.Dialog

    Private path As String
    Public Overloads Sub ShowDialog(ParentWindow As IWin32Window, Video As Video)
        Me.Text = Video.Title
        path = Video.Location
        MyBase.ShowDialog(ParentWindow)
    End Sub

    Private Sub ViewVideoDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        MediaPlayer1.Stop()
        MediaPlayer1.Dispose()
        Do Until MediaPlayer1.IsDisposed
            Application.DoEvents()
        Loop
    End Sub

    Private Sub ViewVideoDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MediaPlayer1.PlayVideo(path)
    End Sub
End Class