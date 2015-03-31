Imports System.IO
Imports System.Net
Imports System.Text

Public Module App

    '<filename> /gitusername/repo "c:\..." tag
    Public Const CompareModeTagParam As String = "tag"
    Public Const CompareModeDateParam As String = "date"
    Public Const SuppressWarningParam As String = "nowarn"

    Public Function Main(Args As String()) As Integer

        If Not Args.Count >= 3 Then
            Log.Write("Not all arguments set.")
            Return 0
        End If

        Dim GitRepo As String = Args(0)
        Dim ExePath As String = Args(1).Replace(ControlChars.Quote, "")
        Dim CompareMode As CompareMode = App.CompareMode.None

        If Args(2) = CompareModeTagParam Then
            CompareMode = App.CompareMode.Tag
        ElseIf Args(2) = CompareModeDateParam Then
            CompareMode = App.CompareMode.Date
        End If


        If ExePath.First = "\" Then
            ExePath = Application.StartupPath + ExePath
        End If

        If ValidateArguments(GitRepo, ExePath, CompareMode) = False Then
            Return 0
        End If

        Try

            If Not UpdateAvailable(GitRepo, CompareMode, ExePath) Then
                Log.Write("No update available.")
                Return 1
            Else

                If Args.Contains(SuppressWarningParam) Then

                    Console.WriteLine("This will update the application, are you sure you want to continue?" + vbNewLine + _
                          "This will automatically close the application down if it is running." + vbNewLine + vbNewLine + _
                          "Press Enter to continue...")

                    If Console.ReadKey.Key = ConsoleKey.Enter Then

                    End If

                End If

            End If

        Catch ex As Exception
            Log.Write(ex.Message)
        End Try

    End Function

    Private Function ValidateRepo(RepoString As String) As Boolean

        If Not RepoString.Contains("/") Then
            Return False
        End If

        Try

            Dim a As New Octokit.ReleasesClient(GetConnection(RepoString.Split("/").Last))
            Dim l As New List(Of Octokit.Release)

            For Each release In a.GetAll(RepoString.Split("/").First, RepoString.Split("/").Last).Result
                If Not release.Prerelease Then
                    l.Add(release)
                End If
            Next

        Catch ex As Octokit.NotFoundException
            Return False
        End Try

        Return True

    End Function

    Private Function ValidateArguments(GitRepo As String, ExePath As String, CompareMode As CompareMode) As Boolean

        If Not ValidateRepo(GitRepo) Then
            Log.Write("Gitrepo is not valid.")
            Return False
        End If

        Try
            GetConnection(GitRepo.Split("/").Last)
        Catch ex As Octokit.NotFoundException
            Log.Write("The git repo '" + GitRepo.Split("/").Last + "' does not exist.")
            Return False
        End Try

        If Not File.Exists(ExePath) Then
            Log.Write("Exepath points to a non-existing file.")
            Return False
        End If

        If CompareMode = App.CompareMode.None Then
            Log.Write("No comparemode set.")
            Return False
        End If

        Return True

    End Function

    Public Enum CompareMode
        None = 0
        Tag = 1
        [Date] = 2
    End Enum

    <Runtime.CompilerServices.Extension()> _
    Public Function Split(ByVal input As String, ByVal ParamArray delimiter As String()) As String()
        Return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)
    End Function

    Public Function UpdateAvailable(Repo As String, CompareMode As CompareMode, ExePath As String) As Boolean

        Dim Owner As String = Repo.Split("/").First
        Dim Productname As String = Repo.Split("/").Last

        Return (UpdateAvailable(Owner, Productname, CompareMode, ExePath))

    End Function

    Public Function UpdateAvailable(Owner As String, Productname As String, CompareMode As CompareMode, ExePath As String) As Boolean

        Dim InstalledVersion As String = ""
        Dim NewestVersion As String = ""

        If CompareMode = App.CompareMode.Tag Then
            InstalledVersion = GetInstalledVersion(ExePath)
            NewestVersion = GetNewestVersion(Owner, Productname, CompareMode)

        ElseIf CompareMode = App.CompareMode.Date Then
            InstalledVersion = GetInstallDate(ExePath)
            NewestVersion = GetNewestVersion(Owner, Productname, CompareMode)
        End If


        If InstalledVersion = "" Then
            Throw New ArgumentException("Could not get installed version")
        End If

        If NewestVersion = "" Or NewestVersion = "0.0" Then
            Throw New ArgumentException("Could not get newest version")
        End If

        Return (NewestVersion > InstalledVersion)

    End Function

    Public Function GetInstalledVersion(ExePath As String) As String

        Dim file As New FileInfo(ExePath)

        If file.Exists Then

            Dim fvi As FileVersionInfo = FileVersionInfo.GetVersionInfo(file.FullName)

            If fvi IsNot Nothing Then
                Return fvi.ProductVersion
            End If

        End If

        Throw New FileNotFoundException("Could not find executable.")

    End Function

    Public Function GetInstallDate(ExePath As String) As String

        Dim file As New FileInfo(ExePath)

        If file.Exists Then

            If Not file.LastWriteTime = Date.MinValue Then
                Return file.LastWriteTime.ToString
            Else
                Throw New ArgumentException("Could not get date")
            End If

        End If

        Throw New FileNotFoundException("Could not find executable.")

    End Function

    Private Function GetConnection(ProductName As String) As Octokit.ApiConnection
        Dim GitProduct As New Octokit.ProductHeaderValue(ProductName)
        Dim conn As New Octokit.Connection(GitProduct)
        Return New Octokit.ApiConnection(conn)
    End Function

    Public Function GetNewestVersion(Repo As String, CompareMode As CompareMode) As String

        Try

            Dim owner As String = Repo.Split("/").First
            Dim productname As String = Repo.Split("/").Last

            Return GetNewestVersion(owner, productname, CompareMode)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GetNewestVersion(Owner As String, Productname As String, CompareMode As CompareMode) As String

        Try

            Dim a As New Octokit.ReleasesClient(GetConnection(Productname))
            Dim l As New List(Of Octokit.Release)

            For Each release In a.GetAll(Owner, Productname).Result
                If Not release.Prerelease Then
                    l.Add(release)
                End If
            Next

            If CompareMode = App.CompareMode.Tag Then
                l.Sort(Function(left As Octokit.Release, right As Octokit.Release) String.Compare(left.TagName, right.TagName))
            ElseIf CompareMode = App.CompareMode.Date Then
                l.Sort(Function(left As Octokit.Release, right As Octokit.Release) DateTimeOffset.Compare(left.PublishedAt, right.PublishedAt))
            Else
                Throw New ArgumentException("Mode not set")
            End If

            If Not l.Count = 0 Then
                If CompareMode = App.CompareMode.Tag Then
                    Return l(0).TagName
                ElseIf CompareMode = App.CompareMode.Date Then
                    Return l(0).PublishedAt.ToString
                Else
                    Throw New ArgumentException("Mode not set")
                End If
            Else
                Return "0.0"
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Event ProgressChanged(ProgressInfo As ProgressInfo)

    Public Sub PerformUpdate()

    End Sub

    Private Sub Download(Filename As FileInfo)

    End Sub

    Private Sub CloseApp()

    End Sub

    Private Sub CopyFiles()

    End Sub

    Public Class ProgressInfo

        Sub New(Stage As ProgressStage, Progress As Integer)
            Me.Stage = Stage
            Me.Progress = Progress
        End Sub

        Public Enum ProgressStage
            None = 0
            Download = 1
            KillApp = 2
            CopyFiles = 3
            CleanUp = 4
        End Enum

        Public Property Stage As ProgressStage
        Public Property Progress As Integer

        Public Property Message As String

        Public Function OverallProgress() As Integer
            Return (Progress * Stage)
        End Function

    End Class

End Module
