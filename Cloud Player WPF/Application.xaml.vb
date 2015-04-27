Imports System.IO
Imports System.Globalization
Imports System.Threading
Imports System.Reflection

Class Application

    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.

#Region "Application level windows"

    Private _SettingsWindow As SettingsWindow
    Public ReadOnly Property SettingsWindow As SettingsWindow
        Get
            If _SettingsWindow Is Nothing OrElse Not _SettingsWindow.IsLoaded Then
                _SettingsWindow = New SettingsWindow
            End If
            Return _SettingsWindow
        End Get
    End Property

    Private _MainWindow As MainWindow
    Public Shadows ReadOnly Property MainWindow As MainWindow
        Get
            If _MainWindow Is Nothing OrElse Not _MainWindow.IsLoaded Then
                _MainWindow = New MainWindow
            End If
            Return _MainWindow
        End Get
    End Property

#End Region

    Private Sub Application_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup

        'Make sure settings carry over after updating
        If My.Settings.UpgradeRequired Then
            My.Settings.Upgrade()
            My.Settings.Reload()
            My.Settings.UpgradeRequired = False
        End If

        'Set language and load custom style (if exists)
        _setLocale(My.Settings.Language)
        LoadCustomStyle()

        'Initialize awesomium webcore so that it doesn´t perform lazy initialization (hangs UI)
        Dim config As New Awesomium.Core.WebConfig() With {.ReduceMemoryUsageOnNavigation = True}
        Awesomium.Core.WebCore.Initialize(config)

        'Load playlists
        Dim pm As PlaylistManager = LoadPlaylists()
        MainWindow.PlaylistManager = pm

        'Initialization done, show mainwindow
        MainWindow.Show()

    End Sub

    Private Sub Application_Exit(sender As Object, e As ExitEventArgs) Handles Me.Exit
        My.Settings.Save()
    End Sub

    Public Sub Restart()
        Process.Start(Application.ResourceAssembly.Location)
        Me.Shutdown()
    End Sub

    Private Sub LoadCustomStyle()
        'Check if Style.xaml exists in install directory
        If New FileInfo("Style.xaml").Exists Then
            Dim rd As New ResourceDictionary
            rd.Source = New Uri(New FileInfo("Style.xaml").FullName)
            Me.Resources.MergedDictionaries.Add(rd)
        End If
    End Sub

    Private Sub _setLocale(Locale As CultureInfo)
        'Set the locale for the current thread and as default thread locale, for multi-threading.
        System.Threading.Thread.CurrentThread.CurrentUICulture = Locale
        CultureInfo.DefaultThreadCurrentUICulture = Locale
    End Sub

    Private Function LoadPlaylists() As PlaylistManager

        Dim playlistmanager As New PlaylistManager

        'Get all xml files from PlaylistStore
        Dim files = Array.ConvertAll(Directory.GetFiles(PlaylistStore.FullName), Function(str As String) New Uri(str))

        'Load playlists with PlaylistLoader dialog
        Dim d As New PlaylistLoader
        playlistmanager.AddRange(d.ShowDialog(files))

        Return playlistmanager

    End Function

End Class
