Imports System.Windows.Interactivity

Class MainWindow

    Sub New()
        InitializeComponent()
        Me.DataContext = Me
        AddHandler InputManager.Current.PreProcessInput, AddressOf Scroll
    End Sub

    Private Sub Player_Loaded(sender As Object, e As RoutedEventArgs) Handles Player.Loaded
        For i As Integer = 0 To 10
            PlaylistManager.Add(New Playlist("sakdfsfsdfsdfdsfs" + i.ToString, "D:\Cloud Services\Dropbox\Projects\Media Center\Media Center\Wallpapers\HD7GYC0E1DWZ4B2.png"))
        Next
        PopulateList()
    End Sub

    Public Property PlaylistManager As New PlaylistManager

    Private Sub ListBox_SourceUpdated(sender As Object, e As DataTransferEventArgs)
        Dim h As Integer = 48 * ListBox.Items.Count
        ListBox.Height = h
    End Sub

    Private Sub Scroll()
        ContentArea.Focus()
    End Sub

    Private Sub StackPanel_MouseUp(sender As Object, e As MouseButtonEventArgs)

    End Sub

    Private Sub PopulateList()
        'Populate with playlists
        ListBox.ItemsSource = PlaylistManager.Playlists
    End Sub

    Private Sub PopulateList(Playlist As Playlist)
        'Populate with videos
        ListBox.ItemsSource = Playlist.Videos
    End Sub

    Private Sub ListBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ListBox.SelectionChanged
        If Not e.AddedItems.Count = 0 Then
            If TypeOf e.AddedItems(0) Is Playlist Then
                PopulateList(e.AddedItems(0))
            ElseIf TypeOf e.AddedItems(0) Is Video Then
                PlayVideo(CType(e.AddedItems(0), Video).Location)
            End If
        End If
    End Sub

    Private Sub PlayVideo(Source As Uri)

    End Sub

End Class

' Used on sub-controls of an expander to bubble the mouse wheel scroll event up 
Public NotInheritable Class BubbleScrollEvent
    Inherits Behavior(Of UIElement)
    Protected Overrides Sub OnAttached()
        MyBase.OnAttached()
        AddHandler AssociatedObject.PreviewMouseWheel, AddressOf AssociatedObject_PreviewMouseWheel
    End Sub

    Protected Overrides Sub OnDetaching()
        RemoveHandler AssociatedObject.PreviewMouseWheel, AddressOf AssociatedObject_PreviewMouseWheel
        MyBase.OnDetaching()
    End Sub

    Private Sub AssociatedObject_PreviewMouseWheel(sender As Object, e As MouseWheelEventArgs)
        e.Handled = True
        Dim e2 = New MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
        e2.RoutedEvent = UIElement.MouseWheelEvent
        AssociatedObject.[RaiseEvent](e2)
    End Sub
End Class