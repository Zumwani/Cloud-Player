Public Class Cache

    Private Shared ReadOnly Videos As New List(Of YouTubeVideo)
    Private Shared ReadOnly Playlists As New List(Of YouTubePlaylist)
    Private Shared ReadOnly Channels As New List(Of YouTubeChannel)

    Private Shared ReadOnly Categories As New List(Of Misc.YouTubeCategory)

    Friend Shared Function GetVideo(ID As YouTubeID) As YouTubeVideo
        For Each v In Videos
            If v.ID = ID Then
                Return v
            End If
        Next
        Return Nothing
    End Function

    Friend Shared Function GetPlaylist(ID As YouTubeID) As YouTubePlaylist
        For Each p In Playlists
            If p.ID = ID Then
                Return p
            End If
        Next
        Return Nothing
    End Function

    Friend Shared Function GetChannel(ID As YouTubeID) As YouTubeChannel
        For Each c In Channels
            If c.ID = ID Then
                Return c
            End If
        Next
        Return Nothing
    End Function

    Friend Shared Function GetCategory(Name As String) As Misc.YouTubeCategory
        For Each c In Categories
            If c.Name = Name Then
                Return c
            End If
        Next
        Return Nothing
    End Function

    Friend Shared Sub AddVideo(Video As YouTubeVideo)
        If Not VideoExists(Video.ID) Then
            Videos.Add(Video)
        End If
    End Sub

    Friend Shared Sub AddPlaylist(Playlist As YouTubePlaylist)
        If Not VideoExists(Playlist.ID) Then
            Playlists.Add(Playlist)
        End If
    End Sub

    Friend Shared Sub AddChannel(Channel As YouTubeChannel)
        If Not VideoExists(Channel.ID) Then
            Channels.Add(Channel)
        End If
    End Sub

    Friend Shared Sub AddCategory(Category As Misc.YouTubeCategory)
        If Not CategoryExists(Category.Name) Then
            Categories.Add(Category)
        End If
    End Sub

    Friend Shared Sub RemoveVideo(Video As YouTubeVideo)
        If VideoExists(Video.ID) Then
            Videos.Remove(Video)
        End If
    End Sub

    Friend Shared Sub RemovePlaylist(Playlist As YouTubePlaylist)
        If VideoExists(Playlist.ID) Then
            Playlists.Remove(Playlist)
        End If
    End Sub

    Friend Shared Sub RemoveChannel(Channel As YouTubeChannel)
        If VideoExists(Channel.ID) Then
            Channels.Remove(Channel)
        End If
    End Sub

    Friend Shared Sub RemoveCategory(Category As Misc.YouTubeCategory)
        If CategoryExists(Category.Name) Then
            Categories.Remove(Category)
        End If
    End Sub

    Friend Shared Function VideoExists(ID As YouTubeID) As Boolean
        For Each v In Videos
            If v.ID = ID Then Return True
        Next
        Return False
    End Function

    Friend Shared Function PlaylistExists(ID As YouTubeID) As Boolean
        For Each p In Playlists
            If p.ID = ID Then Return True
        Next
        Return False
    End Function

    Friend Shared Function ChannelExists(ID As YouTubeID) As Boolean
        For Each c In Channels
            If c.ID = ID Then Return True
        Next
        Return False
    End Function

    Friend Shared Function CategoryExists(Name As String) As Boolean
        For Each c In Categories
            If c.Name = Name Then Return True
        Next
        Return False
    End Function

    ''' <summary>Clears the cache, removing all references to videos, playlists and channels.</summary>
    Public Shared Sub Clear(Optional Dispose As Boolean = False)
        If Dispose Then
            For Each vid In Videos
                vid.Dispose()
            Next
            For Each pl In Playlists
                pl.Dispose()
            Next
            For Each ch In Channels
                ch.Dispose()
            Next
            For Each cat In Categories
                cat.Dispose()
            Next
        Else
            Videos.Clear()
            Playlists.Clear()
            Channels.Clear()
            Categories.Clear()
        End If
    End Sub

End Class
