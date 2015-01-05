Imports System.Xml
Imports System.IO

<System.ComponentModel.DefaultProperty("Playlist")> _
Public Class PlaylistManager

#Region "Properties and events"

    Public Event VideoPlay(Video As Video, Playlist As Playlist)
    Public Event VideoStop()
    Public Event CollectionChanged()
    Public Event PlaylistChanged(Playlist As Playlist)

    Private Shared _TempPlaylist As New Playlist("", "")
    Public Shared ReadOnly Property TempPlaylist As Playlist
        Get
            Return _TempPlaylist
        End Get
    End Property

    Private _CurrentlyPlaying As Video
    Public ReadOnly Property CurrentlyPlaying As Video
        Get
            Return _CurrentlyPlaying
        End Get
    End Property

    Private _CurrentlyPlayingPlaylist As Playlist
    Public ReadOnly Property CurrentlyPlayingPlaylist As Playlist
        Get
            Return _CurrentlyPlayingPlaylist
        End Get
    End Property

#End Region
#Region "Collection"

    Public ReadOnly Property Playlist(Index As Integer) As Playlist
        Get
            Try
                Return Playlists(Index)
            Catch ex As IndexOutOfRangeException
                Throw ex
            End Try
        End Get
    End Property

    Public ReadOnly Property Playlist(ID As Guid) As Playlist
        Get
            For Each p In Playlists
                If p.ID = ID Then
                    Return p
                End If
            Next
            Return Nothing
        End Get
    End Property

    Private _Playlists As New List(Of Playlist)
    Public ReadOnly Property Playlists As IReadOnlyList(Of Playlist)
        Get
            Return _Playlists.AsReadOnly
        End Get
    End Property

    Public Function Add(Playlist As Playlist) As Playlist
        If Not Contains(Playlist) Then
            _Playlists.Add(Playlist)
        End If
        AddHandler Playlist.CollectionChanged, PlaylistCollectionChangedEventHandler
        RaiseEvent CollectionChanged()
        Return Playlist
    End Function

    Public Sub Remove(Playlist As Playlist)
        If Contains(Playlist) Then

            _Playlists.Remove(Playlist)
            RemoveHandler Playlist.CollectionChanged, PlaylistCollectionChangedEventHandler

            Dim f As IO.FileInfo = PlaylistStore.GetFile(Playlist.ID.ToString + ".xml")

            If f.Exists Then
                If My.Settings.DeletePlaylistsPermanently Then
                    f.Delete()
                Else
                    My.Computer.FileSystem.DeleteFile(f.FullName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
                End If
            End If

            RaiseEvent CollectionChanged()

        End If
    End Sub

    Public Function Contains(Playlist As Playlist)
        Return Playlists.Contains(Playlist)
    End Function

    Public Function Find(Video As Video) As Playlist
        For Each p In Playlists
            If p.Contains(Video) Then
                Return p
            End If
        Next
        Return Nothing
    End Function

    Public Function IndexOf(Playlist As Playlist) As Integer
        Dim i As Integer = 0
        For Each p In Playlists
            If p Is Playlist Then
                Return i
            End If
            i += 1
        Next
        Return -1
    End Function

    Private PlaylistCollectionChangedEventHandler As New  _
        Playlist.CollectionChangedEventHandler(AddressOf Playlist_CollectionChanged)

    Private Sub Playlist_CollectionChanged(Playlist As Playlist)
        RaiseEvent PlaylistChanged(Playlist)
    End Sub

#End Region
#Region "Play"

    Public Sub PlayVideo(Video As Video)
        If Video Is Nothing Then
            Throw New ArgumentNullException
        End If
        Dim p As Playlist = Find(Video)
        If p IsNot Nothing Then
            _Play(Video, Find(Video))
        Else
            _Play(Video, TempPlaylist)
        End If
    End Sub

    Public Sub PlayPlaylist(Playlist As Playlist)
        If Playlist Is Nothing Then
            Throw New ArgumentNullException
        End If
        PlayPlaylist(Playlist, 0)
    End Sub

    Public Sub PlayPlaylist(Playlist As Playlist, Index As Integer)
        If Playlist Is Nothing Then
            Throw New ArgumentNullException
        End If
        If Playlist.Videos.Count = 0 Then
            Throw New ArgumentException
        End If
        _Play(Playlist.Videos(0), Playlist)
    End Sub

    Private Sub _Play(Video As Video, Playlist As Playlist)

        _CurrentlyPlaying = Video
        If Playlist IsNot Nothing Then
            _CurrentlyPlayingPlaylist = Playlist
        Else
            _CurrentlyPlayingPlaylist = TempPlaylist
        End If

        RaiseEvent VideoPlay(Video, Playlist)

    End Sub

    Public Sub StopVideo()
        If _CurrentlyPlaying IsNot Nothing Then
            _CurrentlyPlaying = Nothing
        End If
        If _CurrentlyPlayingPlaylist IsNot Nothing Then
            _CurrentlyPlayingPlaylist = Nothing
        End If
        RaiseEvent VideoStop()
    End Sub

#End Region

End Class
