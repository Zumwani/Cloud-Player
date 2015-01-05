Public Class PlaylistDifferentVersionDialog
    Inherits Zumwani.CommonLibrary.Templates.Dialog

    Public Overloads Function ShowDialog(Name As String, ExpectedVersion As String, ActualVersion As String, Optional Parent As Form = Nothing) As DialogResult

        Label1.Text = Label1.Text.Replace("<name>", Name)
        Label1.Text = Label1.Text.Replace("<expectedversion>", ExpectedVersion)
        Label1.Text = Label1.Text.Replace("<actualversion>", ActualVersion)

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
        Upgrade = 4
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

    Private Sub UpgradeButton_Click(sender As Object, e As EventArgs) Handles UpgradeButton.Click
        _Result = DialogResult.Upgrade
        Close() '
    End Sub
End Class