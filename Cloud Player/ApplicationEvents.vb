Imports System.Threading
Imports System.Globalization

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
            Try
                Thread.CurrentThread.CurrentUICulture = My.Settings.Language
            Catch ex As CultureNotFoundException
                Zumwani.CloudPlayer.Log.Write("Application", "Could not set language: " + ex.Message)
            End Try
        End Sub

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            'Make sure that awesomuim process is closed
            Awesomium.Core.WebCore.Shutdown()
        End Sub

    End Class

End Namespace

