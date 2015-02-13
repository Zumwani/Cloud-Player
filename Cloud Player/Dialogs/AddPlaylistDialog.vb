Imports Google.Apis.YouTube.v3
Imports System.ComponentModel

Public Class AddPlaylistDialog
    Inherits Zumwani.CommonLibrary.Templates.Dialog

#Region "Search"

    Private WithEvents Timer As New Timer With {.Interval = 1000}

    Private Event DoSearch()

    Private _eh As DoSearchEventHandler

    Private Sub StartSearchCountdown(EventHandler As DoSearchEventHandler)
        _eh = EventHandler
        Timer.Stop()
        Timer.Start()
    End Sub

    Private Sub StopSearchCountdown()
        Timer.Stop()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        Timer.Stop()
        _eh.DynamicInvoke()
    End Sub

#End Region
#Region "Playlist"

    Private Event RefreshSelection(SelectedPlaylist As Playlist)


    Private Event PlaylistAdded(ByRef PlaylistTags As Dictionary(Of PlaylistFinalizeEventHandler, Object()))
    Private Event PlaylistFinalize(PlaylistTag As Object)

    Private FinalizeEventHandler As PlaylistFinalizeEventHandler
    Private CurrentPlaylistTag As Object

    Private _Playlist As Playlist
    Public Property Playlist() As Playlist
        Get
            Return _Playlist
        End Get
        Set(value As Playlist)
            _Playlist = value
            PlaylistPreview.AssociatedObject = value
            AddButton.Enabled = True
            RaisePlaylistAddedEvent()
        End Set
    End Property

    Private Sub RaisePlaylistAddedEvent()
        Dim d As New Dictionary(Of PlaylistFinalizeEventHandler, Object())
        RaiseEvent PlaylistAdded(d)
        For Each item In d
            If item.Value.Contains(CurrentPlaylistTag) Then
                FinalizeEventHandler = item.Key
            End If
        Next
    End Sub

    Private Sub RaisePlaylistFinalizeEvent()
        If FinalizeEventHandler IsNot Nothing Then
            FinalizeEventHandler.DynamicInvoke(CurrentPlaylistTag)
        End If
    End Sub

    Private createditems As New List(Of ListItem)

    Private Function CreateItem(Playlist As Playlist, PlaylistTag As Object) As ListItem

        If Me.InvokeRequired Then
            Return Me.BeginInvoke(Function() CreateItem(Playlist, PlaylistTag))
        End If

        Dim a As New ListItem(Playlist)

        With a

            .SelectionMode = ListItem.SelectMode.Check
            .AllowPlay = False
            .AllowDelete = False
            .AllowEdit = False
            .Margin = New Padding(0)
            .Tag = PlaylistTag

            AddHandler .Click, AddressOf Item_Click

        End With

        If ItemIsAdded(Playlist) Then
            a.Select(True)
        End If

        Return a

    End Function

    Private Sub Item_Click(sender As ListItem, e As EventArgs)
        CurrentPlaylistTag = sender.Tag
        Playlist() = sender.AssociatedObject
        RaiseEvent RefreshSelection(Playlist)
        sender.Select(True)
    End Sub

    Private Function ItemIsAdded(Playlist As Playlist) As Boolean
        Return (PlaylistPreview.AssociatedObject Is Playlist)
    End Function

#End Region
#Region "Local"

    Private Local_FinalizeEventhandler As New PlaylistFinalizeEventHandler(AddressOf Local_PlaylistFinalize)
    Private Local_ID As String = ""

    Private Sub TitleBox_TextChanged(sender As Object, e As EventArgs) Handles TitleBox.TextChanged
        Playlist = PlaylistFactory.CreateNew(TitleBox.Text, ThumbnailBox.Text)
    End Sub

    Private Sub ThumbnailBox_TextChanged(sender As Object, e As EventArgs) Handles ThumbnailBox.TextChanged
        Playlist = PlaylistFactory.CreateNew(TitleBox.Text, ThumbnailBox.Text)
        Local_ID = Playlist.ID.ToString
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

    Private Sub Local_PlaylistAdded(ByRef PlaylistTags As Dictionary(Of PlaylistFinalizeEventHandler, Object())) Handles Me.PlaylistAdded
        PlaylistTags.Add(Local_FinalizeEventhandler, {Local_ID})
    End Sub

    Private Sub Local_PlaylistFinalize(PlaylistTag As Object)
        Dim path As String = ThumbnailStore.FullName + "\" + Playlist.ID.ToString + "." + Playlist.Thumbnail.Split(".").Last
        If Playlist.Thumbnail.PathIsLocal Then
            IO.File.Copy(Playlist.Thumbnail, path)
        Else
            Using client As New Net.WebClient
                client.DownloadFile(Playlist.Thumbnail, path)
            End Using
        End If
        Playlist.Thumbnail = path
    End Sub

#End Region
#Region "YouTube tab"

    Private YouTubeSearchEventHandler As New DoSearchEventHandler(AddressOf DoYouTubeSearch)
    Private YouTube_FinalizeEventHandler As New PlaylistFinalizeEventHandler(AddressOf YouTube_PlaylistFinalize)

    Private YouTubeItems As String()

    Private Sub DoYouTubeSearch()

        Dim SearchString As String = YouTubeSearchBox.Text

        If Not SearchString = "" Then
            YouTubeSearchResultBox.SuspendLayout()
            YouTubeSearchResultBox.Controls.Clear()

            Dim request As New SearchResource.ListRequest(YouTubeService, "snippet")
            request.Q = SearchString
            request.MaxResults = 20
            request.Type = "playlist"

            Dim response = request.Execute

            Dim l As New List(Of String)

            For Each item In response.Items
                If Not item.Id.PlaylistId = "" Then
                    YouTubeSearchResultBox.Controls.Add(CreateItem(PlaylistFactory.CreateFromYouTubePlaylist(item, False), item.Id.PlaylistId))
                    l.Add(item.Id.PlaylistId)
                End If
            Next

            YouTubeItems = l.ToArray

            YouTubeSearchResultBox.ResumeLayout()

        End If
    End Sub

    Private Sub YouTubeBox_TextChanged(sender As Object, e As EventArgs) Handles YouTubeSearchBox.TextChanged
        If Not YouTubeSearchBox.Text = "" Then
            StartSearchCountdown(YouTubeSearchEventHandler)
        Else
            StopSearchCountdown()
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

    Private Sub YouTube_PlaylistAdded(ByRef PlaylistTags As Dictionary(Of PlaylistFinalizeEventHandler, Object())) Handles Me.PlaylistAdded
        PlaylistTags.Add(YouTube_FinalizeEventHandler, YouTubeItems)
    End Sub

    Private Sub YouTube_PlaylistFinalize(PlaylistTag As Object)
        Dim request As New PlaylistsResource.ListRequest(YouTubeService, "snippet")
        request.MaxResults = 1
        request.Id = CurrentPlaylistTag

        Dim response = request.Execute

        Playlist = PlaylistFactory.CreateFromYouTubePlaylist(response.Items(0), True)
    End Sub

#End Region

    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        RaisePlaylistFinalizeEvent()
    End Sub

End Class