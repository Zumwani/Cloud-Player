Imports System.Net
Imports System.Text
Imports System.IO
Imports Google.Apis.YouTube.v3
Imports Google.Apis
Imports System.Runtime.InteropServices

Public Class AddVideoDialog
    Inherits Zumwani.CommonLibrary.Templates.Dialog

    Public Videos As Video()

#Region "Search"

    Private WithEvents Timer As New Timer With {.Interval = 1000}

    Private Event DoSearch()

    Private _eh As DoSearchEventHandler
    Private Sub StartSearchCountdown(EventHandler As DoSearchEventHandler)
        _eh = EventHandler
        Timer.Stop()
        Timer.Start()
    End Sub

    Private Sub StopSearchCountdown()
        Timer.Stop()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        Timer.Stop()
        _eh.DynamicInvoke()
    End Sub

#End Region
#Region "Playlist"

    Private Function ItemIsAdded(Video As Video) As Boolean
        Return (GetAddedItem(Video) IsNot Nothing)
    End Function

    Private Function GetAddedItem(Video As Video) As ListItem
        For Each item As ListItem In AddedVideosList.Controls
            If CType(item.AssociatedObject, Video).Location = Video.Location Then
                Return item
            End If
        Next
        Return Nothing
    End Function

    Private Function CreateItem(Video As Video, Optional AllowDelete As Boolean = False) As ListItem

        If Me.InvokeRequired Then
            Return Me.BeginInvoke(Function() CreateItem(Video))
        End If

        Dim a As New ListItem(Video)
        With a

            .SelectionMode = ListItem.SelectMode.Check
            .Margin = New Padding(0)
            .AllowOpenLocation = True
            .AllowPlay = True
            .AllowDelete = AllowDelete
            .AllowEdit = False

            AddHandler .Click, AddressOf Item_Clicked
            AddHandler .PlayItemClicked, AddressOf Item_Play
            AddHandler .DeleteItemClicked, AddressOf Item_Delete

        End With

        If ItemIsAdded(Video) Then
            a.Select(True)
        End If

        Return a

    End Function

    Private Sub Item_Clicked(Sender As ListItem, e As EventArgs)
        If Not ItemIsAdded(Sender.AssociatedObject) Then
            AddItem(Sender.AssociatedObject)
        End If
    End Sub

    Private Sub Item_Play(Sender As ListItem, e As EventArgs)
        PlayVideo(Sender.AssociatedObject)
    End Sub

    Private Sub Item_Delete(Sender As ListItem, ByRef Handled As Boolean)
        RemoveItem(Sender.AssociatedObject)
        Handled = True
    End Sub

    Private Sub AddItem(Video As Video)
        If Not ItemIsAdded(Video) Then
            AddedVideosList.Controls.Add(CreateItem(Video, True))
        End If
        CheckAddButtonEnabled()
    End Sub

    Private Sub RemoveItem(Video As Video)
        If ItemIsAdded(Video) Then
            AddedVideosList.Controls.Remove(GetAddedItem(Video))
        End If
        CheckAddButtonEnabled()
    End Sub

    Private Sub CheckAddButtonEnabled()
        AddButton.Enabled = Not (AddedVideosList.Controls.Count = 0)
    End Sub

    Private ViewVideoDialog As New ViewVideoDialog

    Private Sub PlayVideo(Video As Video)
        Dim d As New ViewVideoDialog
        d.ShowDialog(Me, Video)
    End Sub

#End Region
#Region "Local tab"

    Private Sub DiskPreviewBox_VisibleChanged(sender As Object, e As EventArgs) Handles DiskPreviewBox.VisibleChanged
        If DiskPreviewBox.AssociatedObject IsNot Nothing Then
            DiskAddButton.Visible = DiskPreviewBox.Visible
        Else
            DiskAddButton.Visible = False
        End If
    End Sub

    Private Sub LocalPathBox_TextChanged(sender As Object, e As EventArgs) Handles LocalPathBox.TextChanged
        If Not LocalPathBox.Text = "" Then
            DiskPreviewBox.AssociatedObject = VideoFactory.FromMediaFile(New FileInfo(LocalPathBox.Text), False)
        Else
            DiskPreviewBox.AssociatedObject = Nothing
        End If
    End Sub

    Private Sub BrowseButton_Click(sender As Object, e As EventArgs) Handles BrowseButton.Click
        Dim d As New OpenFileDialog With {.AddExtension = True, .AutoUpgradeEnabled = True, .CheckFileExists = True}
        If d.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            LocalPathBox.Text = d.FileName
        End If
    End Sub

    Private Sub DiskAddButton_Click(sender As Object, e As EventArgs) Handles DiskAddButton.Click
        AddItem(DiskPreviewBox.AssociatedObject)
        LocalPathBox.Text = ""
    End Sub

#End Region
#Region "YouTube tab"

    Private YouTubeSearchEventHandler As New DoSearchEventHandler(AddressOf DoYouTubeSearch)

    Private Sub DoYouTubeSearch()

        Dim SearchString As String = YouTubeSearchBox.Text

        If Not SearchString = "" Then
            YouTubeSearchResultBox.Controls.Clear()

            Dim request As New SearchResource.ListRequest(YouTubeService, "snippet")
            request.Q = SearchString
            request.MaxResults = 20

            Dim v As New List(Of Data.SearchResult)

            Dim response = request.Execute

            For Each item In response.Items
                If item.Id.Kind = "youtube#video" Then
                    v.Add(item)
                End If
            Next

            For Each item In v
                YouTubeSearchResultBox.Controls.Add(CreateItem(VideoFactory.CreateFromYouTubeVideo(item)))
            Next

        End If
    End Sub

    Private Sub YouTubeSearchBox_TextChanged(sender As Object, e As EventArgs) Handles YouTubeSearchBox.TextChanged
        If Not YouTubeSearchBox.Text = "" Then
            StartSearchCountdown(YouTubeSearchEventHandler)
        Else
            StopSearchCountdown()
        End If
    End Sub

    Private Sub YouTubeSearchResultBox_MouseEnter(sender As Object, e As EventArgs) Handles YouTubeSearchResultBox.MouseEnter
        YouTubeSearchResultBox.Select()
    End Sub

    Private Sub YouTubeVideosBox_CheckedChanged(sender As Object, e As EventArgs)
        StartSearchCountdown(YouTubeSearchEventHandler)
    End Sub

#End Region
#Region "Nico Nico tab"

    Private NicoNicoSearchEventHandler As New DoSearchEventHandler(AddressOf DoNicoNicoSearch)

    Private Sub DoNicoNicoSearch()

        Dim SearchString As String = NicoNicoSearchBox.Text





    End Sub

    Private Sub NicoNicoSearchBox_TextChanged(sender As Object, e As EventArgs) Handles NicoNicoSearchBox.TextChanged
        If Not NicoNicoSearchBox.Text = "" Then
            StartSearchCountdown(NicoNicoSearchEventHandler)
        Else
            StopSearchCountdown()
        End If
    End Sub

#End Region
#Region "SoundCloud tab"

    'TODO: SoundCloud search not working properly

    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        Dim l As New List(Of Video)
        For Each item As ListItem In AddedVideosList.Controls
            l.Add(item.AssociatedObject)
        Next
        Videos = l.ToArray
    End Sub

    Private SoundCloudEventHandler As New DoSearchEventHandler(AddressOf DoSoundCloudSearch)

    Private Sub DoSoundCloudSearch()

        Dim SearchString As String = SoundCloudSearchBox.Text

        If Not SearchString = "" Then

            If Not SoundCloudClient.IsAuthenticated Then
                SoundCloudClient.Authenticate()
            End If

            SoundCloudResultsBox.Controls.Clear()

            Dim result As List(Of SoundCloud.NET.Track) = SoundCloud.NET.Track.Search(SearchString, {"#SAO2"}, SoundCloud.NET.Filter.Public, "", "", Nothing, Nothing, Nothing, Nothing, DateTime.MinValue, DateTime.Now, Nothing, Nothing, Nothing, , 20)

            For Each item In result
                SoundCloudResultsBox.Controls.Add(CreateItem(VideoFactory.CreateFromSoundCloudTrack(item)))
            Next

        End If

    End Sub

    Private Sub SoundCloudSearchBox_TextChanged(sender As Object, e As EventArgs) Handles SoundCloudSearchBox.TextChanged
        If Not SoundCloudSearchBox.Text = "" Then
            StartSearchCountdown(SoundCloudEventHandler)
        Else
            StopSearchCountdown()
        End If
    End Sub

#End Region
   
End Class