Imports WMPLib
Imports Awesomium.Windows.Controls
Imports Awesomium.Core
Imports System.Web

Public Class MediaPlayer
    Inherits Panel

    'Sub New()
    'SetStyle(ControlStyles.UserPaint + ControlStyles.AllPaintingInWmPaint + ControlStyles.OptimizedDoubleBuffer, True)
    'Controls.AddRange({MediaPlayer, Webbrowser})
    'End Sub

    Public Sub Initialize()
        [Stop]()
    End Sub

#Region "Player propeties"

    Public Enum PlayerState
        Stopped = 0
        Playing = 1
        Paused = 2
    End Enum

    Private _State As PlayerState
    Public ReadOnly Property State As PlayerState
        Get
            Return _State
        End Get
    End Property

    Private _Path As String
    Public ReadOnly Property Path As String
        Get
            Return _Path
        End Get
    End Property

    Public Enum PlayerMode
        Local = 0
        Online = 1
    End Enum

    Private _PlayMode As PlayerMode
    Public ReadOnly Property PlayMode As PlayerMode
        Get
            Return _PlayMode
        End Get
    End Property

#End Region
#Region "Play online video"

    Private Webbrowser As New WebControl With {.WebSession = WebCore.CreateWebSession(New WebPreferences() With {.CustomCSS = "body { background-color : rgb(27, 27, 27); }"})} '.Dock = DockStyle.Fill, .BackColor = Me.BackColor, .Visible = False, .WebSession = WebCore.CreateWebSession(New WebPreferences() With {.CustomCSS = "body { background-color : rgb(27, 27, 27); }"})}

    Public Sub PlayVideo(Uri As Uri)

        Me.Stop()
        If Not Uri.OriginalString.Contains("file://") Then

            MediaPlayer.Hide()
            'Webbrowser.Show()
            'Webbrowser.Show()
            Webbrowser.Visibility = Windows.Visibility.Visible
            Webbrowser.Source = Uri
            _Path = Uri.OriginalString
            _State = PlayerState.Playing
            _PlayMode = PlayerMode.Online

        Else
            PlayVideo(HttpUtility.UrlDecode(Uri.OriginalString).Replace("file://", ""))
        End If

    End Sub

#End Region
#Region "Play local video"

    Private WithEvents MediaPlayer As New WindowsMediaPlayer ', .Dock = DockStyle.Fill}

    Public Sub PlayVideo(Path As String)

        Me.Stop()
        If Not Uri.IsWellFormedUriString(Path, UriKind.Absolute) Then

            If IO.File.Exists(Path) Then

                'Webbrowser.Hide()
                Webbrowser.Visibility = Windows.Visibility.Hidden
                MediaPlayer.Show()
                MediaPlayer.URL = Path

                _Path = Path
                _PlayMode = PlayerMode.Local
                _State = PlayerState.Playing

            End If

        Else
            PlayVideo(New Uri(Path))
        End If

    End Sub

    'Private Sub MediaPlayer_ClickEvent(sender As Object, e As _WMPOCXEvents_ClickEvent) Handles MediaPlayer.ClickEvent
    'TODO: Check if actual video is clicked rather than pause when anywhere on control is clicked (incl. playercontrols)
    'Dim perform As Boolean = False
    '    If MediaPlayer.fullScreen Then

    '    Else

    '    End If


    'If Me.PointToClient(MousePosition).Y < Me.Height - 45 Then

    'End If



    'If MediaPlayer.playState = WMPLib.WMPPlayState.wmppsPaused Then
    '    MediaPlayer.Ctlcontrols.play()
    'ElseIf MediaPlayer.playState = WMPLib.WMPPlayState.wmppsPlaying Then
    '    MediaPlayer.Ctlcontrols.pause()
    'End If
    'End Sub

    'Private Sub MediaPlayer_MediaError(sender As Object, e As _WMPOCXEvents_MediaErrorEvent) Handles MediaPlayer.MediaError
    'TODO: Create error dialog, show it
    'End Sub

#End Region
#Region "Player"

    Public Sub [Stop]()
        'Webbrowser.Hide()
        Webbrowser.Visibility = Windows.Visibility.Hidden
        Webbrowser.Source = New Uri("about:blank")
        MediaPlayer.Hide()
        _Path = ""
        _State = PlayerState.Stopped
        'Invalidate()
    End Sub

    'Private Sub MediaPlayer_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
    '    If State = PlayerState.Stopped Then
    '        e.Graphics.DrawImage(My.Resources.VideoIcon, New Rectangle(Me.Width / 2 - 25, Me.Height / 2 - 25, 50, 50))
    '    End If
    'End Sub

    Private Sub MediaPlayer_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        'MediaPlayer. = Me.Size
    End Sub

#End Region

End Class
