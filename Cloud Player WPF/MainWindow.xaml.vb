Imports System.Windows.Interactivity

Class MainWindow

#Region "Window"

    Sub New()
        Me.DataContext = Me
        InitializeComponent()

        AddHandler InputManager.Current.PreProcessInput, Sub() ContentArea.Focus()
        AddHandler PlaylistManager.PlayVideo, AddressOf PlaylistManager_PlayVideo

    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles MainWindow.Loaded

        'Set saved postion
        If My.Settings.WindowPosition IsNot Nothing AndAlso My.Settings.RestorePositionAtStart Then
            My.Settings.WindowPosition.RestoreWindow(Me)
        Else
            WindowPositionInfo.ResetWindow(Me)
        End If

        PopulateView()

    End Sub

    Private Sub MainWindow_Unloaded(sender As Object, e As RoutedEventArgs) Handles MainWindow.Unloaded

        'Save position
        If My.Settings.SavePositionAtClose Then
            My.Settings.WindowPosition = WindowPositionInfo.FromWindow(Me)
        End If

        My.Application.Shutdown()

    End Sub

#End Region
#Region "Playlists and videos"

    Public Shared Property PlaylistManager As PlaylistManager

    Private Sub PopulateView()
        'Populate view with playlists
        PlaylistView.ItemsSource = PlaylistManager.Playlists
    End Sub

    Private Sub PopulateView(Playlist As Playlist)
        'Populate view with videos
        PlaylistView.ItemsSource = Playlist.Videos
    End Sub

    Private _justSwitchedView As Boolean = False
    Private Sub ViewBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles PlaylistView.SelectionChanged

        If Not e.AddedItems.Count = 0 Then
            If TypeOf e.AddedItems(0) Is Playlist Then

                PopulateView(e.AddedItems(0))
                _justSwitchedView = True

            ElseIf TypeOf e.AddedItems(0) Is Video Then

                If Not _justSwitchedView Then
                    PlayVideo(e.AddedItems(0))
                Else
                    PlaylistView.SelectedIndex = -1
                    _justSwitchedView = False

                End If

            End If
        End If

    End Sub

    Private Sub PlayVideo(Video As Video)
        PlaylistManager.Play(Video)
    End Sub

    Private Sub PlaylistManager_PlayVideo(Video As Video)
        If Video IsNot Nothing AndAlso Video.Source IsNot Nothing Then
            Player.Play(Video.Source)
        Else
            Player.Stop()
        End If
    End Sub

#End Region
#Region "Playlist options panel"



#End Region

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        My.Application.SettingsWindow.Show()
    End Sub
End Class