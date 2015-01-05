Public Class EditVideoDialog

    Private Video As Video
    Public Overloads Sub ShowDialog(Owner As IWin32Window, Video As Video)
        Me.Video = Video
        'Me.TitleBox.Text = Playlist.Title
        'Me.ThumbnailBox.Text = Playlist.Thumbnail
        MyBase.ShowDialog(Owner)
    End Sub

End Class