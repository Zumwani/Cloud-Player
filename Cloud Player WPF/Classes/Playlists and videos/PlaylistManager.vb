Imports System.Xml
Imports System.IO
Imports System.Collections.ObjectModel
Imports System.ComponentModel

<System.ComponentModel.DefaultProperty("Playlist")> _
Public Class PlaylistManager
    Inherits DependencyObject

#Region "Properties and events"

    Public Event VideoPlay(Video As Video, Playlist As Playlist)
    Public Event VideoStop()
    Public Event CollectionChanged()
    Public Event PlaylistChanged(Playlist As Playlist)

    Public Shared ReadOnly CurrentPlaylistProperty As DependencyProperty = DependencyProperty.Register("CurrentPlaylist", GetType(Playlist), GetType(PlaylistManager))
    Public Shared ReadOnly CurrentlyPlayingVideoProperty As DependencyProperty = DependencyProperty.Register("CurrentlyPlayingVideo", GetType(Video), GetType(PlaylistManager))

    Private Shared _TempPlaylist As New Playlist("", "")
    Public Shared ReadOnly Property TempPlaylist As Playlist
        Get
            Return _TempPlaylist
        End Get
    End Property

    Public ReadOnly Property CurrentlyPlayingVideo As Video
        Get
            Return Me.GetValue(CurrentlyPlayingVideoProperty)
        End Get
    End Property

    Private Sub setCurrentlyPlayingVideo(Video As Video)
        Me.SetValue(CurrentlyPlayingVideoProperty, Video)
    End Sub

    Public ReadOnly Property CurrentlyPlaylist As Playlist
        Get
            Return Me.GetValue(CurrentPlaylistProperty)
        End Get
    End Property

    Private Sub setCurrentPlaylist(Playlist As Playlist)
        Me.SetValue(CurrentPlaylistProperty, Playlist)
    End Sub

#End Region
#Region "Methods"

    Public Function Import(File As FileInfo) As Playlist
        Return Add(PlaylistGenerator.Load(File))
    End Function

    Public Sub Export(Playlist As Playlist, Directory As DirectoryInfo)
        Dim file As New FileInfo(Playlist.GetLocation)
        'file.CopyTo()
        'PlaylistGenerator.Save(Directory + )
    End Sub

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

    Private _Playlists As New ObservableCollection(Of Playlist)
    Public ReadOnly Property Playlists As ObservableCollection(Of Playlist)
        Get
            Return _Playlists
        End Get
    End Property

    Public Function Add(Playlist As Playlist) As Playlist
        If Not Contains(Playlist) Then
            Playlists.Add(Playlist)
        End If
        AddHandler Playlist.CollectionChanged, PlaylistCollectionChangedEventHandler
        RaiseEvent CollectionChanged()
        Return Playlist
    End Function

    Public Sub Remove(Playlist As Playlist)
        If Contains(Playlist) Then

            Playlists.Remove(Playlist)
            RemoveHandler Playlist.CollectionChanged, PlaylistCollectionChangedEventHandler

            Dim f As IO.FileInfo = PlaylistStore.GetFile(Playlist.ID.ToString + ".pl")

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

        setCurrentlyPlayingVideo(Video)
        If Playlist IsNot Nothing Then
            setCurrentPlaylist(Playlist)
        Else
            setCurrentPlaylist(TempPlaylist)
        End If

        RaiseEvent VideoPlay(Video, Playlist)

    End Sub

    Public Sub StopVideo()
        If CurrentlyPlayingVideo IsNot Nothing Then
            setCurrentlyPlayingVideo(Nothing)
        End If
        If CurrentlyPlaylist IsNot Nothing Then
            setCurrentPlaylist(Nothing)
        End If
        RaiseEvent VideoStop()
    End Sub

#End Region

End Class
