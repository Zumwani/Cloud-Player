Imports System.Runtime.CompilerServices
Imports System.IO
Imports Google.Apis.YouTube.v3
Imports Google.Apis
Imports System.Reflection
Imports System.Resources

Module ExtensionMethods

    ''' <summary>Gets a fileinfo object from the specified file inside the directory.</summary>
    <Extension> _
    Public Function GetFile(DirectoryInfo As DirectoryInfo, File As String) As FileInfo
        Return New FileInfo(DirectoryInfo.FullName + "\" + File)
    End Function

    Public Function ParseRectangleString(Str As String) As Rectangle

        If Not Str = "" Then

            Dim x, y, w, h As Integer

            For Each s In Str.Remove(Str.Length - 1, 1).Split(",")
                If s.Contains("X") Then x = CType(s.Split("=").Last, Integer)
                If s.Contains("Y") Then y = CType(s.Split("=").Last, Integer)
                If s.Contains("Width") Then w = CType(s.Split("=").Last, Integer)
                If s.Contains("Height") Then h = CType(s.Split("=").Last, Integer)
            Next

            Return New Rectangle(x, y, w, h)

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

    ''' <summary>Returns a value that indicates if the path string is local.</summary>
    <Extension>
    Public Function PathIsLocal(Str As String) As Boolean
        If Uri.IsWellFormedUriString(Str, UriKind.Absolute) Then
            If Str.Contains("file://") Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function

    ''' <summary>Gets the screen to the left.</summary>
    <Extension>
    Public Function GetScreenToLeft(Scr As Screen) As Screen
        Dim x As Integer = Scr.Bounds.Left - 10
        For Each s In Screen.AllScreens
            If s IsNot Scr Then
                If s.Bounds.Contains(x, s.Bounds.Top) Then
                    Return s
                End If
            End If
        Next
        Return Nothing
    End Function

    ''' <summary>Gets the screen to the right.</summary>
    <Extension>
    Public Function GetScreenToRight(Scr As Screen) As Screen
        Dim x As Integer = Scr.Bounds.Right + 10
        For Each s In Screen.AllScreens
            If s IsNot Scr Then
                If s.Bounds.Contains(x, s.Bounds.Top) Then
                    Return s
                End If
            End If
        Next
        Return Nothing
    End Function

    ''' <summary>Gets the index of this screen.</summary>
    <Extension>
    Public Function Index(Scr As Screen) As Integer
        Dim i As Integer = 0
        For Each s In Screen.AllScreens
            If s Is Scr Then
                Return i
            End If
            i += 1
        Next
        Return -1
    End Function

    <Extension()> _
    Public Function Split(ByVal input As String, ByVal ParamArray delimiter As String()) As String()
        Return input.Split(delimiter, StringSplitOptions.None)
    End Function

    <Extension>
    Public Function ToHTMLColor(Color As Color) As String
        Return ColorTranslator.ToHtml(Color)
    End Function

    ' Public ReadOnly YouTubeService As Google.Apis.Services.BaseClientService = _
    'New YouTubeService(New Services.BaseClientService.Initializer With {.ApplicationName = "Cloud Player", .ApiKey = "AIzaSyCVtDXEsF96YRzvVtv5kEzqRuqOymiYQmI"})

    Public ReadOnly SoundCloudClient As New SoundCloud.NET.SoundCloudClient(New SoundCloud.NET.SoundCloudCredentials("454972d9aec9bedff9a95d59a9076411", "1b5f909fbb3a378fbcc5f6ceb7672a86", "andreas.ingeholm@hotmail.com", "0kmyJ5bhEm7Q"))

    Public ReadOnly SettingsDirectory As DirectoryInfo = IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\" + Application.CompanyName + "\" + Application.ProductName)
    Public ReadOnly PlaylistStore As DirectoryInfo = SettingsDirectory.CreateSubdirectory("PlaylistStore")
    Public ReadOnly ThumbnailStore As DirectoryInfo = SettingsDirectory.CreateSubdirectory("ThumbnailStore")
    Public ReadOnly BackupDir As DirectoryInfo = SettingsDirectory.CreateSubdirectory("Backup")

End Module
