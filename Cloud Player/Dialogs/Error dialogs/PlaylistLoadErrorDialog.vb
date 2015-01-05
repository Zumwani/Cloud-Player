Imports System.IO

Public Class PlaylistLoadErrorDialog
    Inherits Zumwani.CommonLibrary.Templates.Dialog

    Public Overloads Function ShowDialog(File As FileInfo, GeneratorVersion As String, PlaylistVersion As String, ErrorMessage As String, Optional Parent As Form = Nothing, Optional ShowIgnoreButton As Boolean = True, Optional ShowDeleteButton As Boolean = True, Optional ShowRetryButton As Boolean = True) As DialogResult

        Label1.Text = Label1.Text.Replace("<filename>", File.Name)
        Label1.Text = Label1.Text.Replace("<generatorversion>", GeneratorVersion)
        Label1.Text = Label1.Text.Replace("<playlistversion>", PlaylistVersion)
        Label1.Text = Label1.Text.Replace("<errormessage>", ErrorMessage)

        IgnoreButton.Visible = ShowIgnoreButton
        DeleteButton.Visible = ShowDeleteButton
        RetryButton.Visible = ShowRetryButton

        If Not (ShowIgnoreButton And ShowDeleteButton And ShowRetryButton) Then
            OkButton.Visible = True
        End If

        If Parent IsNot Nothing Then
            MyBase.ShowDialog(Parent)
        Else
            MyBase.ShowDialog()
        End If

        Return Result

    End Function

    Public Shadows Enum DialogResult
        None = 0
        Ignore = 1
        Delete = 2
        Retry = 3
        Ok = 4
    End Enum

    Private _Result As DialogResult = DialogResult.None
    Public ReadOnly Property Result As DialogResult
        Get
            Return _Result
        End Get
    End Property

    Private Sub IgnoreButton_Click(sender As Object, e As EventArgs) Handles IgnoreButton.Click
        _Result = DialogResult.Ignore
        Close()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        _Result = DialogResult.Delete
        Close()
    End Sub

    Private Sub RetryButton_Click(sender As Object, e As EventArgs) Handles RetryButton.Click
        _Result = DialogResult.Retry
        Close()
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        _Result = DialogResult.Ok
        Close()
    End Sub
End Class