Imports System.Xml
Imports System.IO
Imports System.Collections.ObjectModel
Imports System.ComponentModel

<System.ComponentModel.DefaultProperty("Playlist")> _
Public Class PlaylistManager
    Implements INotifyPropertyChanged

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

#Region "Properties and events"

    Public Event PlayVideo(Video As Video)

    Private Shared _TempPlaylist As New Playlist("", "")
    Public Shared ReadOnly Property TempPlaylist As Playlist
        Get
            Return _TempPlaylist
        End Get
    End Property

    Private _CurrentlyPlayingVideo As Video
    Public ReadOnly Property CurrentlyPlayingVideo As Video
        Get
            Return _CurrentlyPlayingVideo
        End Get
    End Property

    Private _CurrentlyPlayingPlaylist As Playlist
    Public ReadOnly Property CurrentlyPlayingPlaylist As Playlist
        Get
            Return _CurrentlyPlayingPlaylist
        End Get
    End Property

#End Region
#Region "Import / export"

    ''' <summary>Imports the specified playlists. Will return null if none could be imported.</summary>
    Public Function Import(Sources As Uri()) As Playlist()

        Dim d As New PlaylistLoader
        Dim pl As Playlist() = d.ShowDialog(Sources)

        If Not pl.Count = 0 Then
            AddRange(pl)
            Return pl
        Else
            Return Nothing
        End If

    End Function

    Public Sub Export(Playlist As Playlist, Directory As DirectoryInfo)
        'TODO: fix (create pick folder dialog)
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
            'AddHandler Playlist.CollectionChanged, PlaylistCollectionChangedEventHandler
            'RaiseEvent CollectionChanged()
        End If
        Return Playlist
    End Function

    Public Sub AddRange(Playlists As Playlist())
        For Each pl In Playlists
            Add(pl)
        Next
    End Sub

    Public Sub Remove(Playlist As Playlist)
        If Contains(Playlist) Then

            Playlists.Remove(Playlist)
            'RemoveHandler Playlist.CollectionChanged, PlaylistCollectionChangedEventHandler

            Dim f As New IO.FileInfo(PlaylistStore.FullName + "\" + Playlist.ID.ToString + ".xml")

            If f.Exists Then
                If My.Settings.DeletePlaylistsPermanently Then
                    f.Delete()
                Else
                    My.Computer.FileSystem.DeleteFile(f.FullName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
                End If
            End If

            'RaiseEvent CollectionChanged()

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

    'Private PlaylistCollectionChangedEventHandler As New  _
    '    Playlist.CollectionChangedEventHandler(AddressOf Playlist_CollectionChanged)

    'Private Sub Playlist_CollectionChanged(Playlist As Playlist)
    '    RaiseEvent PlaylistChanged(Playlist)
    'End Sub

#End Region
#Region "Play"

    ''' <summary>Plays the specified video, and optionally specifies what playlist to open.</summary>
    Public Sub Play(Video As Video, Optional Playlist As Playlist = Nothing)

        _CurrentlyPlayingVideo = Video
        _CurrentlyPlayingPlaylist = Playlist

        RaiseEvent PlayVideo(Video)

        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("CurrentlyPlayingVideo"))
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("CurrentlyPlayingPlaylist"))

    End Sub

    ''' <summary>Plays the playlist starting at the specified start index.</summary>
    Public Sub Play(Playlist As Playlist, Optional StartIndex As Integer = 0)

        If Not Playlist.Videos.Count = 0 Then

            'Wrap around
            If StartIndex < 0 Then
                StartIndex = Playlist.Videos.Count - 1
            End If
            If StartIndex > Playlist.Videos.Count - 1 Then
                StartIndex = 0
            End If

            _CurrentlyPlayingVideo = Playlist.Videos(StartIndex)

        Else
            _CurrentlyPlayingVideo = Nothing
        End If

        _CurrentlyPlayingPlaylist = Playlist

        RaiseEvent PlayVideo(_CurrentlyPlayingVideo)

        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("CurrentlyPlayingVideo"))
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("CurrentlyPlayingPlaylist"))

    End Sub

    'Public Sub Play(Video As Video)

    '    If Video Is Nothing Then
    '        Throw New ArgumentNullException
    '    End If

    '    Dim p As Playlist = Find(Video)

    '    If p IsNot Nothing Then
    '        _Play(Video, p)
    '    Else
    '        _Play(Video, TempPlaylist)
    '    End If

    'End Sub

    'Public Sub Play(Playlist As Playlist)
    '    If Playlist Is Nothing Then
    '        Throw New ArgumentNullException
    '    End If
    '    Play(Playlist, 0)
    'End Sub

    'Public Sub Play(Playlist As Playlist, Index As Integer)
    '    If Playlist Is Nothing Then
    '        Throw New ArgumentNullException
    '    End If
    '    If Playlist.Videos.Count = 0 Then
    '        Throw New ArgumentException
    '    End If
    '    _Play(Playlist.Videos(0), Playlist)
    'End Sub

    'Private Sub _Play(Video As Video, Playlist As Playlist)

    '    setCurrentlyPlayingVideo(Video)
    '    If Playlist IsNot Nothing Then
    '        setCurrentPlaylist(Playlist)
    '    Else
    '        setCurrentPlaylist(TempPlaylist)
    '    End If

    '    RaiseEvent VideoPlay(Video, Playlist)

    'End Sub

    'Public Sub StopVideo()
    '    If CurrentlyPlayingVideo IsNot Nothing Then
    '        setCurrentlyPlayingVideo(Nothing)
    '    End If
    '    If CurrentlyPlaylist IsNot Nothing Then
    '        setCurrentPlaylist(Nothing)
    '    End If
    '    RaiseEvent VideoStop()
    'End Sub

#End Region

End Class