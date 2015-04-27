Imports System.IO
Imports System.Windows.Threading

Public Class MediaPlayer
    'TODO: Use stable version of awesomium
    Public Event MediaFailed(sender As Object, e As Exception)
    Public Event MediaEnded(sender As Object, e As EventArgs)

    Public Enum MediaType
        None = 0
        Local = 1
        Online = 2
    End Enum

    Private _CurrentMediaType As MediaType
    Public ReadOnly Property CurrentMediaType As MediaType
        Get
            Return _CurrentMediaType
        End Get
    End Property

    Private _CurrentSource As Uri
    Public ReadOnly Property CurrentSource As Uri
        Get
            Return _CurrentSource
        End Get
    End Property

    Public Sub Play(Source As Uri)
        Me.Stop()
        If Source.IsFile Then
            PlayLocal(Source)
        Else
            PlayOnline(Source)
        End If
    End Sub

    Private Sub PlayLocal(Source As Uri)

        If File.Exists(Source.LocalPath) Then

            LocalPlayer.Source = Source
            LocalPlayer.Play()

            LocalView.IsSelected = True

        Else
            Fail(New FileNotFoundException())
        End If

    End Sub

    Private Sub PlayOnline(Source As Uri)
        OnlinePlayer.Source = Source
        OnlineView.IsSelected = True
    End Sub

    Public Sub Pause()
        If CanPause Then
            LocalPlayer.Pause()
        End If
    End Sub

    Public Sub [Resume]()
        If LocalView.IsSelected Then
            LocalPlayer.Play()
        End If
    End Sub

    Public Sub [Stop]()

        LocalPlayer.Stop()
        LocalPlayer.Close()
        LocalPlayer.Source = Nothing

        'OnlinePlayer.

        OnlinePlayer.Source = New Uri("about:blank")

        _CurrentSource = Nothing
        EmptyView.IsSelected = True

    End Sub

    Public ReadOnly Property CanPause As Boolean
        Get
            Return (CurrentMediaType = MediaType.Local And LocalPlayer.CanPause)
        End Get
    End Property

    Private Sub Fail(e As Exception)

        MediaFailedMessage.Text = e.Message
        MediaFailedView.IsSelected = True

        RaiseEvent MediaFailed(Me, e)

    End Sub

    Private Sub EndMedia()
        RaiseEvent MediaEnded(Me, EventArgs.Empty)
    End Sub

    Private Sub LocalPlayer_MediaFailed(sender As Object, e As ExceptionRoutedEventArgs) Handles LocalPlayer.MediaFailed
        Fail(New ArgumentException(Locale.Locale.MainWindow_LocalMediaFailed))
    End Sub

    Private Sub LocalPlayer_MediaEnded(sender As Object, e As RoutedEventArgs) Handles LocalPlayer.MediaEnded
        EndMedia()
    End Sub

    'Private Sub OnlinePlayer_LoadingFrameFailed(sender As Object, e As Awesomium.Core.LoadingFrameFailedEventArgs) Handles OnlinePlayer.LoadingFrameFailed
    '    Fail(New ArgumentException(Locale.Locale.MainWindow_OnlineMediaFailed))
    'End Sub

End Class
