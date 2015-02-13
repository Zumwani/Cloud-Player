Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Threading
Imports System.Globalization

Public Class SplashScreen
    Inherits Zumwani.CommonLibrary.Templates.Window

    Public CanContinue As Boolean = False

    Public Sub SetProgress(Progress As Integer)

        If Me.InvokeRequired Then
            Me.BeginInvoke(Sub() SetProgress(Progress))
            Return
        End If

        ProgressBar1.Value = Progress
        If Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.IsPlatformSupported Then
            Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.Instance.SetProgressValue(Progress, 100)
        End If

    End Sub

    Public Sub ShowUpgrade(File As FileInfo, GeneratorVersion As String, PlaylistVersion As String)

        If Me.InvokeRequired() Then
            Me.BeginInvoke(Sub() ShowUpgrade(File, GeneratorVersion, PlaylistVersion))
            Return
        End If

        CanContinue = False

        _File = File

        UpgradeMessageLabel.Text = String.Format(Locale.SplashScreen_Upgrade, File.Name, GeneratorVersion, PlaylistVersion)

        PanoramaTabControl1.SelectedTab = UpgradeTab
        Me.Size = Me.MaximumSize

    End Sub

    Public Sub ShowError(File As FileInfo, GeneratorVersion As String, ErrorMessage As String)

        If Me.InvokeRequired() Then
            Me.BeginInvoke(Sub() ShowError(File, GeneratorVersion, ErrorMessage))
            Return
        End If

        CanContinue = False

        _File = File

        ErrorMessageLabel.Text = String.Format(Locale.SplashScreen_Error, File.Name, GeneratorVersion, ErrorMessage)

        PanoramaTabControl1.SelectedTab = ErrorTab
        Me.Size = Me.MaximumSize

    End Sub

#Region "Window"

    Private Sub SplashScreen_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Size = Me.MinimumSize
        CanContinue = True
    End Sub

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
#Region "UI and UI functionality"

    Private _File As FileInfo

    Private Sub ErrorIgnoreButton_Click(sender As Object, e As EventArgs) Handles ErrorIgnoreButton.Click
        CanContinue = True
    End Sub

    Private Sub ErrorDeleteButton_Click(sender As Object, e As EventArgs) Handles ErrorDeleteButton.Click
        If _File.Exists Then
            _File.MoveToRecycleBin()
        End If
        CanContinue = True
    End Sub

    Private Sub ErrorOKButton_Click(sender As Object, e As EventArgs) Handles ErrorOKButton.Click
        CanContinue = True
    End Sub

    Private Sub UpgradeIgnoreButton_Click(sender As Object, e As EventArgs) Handles UpgradeIgnoreButton.Click
        CanContinue = True
    End Sub

    Private Sub UpgradeDeleteButton_Click(sender As Object, e As EventArgs) Handles UpgradeDeleteButton.Click
        If _File.Exists Then
            _File.MoveToRecycleBin()
        End If
        CanContinue = True
    End Sub

    Private Sub UpgradeUpgradeButton_Click(sender As Object, e As EventArgs) Handles UpgradeUpgradeButton.Click
        PlaylistGenerator.UpgradePlaylist(_File.FullName)
        PlaylistGenerator.Load(_File)
        CanContinue = True
    End Sub

    Private i As Integer = 1
    Private Sub DotTimer_Tick(sender As Object, e As EventArgs) Handles DotTimer.Tick

        If Me.InvokeRequired Then
            Me.BeginInvoke(Sub() DotTimer_Tick(sender, e))
            Return
        End If

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

End Class