Imports System.Threading
Imports System.Globalization
Imports System.IO

Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup

            'Set language
            SetLanguage(My.Settings.Language, False)

            'Load playlists
            MainWindow.PlaylistManager = LoadPlaylists()

        End Sub

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            'Close the awesomium process
            Awesomium.Core.WebCore.Shutdown()
        End Sub

        Public Sub SetLanguage(Language As CultureInfo, Optional DoRestart As Boolean = False)

            Try

                Thread.CurrentThread.CurrentUICulture = Language

                If DoRestart Then
                    System.Windows.Forms.Application.Restart()
                End If

            Catch ex As CultureNotFoundException
                Zumwani.CloudPlayer.Log.Write("Application", "Could not set language: " + ex.Message)
            End Try

        End Sub

        Private Function LoadPlaylists() As PlaylistManager

            Dim splash As SplashScreen = CType(My.Application.SplashScreen, SplashScreen)

            splash.SetProgress(0)

            PausePlaylistLoading()

            Dim pm As New PlaylistManager
            Dim files As FileInfo() = PlaylistStore.GetFiles
            Dim i As Integer = 1

            For Each file In files

                If file.Extension = ".pl" Then

                    Try

                        pm.Add(PlaylistGenerator.Load(file, True, False))

                    Catch ex As PlaylistGenerator.ParseException
                        If TypeOf ex.InnerException Is NotImplementedException Then

                            'Playlist needs upgrading
                            splash.ShowUpgrade(ex.File, ex.GeneratorVersion, ex.PlaylistVersion)

                            'Wait until user has made a decision
                            PausePlaylistLoading()

                        ElseIf TypeOf ex.InnerException Is Xml.XmlException Then

                            'An error occured
                            splash.ShowError(ex.File, ex.GeneratorVersion, ex.InnerException.Message)

                            'Wait until user has made a decision
                            PausePlaylistLoading()

                        ElseIf TypeOf ex.InnerException Is FileNotFoundException Then

                            'The file could not be found
                            splash.ShowError(ex.File, ex.GeneratorVersion, ex.Message)

                            'Wait until user has made a decision
                            PausePlaylistLoading()

                        ElseIf TypeOf ex.InnerException Is ArgumentException Then

                            'The file did not have the correct fileextionsion
                            splash.ShowError(ex.File, ex.GeneratorVersion, ex.Message)

                            'Wait until user has made a decision
                            PausePlaylistLoading()

                        End If
                    End Try

                End If

                splash.SetProgress(((i / files.Count) * 100))
                i += 1

            Next

            'Done = pm
            splash.SetProgress(100)

            Return pm

        End Function

        Private Sub PausePlaylistLoading()
            Dim splash As SplashScreen = CType(My.Application.SplashScreen, SplashScreen)
            Thread.Sleep(100) 'Sleep to give splash thread a chance to set CanContinue
            'Sleep until user has made a decision
            Do Until splash.CanContinue
                Application.DoEvents()
            Loop
        End Sub

    End Class

End Namespace

