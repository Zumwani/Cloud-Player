Imports System.Xml
Imports System.IO
Imports Microsoft.WindowsAPICodePack.Shell

Public Class VideoFactory

    Public Shared Function FromMediaFile(File As FileInfo, Optional ThrowOnNotExist As Boolean = True) As Video

        If File.Exists Then

            Dim bitmapfilename As String = ThumbnailStore.FullName + "\" + Guid.NewGuid.ToString + ".png"
            Dim b As BitmapImage = GetFileThumbnail(File.FullName).ToBitmapImage(New FileInfo(bitmapfilename))

            Return New Video(New Uri(File.FullName), "Disk", File.Name, Environment.UserName, GetVideoFileLength(File.FullName), bitmapfilename)

        Else
            If ThrowOnNotExist Then
                Throw New FileNotFoundException
            Else
                Return Nothing
            End If
        End If

    End Function

    Public Shared Function CreateFromYouTubeVideo(Video As Google.Apis.YouTube.v3.Data.SearchResult) As Video
        With Video.Snippet
            Return New Video(GetYouTubeEmbedLink(Video.Id.VideoId), "YouTube", .Title, .ChannelTitle, Nothing, .Thumbnails.Default.Url)
        End With
    End Function

    Public Shared Function CreateFromYouTubeVideo(Video As Google.Apis.YouTube.v3.Data.PlaylistItem) As Video
        With Video.Snippet
            Return New Video(GetYouTubeEmbedLink(Video.Id), "YouTube", .Title, .ChannelTitle, Nothing, .Thumbnails.Default.Url)
        End With
    End Function

    Public Shared Function CreateFromYouTubeVideo(Video As Google.Apis.YouTube.v3.Data.Video) As Video
        With Video.Snippet
            Return New Video(GetYouTubeEmbedLink(Video.Id), "YouTube", .Title, .ChannelTitle, Nothing, .Thumbnails.Default.Url)
        End With
    End Function

    'Public Shared Function CreateFromNicoNicoVideo(Video As NND.Net.Video) As Video
    '    With Video
    '        Return New Video(NND.Net.Video.)
    '    End With
    'End Function

    'Public Shared Function CreateFromSoundCloudTrack(Track As SoundCloud.NET.Track) As Video
    '    With Track
    '        Return New Video(New Uri(.StreamUrl), "SoundCloud", .Title, .User.UserName, Nothing, "")
    '    End With
    'End Function

    Private Shared Function GetVideoFileLength(File As String) As TimeSpan

        'Using WindowsApiCodePack
        Dim so As ShellFile = ShellFile.FromFilePath(File)
        Dim nanoseconds As Double
        Double.TryParse(so.Properties.System.Media.Duration.Value.ToString(), nanoseconds)

        Return New TimeSpan(nanoseconds)

    End Function

    Private Shared Function GetFileThumbnail(File As String) As BitmapSource

        'Using WindowsApiCodePack
        Dim so As ShellFile = ShellFile.FromFilePath(File)
        Dim b As BitmapSource = so.Thumbnail.BitmapSource

        Return b

    End Function

    Public Shared Function GetYouTubeEmbedLink(VideoID As String) As Uri
        'Return My.Resources.YouTubeEmbedLink + VideoID + "?" + My.Resources.YouTubeAutoplayParam
    End Function

End Class
