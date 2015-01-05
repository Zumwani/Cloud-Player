Imports System.Globalization

Public Class SettingsDialog
    Inherits Zumwani.CommonLibrary.Templates.Dialog

    Private Sub SettingsWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SavePositionAtCloseBox.Checked = (My.Settings.SavePositionAtClose)
        RestorePositionAtStartBox.Checked = (My.Settings.RestorePositionAtStartup)

        LanguageBox.Items.AddRange({CultureInfo.GetCultureInfoByIetfLanguageTag("en-US"), CultureInfo.GetCultureInfoByIetfLanguageTag("sv-SE")})
        LanguageBox.SelectedItem = My.Settings.Language

    End Sub

    Private Sub SettingsWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        My.Settings.SavePositionAtClose = SavePositionAtCloseBox.Checked
        My.Settings.RestorePositionAtStartup = RestorePositionAtStartBox.Checked

        My.Settings.Save()

    End Sub

    Private Sub SaveWindowRectangleButton_Click(sender As Object, e As EventArgs) Handles SaveWindowRectangleButton.Click
        MainWindow.SaveWindowPositionInfo()
    End Sub

    Private Sub LanguageBox_SelectedValueChanged(sender As Object, e As EventArgs) Handles LanguageBox.SelectedValueChanged
        If LanguageBox.SelectedItem IsNot Nothing Then
            RestartMessageLabel.Visible = Not (CType(LanguageBox.SelectedItem, CultureInfo).DisplayName = My.Settings.Language.DisplayName)
            RestartNowLink.Visible = Not (CType(LanguageBox.SelectedItem, CultureInfo).DisplayName = My.Settings.Language.DisplayName)
            My.Settings.Language = LanguageBox.SelectedItem
        Else
            RestartMessageLabel.Visible = False
            RestartNowLink.Visible = False
        End If
    End Sub

    Private Sub RestartNowLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles RestartNowLink.LinkClicked
        Application.Restart()
    End Sub

    Private Sub GetPlaylists()
        ObjectListView1.SetObjects(MainWindow.PlaylistManager.Playlists)
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

    End Sub

    Private Sub OpenLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenLocationToolStripMenuItem.Click

    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click

    End Sub

    Private Sub PlaylistTab_Enter(sender As Object, e As EventArgs) Handles PlaylistTab.Enter
        GetPlaylists()
    End Sub
End Class