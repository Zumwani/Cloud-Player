Public Class EditPlaylistDialog
    Inherits Zumwani.CommonLibrary.Templates.Dialog

    Private Playlist As Playlist
    Public Overloads Sub ShowDialog(Owner As IWin32Window, Playlist As Playlist)

        Me.Playlist = Playlist
        Me.TitleBox.Text = Playlist.Title
        Me.ThumbnailBox.Text = Playlist.Thumbnail
        Me.IDLabel.Text = Playlist.ID.ToString("B")
        PopulateList(Playlist)

        RefreshThumb()

        If Not List.Controls.Count = 0 Then
            If ThumbnailPreviewBox.ImageLocation = CType(CType(List.Controls(0), ListItem).AssociatedObject, Video).Thumbnail Then
                AutoThumbnailBox.Checked = True
            End If
        End If

        MyBase.ShowDialog(Owner)

    End Sub

    Private Sub ThumbnailBox_TextChanged(sender As Object, e As EventArgs) Handles ThumbnailBox.TextChanged
        RefreshThumb()
    End Sub

    Private Sub RegenerateIDLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles RegenerateIDLink.LinkClicked
        Dim id As Guid = Guid.NewGuid
        IDLabel.Text = id.ToString("B")
        IDInUseLabel.Visible = (MainWindow.PlaylistManager.Playlist(id) IsNot Nothing)
    End Sub

    Private Sub PopulateList(Playlist As Playlist)
        List.Controls.Clear()
        For Each vid In Playlist.Videos
            List.Controls.Add(CreateItem(vid))
        Next
    End Sub

    Private Function CreateItem(Video As Video) As ListItem
        Dim a As New ListItem(Video)
        With a
            .SelectionMode = ListItem.SelectMode.ChangeBackcolor
            .AllowDelete = True
            .AllowEdit = False
            .AllowOpenLocation = True
            .AllowPlay = True
            .Margin = New Padding(0)
            .AutomaticallySetCurrentlyPlayingStatus = False
        End With
        AddHandler a.Click, AddressOf Item_Click
        AddHandler a.PlayItemClicked, AddressOf Item_Play
        AddHandler a.DeleteItemClicked, AddressOf Item_Delete
        Return a
    End Function

    Private Sub Item_Click(Sender As ListItem, e As EventArgs)
        For Each item As ListItem In List.Controls
            If item IsNot Sender And item.Selected Then
                item.Deselect(True)
            End If
        Next
    End Sub

    Private Sub Item_Play(Sender As ListItem, e As EventArgs)
        Dim d As New ViewVideoDialog
        d.ShowDialog(Me, Sender.AssociatedObject)
    End Sub

    Private Sub Item_Delete(Sender As ListItem, ByRef Handled As Boolean)
        Sender.SetStatus(ListItem.Status.ToBeRemoved)
        Handled = True
    End Sub

    Private Sub List_MouseEnter(sender As Object, e As EventArgs) Handles List.MouseEnter
        List.Select()
    End Sub

    Private Function GetSelectedItem() As ListItem
        For Each item As ListItem In List.Controls
            If item.Selected Then
                Return item
            End If
        Next
        Return Nothing
    End Function

    Private Sub MoveUpButton_Click(sender As Object, e As EventArgs) Handles MoveUpButton.Click

        Dim item As ListItem = GetSelectedItem()

        If item IsNot Nothing Then

            Dim i As Integer = List.Controls.IndexOf(item) - 1
            If i >= 0 Then
                List.Controls.SetChildIndex(item, i)
            End If

            List.ScrollControlIntoView(item)
            RefreshThumb()

        End If

    End Sub

    Private Sub MoveDownButton_Click(sender As Object, e As EventArgs) Handles MoveDownButton.Click

        Dim item As ListItem = GetSelectedItem()

        If item IsNot Nothing Then

            Dim i As Integer = List.Controls.IndexOf(item) + 1
            If i < List.Controls.Count Then
                List.Controls.SetChildIndex(item, i)
            End If

            List.ScrollControlIntoView(item)
            RefreshThumb()

        End If

    End Sub

    Private Sub AutoThumbnailBox_CheckedChanged(sender As Object, e As EventArgs) Handles AutoThumbnailBox.CheckedChanged
        RefreshThumb()
    End Sub

    Private Sub RefreshThumb()

        If Not AutoThumbnailBox.Checked Then
            ThumbnailPreviewBox.ImageLocation = ThumbnailBox.Text
        Else
            If Not List.Controls.Count = 0 Then
                ThumbnailPreviewBox.ImageLocation = CType(CType(List.Controls(0), ListItem).AssociatedObject, Video).Thumbnail
            Else
                ThumbnailPreviewBox.ImageLocation = ""
            End If
        End If

    End Sub

End Class