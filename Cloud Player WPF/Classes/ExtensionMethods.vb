Imports System.Runtime.CompilerServices
Imports System.IO
Imports Google.Apis.YouTube.v3
Imports Google.Apis
Imports System.Reflection
Imports System.Resources

Module ExtensionMethods

    Public Function ParseRectangleString(Str As String) As Rect

        If Not Str = "" Then

            Dim x, y, w, h As Integer

            For Each s In Str.Remove(Str.Length - 1, 1).Split(",")
                If s.Contains("X") Then x = CType(s.Split("=").Last, Integer)
                If s.Contains("Y") Then y = CType(s.Split("=").Last, Integer)
                If s.Contains("Width") Then w = CType(s.Split("=").Last, Integer)
                If s.Contains("Height") Then h = CType(s.Split("=").Last, Integer)
            Next

            Return New Rect(x, y, w, h)

        Else
            Return Nothing
        End If

    End Function

    ''' <summary>Moves the file to the recycle bin.</summary>
    <Extension>
    Public Sub MoveToRecycleBin(File As FileInfo)
        If File.Exists Then
            My.Computer.FileSystem.DeleteFile(File.FullName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
        End If
    End Sub

    <Extension()> _
    Public Function Split(ByVal input As String, ByVal ParamArray delimiter As String()) As String()
        Return input.Split(delimiter, StringSplitOptions.None)
    End Function

    Public ReadOnly YouTubeService As Google.Apis.Services.BaseClientService = _
   New YouTubeService(New Services.BaseClientService.Initializer With {.ApplicationName = "Cloud Player", .ApiKey = "AIzaSyCVtDXEsF96YRzvVtv5kEzqRuqOymiYQmI"})

    'Public ReadOnly SoundCloudClient As New SoundCloud.NET.SoundCloudClient(New SoundCloud.NET.SoundCloudCredentials("454972d9aec9bedff9a95d59a9076411", "1b5f909fbb3a378fbcc5f6ceb7672a86", "andreas.ingeholm@hotmail.com", "0kmyJ5bhEm7Q"))

    Public ReadOnly SettingsDirectory As DirectoryInfo = IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\" + My.Application.Info.CompanyName + "\" + My.Application.Info.ProductName)
    Public ReadOnly PlaylistStore As DirectoryInfo = SettingsDirectory.CreateSubdirectory("PlaylistStore")
    Public ReadOnly ThumbnailStore As DirectoryInfo = SettingsDirectory.CreateSubdirectory("ThumbnailStore")
    Public ReadOnly BackupDir As DirectoryInfo = SettingsDirectory.CreateSubdirectory("Backup")

    <Extension>
    Public Function ToBitmapImage(ImageSource As ImageSource, Optional SavePath As FileInfo = Nothing) As BitmapImage

        Dim encoder As New JpegBitmapEncoder()
        Dim memoryStream As New MemoryStream()
        Dim bImg As New BitmapImage()

        encoder.Frames.Add(BitmapFrame.Create(ImageSource))
        encoder.Save(memoryStream)

        bImg.BeginInit()
        bImg.StreamSource = New MemoryStream(memoryStream.ToArray())
        If SavePath IsNot Nothing Then
            bImg.StreamSource.SaveToDisk(SavePath)
        End If

        bImg.EndInit()

        memoryStream.Close()

        Return bImg

    End Function

    <Extension>
    Public Sub SaveToDisk(Stream As Stream, Path As FileInfo)
        If Path IsNot Nothing Then
            Path.Directory.Create()
            Using fs As New FileStream(Path.FullName, FileMode.Create)
                Stream.CopyTo(fs)
            End Using
        End If
    End Sub

End Module
