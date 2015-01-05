Imports Google.Apis.YouTube.v3

Public Class AddPlaylistDialog
    Inherits Zumwani.CommonLibrary.Templates.Dialog

#Region "Search"

    Private WithEvents Timer As New Timer With {.Interval = 1000}

    Private Event DoSearch(SearchKey As String)

    Private _k As String
    Private Sub StartSearchCountdown(SearchKey As String)
        _k = SearchKey
        Timer.Stop()
        Timer.Start()
    End Sub

    Private Sub StopSearchCountdown()
        Timer.Stop()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        Timer.Stop()
        RaiseEvent DoSearch(_k)
    End Sub

#End Region
#Region "Playlist"

    Private Event RefreshSelection(SelectedPlaylist As Playlist)

    Private _Playlist As Playlist
    Public Property Playlist As Playlist
        Get
            Return _Playlist
        End Get
        Set(value As Playlist)
            _Playlist = value
            PlaylistPreview.AssociatedObject = value
            AddButton.Enabled = True
        End Set
    End Property

    Private createditems As New List(Of ListItem)

    Private Function CreateItem(Playlist As Playlist) As ListItem

        Dim a As New ListItem(Playlist)

        With a

            .SelectionMode = ListItem.SelectMode.Check
            .AllowPlay = False
            .AllowDelete = False
            .AllowEdit = False
            .Margin = New Padding(0)

            AddHandler .Click, AddressOf Item_Click

        End With

        If ItemIsAdded(Playlist) Then
            a.Select(True)
        End If

        Return a

    End Function

    Private Sub Item_Click(sender As ListItem, e As EventArgs)
        Playlist = sender.AssociatedObject
        RaiseEvent RefreshSelection(Playlist)
        sender.Select(True)
    End Sub

    Private Function ItemIsAdded(Playlist As Playlist) As Boolean
        Return (PlaylistPreview.AssociatedObject Is Playlist)
    End Function

#End Region
#Region "Create new tab"

    Private Sub TitleBox_TextChanged(sender As Object, e As EventArgs) Handles TitleBox.TextChanged
        Playlist = PlaylistFactory.CreateNew(TitleBox.Text, ThumbnailBox.Text)
    End Sub

    Private Sub ThumbnailBox_TextChanged(sender As Object, e As EventArgs) Handles ThumbnailBox.TextChanged
        Playlist = PlaylistFactory.CreateNew(TitleBox.Text, ThumbnailBox.Text)
        StoreImageLocally = True
    End Sub

    Private Sub BrowseButton_Click(sender As Object, e As EventArgs) Handles BrowseButton.Click
        Dim d As New OpenFileDialog
        d.AutoUpgradeEnabled = True
        d.CheckFileExists = True
        d.Filter = ".png|*.png|.jpg|*.jpg|.gif|*.gif|All files|*.*"
        d.Title = "Select image to use as thumbnail..."
        If d.ShowDialog = Windows.Forms.DialogResult.OK Then
            ThumbnailBox.Text = d.FileName
        End If
    End Sub

#End Region
#Region "YouTube tab"

    Private Sub DoYouTubeSearch(SearchString As String)
        If Not SearchString = "" Then
            YouTubeSearchResultBox.SuspendLayout()
            YouTubeSearchResultBox.Controls.Clear()

            Dim request As New SearchResource.ListRequest(YouTubeService, "snippet")
            request.Q = SearchString
            request.MaxResults = 20
            request.Type = "youtube#playlist"

            Dim response = request.Execute

            For Each item In response.Items
                If Not item.Id.PlaylistId = "" Then
                    YouTubeSearchResultBox.Controls.Add(CreateItem(PlaylistFactory.CreateFromYouTubePlaylist(item)))
                End If
            Next

            YouTubeSearchResultBox.ResumeLayout()

        End If
    End Sub

    Private Sub YouTubeBox_TextChanged(sender As Object, e As EventArgs) Handles YouTubeSearchBox.TextChanged
        If Not YouTubeSearchBox.Text = "" Then
            StartSearchCountdown("YouTube")
        Else
            StopSearchCountdown()
        End If
    End Sub

    Private Sub YouTube_DoSearchEvent(SearchKey As String) Handles Me.DoSearch
        If SearchKey = "YouTube" Then
            DoYouTubeSearch(YouTubeSearchBox.Text)
        End If
    End Sub

    Private Sub YouTube_RefreshSelection(SelectedPlaylist As Playlist) Handles Me.RefreshSelection
        For Each item As ListItem In YouTubeSearchResultBox.Controls
            item.Selected = False
        Next
    End Sub

    Private Sub YouTubeSearchResultBox_MouseEnter(sender As Object, e As EventArgs) Handles YouTubeSearchResultBox.MouseEnter
        YouTubeSearchResultBox.Select()
    End Sub

#End Region

    Private StoreImageLocally As Boolean = False

    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        If StoreImageLocally Then
            Dim path As String = ThumbnailStore.FullName + "\" + Playlist.ID.ToString + "." + Playlist.Thumbnail.Split(".").Last
            If Playlist.Thumbnail.PathIsLocal Then
                IO.File.Copy(Playlist.Thumbnail, path)
            Else
                Using client As New Net.WebClient
                    client.DownloadFile(Playlist.Thumbnail, path)
                End Using
            End If
            Playlist.Thumbnail = path
        End If
    End Sub

End Class