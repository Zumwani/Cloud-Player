Imports System.Xml
Imports System.IO
Imports Google.Apis.YouTube.v3

Public Class PlaylistFactory

    Public Shared Function CreateNew() As Playlist
        Return CreateNew("My Playlist", "")
    End Function

    Public Shared Function CreateNew(Title As String, Thumbnail As String) As Playlist
        Return New Playlist(Title, Thumbnail)
    End Function

    Public Shared Function CreateFromYouTubePlaylist(Playlist As Data.SearchResult, GetVideos As Boolean) As Playlist

        With Playlist

            Dim thumb As String = ""
            If .Snippet.Thumbnails.Default IsNot Nothing Then
                thumb = .Snippet.Thumbnails.Default.Url
            End If

            Dim p As Playlist = CreateNew(.Snippet.Title, thumb)

            If GetVideos Then

                Dim request As New Google.Apis.YouTube.v3.PlaylistItemsResource.ListRequest(YouTubeService, "contentDetails")
                request.PlaylistId = .Id.PlaylistId
                request.MaxResults = 50

                For Each vid In GetAllResults(request)

                    Dim vrequest As New Google.Apis.YouTube.v3.VideosResource.ListRequest(YouTubeService, "snippet")
                    vrequest.MaxResults = 1
                    vrequest.Id = vid.ContentDetails.VideoId

                    Dim vresponse = vrequest.Execute
                    If vresponse.Items.Count = 1 Then
                        p.Add(VideoFactory.CreateFromYouTubeVideo(vresponse.Items(0)))
                    End If

                Next

            End If

            Return p

        End With

    End Function

    Public Shared Function CreateFromYouTubePlaylist(Playlist As Data.Playlist, GetVideos As Boolean) As Playlist

        With Playlist

            Dim thumb As String = ""
            If .Snippet.Thumbnails.Default IsNot Nothing Then
                thumb = .Snippet.Thumbnails.Default.Url
            End If

            Dim p As Playlist = CreateNew(.Snippet.Title, thumb)

            If GetVideos Then

                Dim request As New Google.Apis.YouTube.v3.PlaylistItemsResource.ListRequest(YouTubeService, "contentDetails")
                request.PlaylistId = .Id
                request.MaxResults = 50

                For Each vid In GetAllResults(request)

                    Dim vrequest As New Google.Apis.YouTube.v3.VideosResource.ListRequest(YouTubeService, "snippet")
                    vrequest.MaxResults = 1
                    vrequest.Id = vid.ContentDetails.VideoId

                    Dim vresponse = vrequest.Execute
                    If vresponse.Items.Count = 1 Then
                        p.Add(VideoFactory.CreateFromYouTubeVideo(vresponse.Items(0)))
                    End If

                Next

            End If

            Return p

        End With

    End Function

    Private Shared Function GetAllResults(Request As Google.Apis.YouTube.v3.PlaylistItemsResource.ListRequest) As List(Of Data.PlaylistItem)

        Dim l As New List(Of Data.PlaylistItem)

        Request.PageToken = ""
        Dim response As Data.PlaylistItemListResponse = Request.Execute

        l.AddRange(response.Items)

        'TODO: See if there is a better way
        For i As Integer = 2 To 100
            If Not response.NextPageToken = "" Then
                Request.PageToken = response.NextPageToken
                response = Request.Execute
                l.AddRange(response.Items)
            End If
        Next

        Return l

    End Function

    'Public Shared Function CreateFromNicoNicoMyList(MyList As MyList) As Playlist

    '    Dim p As Playlist = CreateNew(MyList.Title, "")

    '    For Each id In MyList.Videos
    '        p.Add(VideoFactory.CreateFromNicoNicoVideo(NND.Net.Video.FromID(id ))
    '    Next

    '    Return p

    'End Function

    'Public Shared Function CreateFromSoundCloudSet([Set] As soundcloudset) As Playlist



    'save playlist

    'End Function

    Public Shared Function FromDisk(File As FileInfo) As Playlist
        If File.Extension = ".pl" Then
            If File.Exists Then

                Dim xml As New XmlDocument
                xml.Load(File.FullName)

                Return PlaylistGenerator.Load(File)

            Else
                Throw New FileNotFoundException
            End If
        Else
            Throw New ArgumentException("File was not a valid playlist file.")
        End If
    End Function

End Class
