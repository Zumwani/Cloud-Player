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

    Private Sub TabHeader1_TabClicked(e As CommonLibrary.Controls.TabHeader.TabClickedEventArgs) Handles TabHeader1.TabClicked

        If e.TabPage Is PlaylistTab Then
            GetPlaylists()
        End If

    End Sub

    Private Sub ObjectListView1_SelectionChanged(sender As Object, e As EventArgs) Handles ObjectListView1.SelectionChanged
        ExportButton.Enabled = (ObjectListView1.SelectedObject IsNot Nothing)
    End Sub

    Private Sub ImportButton_Click(sender As Object, e As EventArgs) Handles ImportButton.Click

        Dim d As New OpenFileDialog
        With d
            .AddExtension = True
            .AutoUpgradeEnabled = True
            .CheckFileExists = True
            .Filter = "Playlists (*.pl)|*.pl|XML Files (*.xml)|*.xml|All Files|*.*"
            .Multiselect = False
            .Title = "Choose a playlist to import..."
        End With

        If d.ShowDialog = Windows.Forms.DialogResult.OK Then
            MainWindow.PlaylistManager.Add(PlaylistGenerator.Load(New IO.FileInfo(d.FileName), False))
        End If

        GetPlaylists()

    End Sub

    Private Sub ExportButton_Click(sender As Object, e As EventArgs) Handles ExportButton.Click

        Dim d As New SaveFileDialog
        With d
            .AddExtension = True
            .AutoUpgradeEnabled = True
            .DefaultExt = ".pl"
            .OverwritePrompt = True
            .FileName = CType(ObjectListView1.SelectedObject, Playlist).Title
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            .Filter = "Playlist file (*.pl)|*.pl|XML document (*.xml)|*.xml|Text file (*.txt)|.txt"
            .Title = "Select location to export " + CType(ObjectListView1.SelectedObject, Playlist).Title + " to..."
        End With

        If d.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            PlaylistGenerator.Save(ObjectListView1.SelectedObject, d.FileName)
        End If

    End Sub
End Class