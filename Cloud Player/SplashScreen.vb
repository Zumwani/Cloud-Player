Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Threading
Imports System.Globalization

Public Class SplashScreen
    Inherits Zumwani.CommonLibrary.Templates.Window
    'TODO: Fix localization
#Region "Window"

    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles Me.Load
        If PlaylistStore.GetFiles.Count = 0 Then
            'No need to show form
            MainWindow.PlaylistManager = New PlaylistManager
            MainWindow.Show()
            Close()
        End If
    End Sub

    Private Sub SplashScreen_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Size = Me.MinimumSize
        BackgroundWorker1.RunWorkerAsync()
    End Sub

#End Region
#Region "Work"

    Private Sub PauseWorker()
        WorkerPaused = True
        DotTimer.Stop()
    End Sub

    Private Sub ContinueWorker()
        Me.Size = MinimumSize
        DotTimer.Start()
        _File = Nothing
        WorkerPaused = False
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        'Load all playlists
        BackgroundWorker1.ReportProgress(0)

        Dim pm As New PlaylistManager
        Dim files As FileInfo() = PlaylistStore.GetFiles
        Dim i As Integer = 1

        For Each file In files
            If file.Extension = ".xml" Then
                Try
                    pm.Add(PlaylistGenerator.Load(file, True, False))
                Catch ex As PlaylistGenerator.ParseException
                    If TypeOf ex.InnerException Is NotImplementedException Then
                        'Playlist needs upgrading
                        ShowUpgrade(ex.File, ex.GeneratorVersion, ex.PlaylistVersion)
                        PauseWorker()
                        Do Until Not WorkerPaused
                            Thread.Sleep(100)
                        Loop
                    ElseIf TypeOf ex.InnerException Is Xml.XmlException Then
                        'An error occured
                        ShowError(ex.File, ex.GeneratorVersion, ex.InnerException.Message)
                        PauseWorker()
                        Do Until Not WorkerPaused
                            Thread.Sleep(100)
                        Loop
                    End If
                End Try
            End If
            BackgroundWorker1.ReportProgress(((i / files.Count) * 100))
            i += 1
        Next

        'Done
        BackgroundWorker1.ReportProgress(100)
        e.Result = pm

    End Sub

    Private WorkerPaused As Boolean

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        MainWindow.PlaylistManager = e.Result
        MainWindow.Show()
        Close()
    End Sub

#End Region
#Region "Dots"

    Private i As Integer = 0
    Private Sub DotTimer_Tick(sender As Object, e As EventArgs) Handles DotTimer.Tick

        Select Case i
            Case Is = 0
                LoadingLabel.Text = Locale.Loading

            Case Is = 1
                LoadingLabel.Text = Locale.Loading & "."

            Case Is = 2
                LoadingLabel.Text = Locale.Loading & ".."

            Case Is = 3
                LoadingLabel.Text = Locale.Loading & "..."

        End Select
        If Not i = 3 Then
            i += 1
        Else
            i = 0
        End If

    End Sub

#End Region
#Region "Move form"

    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HT_CAPTION As Integer = &H2
    <DllImportAttribute("user32.dll")> _
    Public Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function
    <DllImportAttribute("user32.dll")> _
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    Private Sub ProgressLabel_MouseDown(sender As Object, e As MouseEventArgs) Handles _
        LoadingLabel.MouseDown, ProgressBar1.MouseDown, Panel1.MouseDown, Panel2.MouseDown, _
        ErrorMessageLabel.MouseDown, ErrorTab.MouseDown, _
        UpgradeMessageLabel.MouseDown, UpgradeTab.MouseDown

        ReleaseCapture()
        SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)

    End Sub

#End Region
#Region "Error + upgrade"

    Private _File As FileInfo

    Private Sub ShowUpgrade(File As FileInfo, GeneratorVersion As String, PlaylistVersion As String)

        If Me.InvokeRequired() Then
            Me.BeginInvoke(Sub() ShowUpgrade(File, GeneratorVersion, PlaylistVersion))
            Return
        End If

        _File = File

        UpgradeMessageLabel.Text = String.Format(Locale.SplashScreen_Upgrade, File.Name, GeneratorVersion, PlaylistVersion)

        PanoramaTabControl1.SelectedTab = UpgradeTab
        Me.Size = Me.MaximumSize

    End Sub

    Private Sub ShowError(File As FileInfo, GeneratorVersion As String, ErrorMessage As String)

        If Me.InvokeRequired() Then
            Me.BeginInvoke(Sub() ShowError(File, GeneratorVersion, ErrorMessage))
            Return
        End If

        _File = File

        ErrorMessageLabel.Text = String.Format(Locale.SplashScreen_Error, File.Name, GeneratorVersion, ErrorMessage)

        PanoramaTabControl1.SelectedTab = ErrorTab
        Me.Size = Me.MaximumSize

    End Sub

    Private Sub ErrorIgnoreButton_Click(sender As Object, e As EventArgs) Handles ErrorIgnoreButton.Click
        ContinueWorker()
    End Sub

    Private Sub ErrorDeleteButton_Click(sender As Object, e As EventArgs) Handles ErrorDeleteButton.Click
        If _File.Exists Then
            _File.MoveToRecycleBin()
        End If
        ContinueWorker()
    End Sub

    Private Sub ErrorOKButton_Click(sender As Object, e As EventArgs) Handles ErrorOKButton.Click
        ContinueWorker()
    End Sub

    Private Sub UpgradeIgnoreButton_Click(sender As Object, e As EventArgs) Handles UpgradeIgnoreButton.Click
        ContinueWorker()
    End Sub

    Private Sub UpgradeDeleteButton_Click(sender As Object, e As EventArgs) Handles UpgradeDeleteButton.Click
        If _File.Exists Then
            _File.MoveToRecycleBin()
        End If
        ContinueWorker()
    End Sub

    Private Sub UpgradeUpgradeButton_Click(sender As Object, e As EventArgs) Handles UpgradeUpgradeButton.Click
        PlaylistGenerator.UpgradePlaylist(_File.FullName)
        PlaylistGenerator.Load(_File)
        ContinueWorker()
    End Sub

#End Region

End Class