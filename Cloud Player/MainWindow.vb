Imports System.Drawing.Drawing2D
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices
Imports System.Net

Public Class MainWindow
    Inherits Zumwani.CommonLibrary.Templates.Window

    Private Sub ScrollHelper_EventHandler()
        ContentPanel.Select()
        RefreshUI()
    End Sub

#Region "Window, UI"

    Private Sub MainWindow_ControlAdded(sender As Control, e As ControlEventArgs) Handles Me.ControlAdded
        AddHandler sender.MouseWheel, AddressOf ScrollHelper_EventHandler
    End Sub

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MsgBox(SoundCloudClient.Authenticate().AccessToken)

        'Dim a As New SoundCloud.NET.SoundCloudClient(New SoundCloud.NET.SoundCloudCredentials("454972d9aec9bedff9a95d59a9076411", "1b5f909fbb3a378fbcc5f6ceb7672a86"))

        'Dim b = SoundCloud.NET.Track.Search("Raku Mugetsu", Nothing, SoundCloud.NET.Filter.Public, "", "", Nothing, Nothing, Nothing, Nothing, DateTime.MinValue, DateTime.Now, Nothing, Nothing, Nothing)

        'For Each t In b
        '    MsgBox(t.Title)
        'Next


        If My.Settings.WindowPosition Is Nothing Then
            My.Settings.WindowPosition = New WindowPositionInfo
        End If

        If My.Settings.RestorePositionAtStartup Then
            RestoreWindowPosition()
        End If

        PopulateList()

    End Sub

    Private Sub MainWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If My.Settings.SavePositionAtClose Then
            SaveWindowPositionInfo()
        End If

    End Sub

    Public Sub RestoreWindowPosition()

        With My.Settings.WindowPosition

            If .DockedSide = ScreenSide.None Or .DockScreen = -1 Or .Maximized Then

                Me.DesktopBounds = .DisplayRectangle
                If .Maximized Then
                    Me.WindowState = FormWindowState.Maximized
                End If

            Else

                Me.DesktopBounds = .DisplayRectangle
                DockToScreen(.DockedSide, Screen.AllScreens(.DockScreen))

            End If

        End With

    End Sub

    Public Sub SaveWindowPositionInfo()

        With My.Settings.WindowPosition

            If DockSide = ScreenSide.None Then

                If WindowState = FormWindowState.Maximized Then
                    .DisplayRectangle = Me.RestoreBounds
                    .Maximized = True
                Else
                    .DisplayRectangle = Me.DesktopBounds
                    .Maximized = False
                End If

                .DockedSide = ScreenSide.None
                .DockScreen = -1

            Else

                .DisplayRectangle = Me.RectBeforeDocked
                .Maximized = False

                .DockedSide = DockSide
                .DockScreen = DockScreen.Index

            End If

        End With

    End Sub

    Private Sub ContentPanel_Paint(sender As Object, e As PaintEventArgs) Handles ContentPanel.Paint

        'Draw left side shadow
        Dim rect As New Rectangle(InnerContentPanel.Left - 20, 0, 20, Me.Height)
        If rect.Width > 0 And rect.Height > 0 Then
            Using Brush As New LinearGradientBrush(rect, Color.Transparent, Color.Black, LinearGradientMode.Horizontal)
                e.Graphics.FillRectangle(Brush, rect)
            End Using
        End If

        'Draw right hand shadow
        rect = New Rectangle(InnerContentPanel.Right, 0, 20, Me.Height)
        If rect.Width > 0 And rect.Height > 0 Then
            Using Brush As New LinearGradientBrush(rect, Color.Black, Color.Transparent, LinearGradientMode.Horizontal)
                e.Graphics.FillRectangle(Brush, rect)
            End Using
        End If

    End Sub

    Private Sub VideoGradientPanel_Paint(sender As Object, e As PaintEventArgs) Handles VideoGradientPanel.Paint
        If e.ClipRectangle.Width > 0 And e.ClipRectangle.Height > 0 Then
            Using Brush As New LinearGradientBrush(e.ClipRectangle, Color.FromArgb(27, 27, 27), Color.FromArgb(40, 40, 40), LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(Brush, e.ClipRectangle)
            End Using
        End If
    End Sub

    Private Sub RefreshUI() Handles MyBase.SizeChanged, MyBase.ResizeEnd

        If Not WindowState = FormWindowState.Minimized And Visible Then

            'Define size of contentpanel
            Dim rect As New Rectangle(0, 0, Me.Width - 10, Me.Height - PlaylistOptionsPanel.Height - 30)

            'Make sure rect.width does not exceed more than 0.7 of screen width
            If rect.Width > Screen.FromControl(Me).Bounds.Width * 0.7 Then
                rect.Width = Screen.FromControl(Me).Bounds.Width * 0.7
                rect.X = (Me.Width / 2) - (rect.Width / 2)
            Else
                rect.X = 0
            End If

            If ContentPanel.VerticalScroll.Visible Then
                'Subtract width of scrollbar
                rect.Width -= 23
                Me.MinimumSize = New Size(400, rect.Height)
            Else
                'Width exceeds form width, this appears to fix it TODO: Check if fixable
                rect.Width -= 6
                Me.MinimumSize = New Size(415, rect.Height)
            End If

            InnerContentPanel.Left = rect.Left
            InnerContentPanel.Width = rect.Width
            MediaPlayer1.Height = MediaPlayer1.Width / 1.64 'Make sure aspect ratio is 16:9

            If PlaylistTitleLabel.Visible Then
                PlaylistTitleLabel.Top = MediaPlayer1.Bottom + 10
                List.Top = PlaylistTitleLabel.Bottom
            Else
                List.Top = MediaPlayer1.Bottom + 10
            End If

            InnerContentPanel.Height = InnerContentPanel.PreferredSize.Height + PlaylistOptionsPanel.Height

            'Check if rect reaches bottom
            If InnerContentPanel.Bottom < Me.Height - PlaylistOptionsPanel.Height Then
                InnerContentPanel.Height = Me.Height - PlaylistOptionsPanel.Height - 10
            End If

            PlaylistOptionsPanel.Left = rect.Left
            If ContentPanel.VerticalScroll.Visible Then
                PlaylistOptionsPanel.Width = rect.Width - 17
            Else
                PlaylistOptionsPanel.Width = rect.Width
                'TODO: Set proper width of playlist options panel
            End If


            ContentPanel.Invalidate()
            MediaPlayer1.Invalidate()

            Using G As Graphics = Graphics.FromHwnd(0)

                G.CompositingQuality = CompositingQuality.HighSpeed

                rect = ContentPanel.RectangleToScreen(PlaylistOptionsPanel.Bounds)
                rect = New Rectangle(rect.Left, rect.Top - 10, rect.Width, 10)
                Using Brush As New LinearGradientBrush(rect, Color.Transparent, PlaylistOptionsPanel.BackColor, LinearGradientMode.Vertical)
                    G.FillRectangle(Brush, rect)
                End Using
            End Using





        End If

    End Sub

#End Region
#Region "UI functionality"

    Private Sub PlaylistsButton_Click(sender As Object, e As EventArgs) Handles PlaylistsButton.Click
        If OpenPlaylist IsNot Nothing Then
            PopulateList()
        End If
    End Sub

    Private Sub CurrentlyPlayingButton_Click(sender As Object, e As EventArgs) Handles CurrentlyPlayingButton.Click
        If OpenPlaylist IsNot PlaylistManager.CurrentlyPlayingPlaylist Then
            If PlaylistManager.CurrentlyPlayingPlaylist Is PlaylistManager.TempPlaylist Then
                If Not PlaylistManager.TempPlaylist.Videos.Count = 0 Then
                    PopulateList(PlaylistManager.TempPlaylist)
                End If
            Else
                PopulateList(PlaylistManager.CurrentlyPlayingPlaylist)
            End If
        End If
    End Sub

    Private Sub SettingsButton_Click(sender As Object, e As EventArgs) Handles SettingsButton.Click
        SettingsDialog.ShowDialog(Me)
    End Sub

    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click

        If OpenPlaylist Is Nothing Then
            'Add playlist

            Dim d As New AddPlaylistDialog

            If d.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                PlaylistManager.Add(d.Playlist)
                d.Playlist.Save()
                PopulateList()
            End If

        Else
            'Add video

            If OpenPlaylist IsNot PlaylistManager.TempPlaylist Then

                Dim d As New AddVideoDialog

                If d.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    OpenPlaylist.AddRange(d.Videos)
                    OpenPlaylist.Save()
                End If

            End If

        End If

    End Sub
    'TODO: Add support for multiple monitors (appbar)
    Private Sub MainWindow_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.Alt Then
            If e.KeyCode = Keys.Left Then
                If _Side = ScreenSide.None Then
                    DockToScreen(ScreenSide.Left, Screen.FromControl(Me))
                ElseIf _Side = ScreenSide.Left Then
                    Dim s As Screen = Screen.FromControl(Me).GetScreenToLeft
                    If s IsNot Nothing Then
                        DockToScreen(ScreenSide.Right, s)
                    End If
                ElseIf _Side = ScreenSide.Right Then
                    UndockFromScreen()
                End If
                RefreshUI()
            ElseIf e.KeyCode = Keys.Right Then
                If _Side = ScreenSide.None Then
                    DockToScreen(ScreenSide.Right, Screen.FromControl(Me))
                ElseIf _Side = ScreenSide.Left Then
                    UndockFromScreen()
                ElseIf _Side = ScreenSide.Right Then
                    Dim s As Screen = Screen.FromControl(Me).GetScreenToRight
                    If s IsNot Nothing Then
                        DockToScreen(ScreenSide.Left, s)
                    End If
                End If
                RefreshUI()
            End If
        End If
    End Sub

#End Region
#Region "Playlists and video"

    Public WithEvents PlaylistManager As PlaylistManager

    Private OpenPlaylist As Playlist

    Private Sub PlaylistManager_CollectionChanged() Handles PlaylistManager.CollectionChanged
        If OpenPlaylist Is Nothing Then
            RefreshList()
        End If
    End Sub

    Private Sub PlaylistManager_PlaylistChanged(Playlist As Playlist) Handles PlaylistManager.PlaylistChanged
        If OpenPlaylist Is Playlist Then
            RefreshList()
        End If
    End Sub

    Private Sub PlaylistManager_VideoPlay(Video As Video, Playlist As Playlist) Handles PlaylistManager.VideoPlay
        MediaPlayer1.PlayVideo(Video.Location)
        Me.Text = Video.Title + " - Cloud Player"
        RefreshItemSelectionStates(FindItem(Video))
        RefreshItemSelectionStates(FindItem(Playlist))
    End Sub

    Private Sub PlaylistManager_VideoStop() Handles PlaylistManager.VideoStop
        MediaPlayer1.Stop()
        Me.Text = "Cloud Player"
        RefreshItemSelectionStates()
    End Sub

    Public Sub RefreshList()

        If OpenPlaylist Is Nothing Then
            'Playlists view

            'Check for removed playlists
            For Each item As ListItem In List.Controls
                If Not PlaylistManager.Contains(item.AssociatedObject) Then
                    List.Controls.Remove(item)
                End If
            Next

            'Check for new playlists
            For Each p In PlaylistManager.Playlists
                Dim exists As Boolean = False
                For Each item As ListItem In List.Controls
                    If item.AssociatedObject Is p Then
                        exists = True
                    End If
                Next
                If Not exists Then
                    Dim a As ListItem = CreateItem(p)
                    List.Controls.Add(a)
                    List.Controls.SetChildIndex(a, PlaylistManager.IndexOf(p))
                End If
            Next

        Else
            'Videos view

            'Check for removed videos
            For Each item As ListItem In List.Controls
                If Not OpenPlaylist.Contains(item.AssociatedObject) Then
                    List.Controls.Remove(item)
                End If
            Next

            'Check for new videos
            For Each v In OpenPlaylist.Videos
                Dim exists As Boolean = False
                For Each item As ListItem In List.Controls
                    If item.AssociatedObject Is v Then
                        exists = True
                    End If
                Next
                If Not exists Then
                    Dim a As ListItem = CreateItem(v)
                    List.Controls.Add(a)
                    List.Controls.SetChildIndex(a, OpenPlaylist.IndexOf(v))
                End If
            Next

        End If

    End Sub

    Public Sub PopulateList()

        List.SuspendLayout()

        List.Controls.Clear()
        For Each p In PlaylistManager.Playlists
            List.Controls.Add(CreateItem(p))
        Next

        OpenPlaylist = Nothing
        RefreshUI()

        List.ResumeLayout()

        ToolTip1.SetToolTip(AddButton, Locale.MainWindow_AddPlaylist)

    End Sub

    Public Sub PopulateList(Playlist As Playlist)

        If Playlist IsNot Nothing Then

            List.SuspendLayout()

            List.Controls.Clear()
            For Each p In Playlist.Videos
                List.Controls.Add(CreateItem(p))
            Next

            OpenPlaylist = Playlist
            RefreshUI()

            List.ResumeLayout()

            ToolTip1.SetToolTip(AddButton, Locale.MainWindow_AddVideo)

        End If

    End Sub

    Private Function CreateItem(Obj As Object) As ListItem
        Dim a As ListItem

        If TypeOf Obj Is Video Then
            a = New ListItem(CType(Obj, Video))
            If PlaylistManager.CurrentlyPlaying Is Obj Then
                a.Select(True)
            End If
        ElseIf TypeOf Obj Is Playlist Then
            a = New ListItem(CType(Obj, Playlist))
            If PlaylistManager.CurrentlyPlayingPlaylist Is Obj Then
                a.Select(True)
            End If
        Else
            Throw New ArgumentException
        End If

        With a
            .AllowPlay = True
            .AllowEdit = True
            .AllowOpenLocation = True
            .AllowDelete = True
            .SelectionMode = ListItem.SelectMode.ChangeBackcolor
            .ShowPlayAsStopIfPlayingAtMainWindow = True
            .Margin = New Padding(0)
        End With

        AddHandler a.Click, AddressOf Item_Play
        AddHandler a.PlayItemClicked, AddressOf Item_Play
        AddHandler a.OpenLocationItemClicked, AddressOf Item_Open

        Return a
    End Function

    Private Sub Item_Play(Sender As ListItem, e As EventArgs)
        If TypeOf Sender.AssociatedObject Is Video Then
            If Not PlaylistManager.CurrentlyPlaying Is Sender.AssociatedObject Then
                'Play video
                PlaylistManager.PlayVideo(Sender.AssociatedObject)
            Else
                'Stop video
                PlaylistManager.StopVideo()

            End If
        ElseIf TypeOf Sender.AssociatedObject Is Playlist Then
            If OpenPlaylist IsNot Sender.AssociatedObject Then
                'Open playlist
                PopulateList(Sender.AssociatedObject)
            End If
        End If
    End Sub

    Private Sub Item_Open(Sender As ListItem, ByRef Handled As Boolean)
        If TypeOf Sender.AssociatedObject Is Video Then
            Dim v As Video = Sender.AssociatedObject

            Select Case v.Service
                Case Is = "Local"
                    Handled = True
                    Process.Start(v.Location)
                Case Is = "YouTube"
                    Handled = True
                    Dim id As String = v.Location.Split("/").Last.Split("?").First
                    Process.Start("www.youtube.com/watch?v=" + id)
                Case Is = "NicoNico"

                Case Is = "SoundCloud"

            End Select

        End If
    End Sub

    Private Sub RefreshItemSelectionStates(Optional SelectedItem As ListItem = Nothing)
        For Each item As ListItem In List.Controls
            If item IsNot SelectedItem Then
                item.Deselect(True)
            End If
        Next
    End Sub

    Private Function FindItem(Obj As Object) As ListItem
        For Each item As ListItem In List.Controls
            If item.AssociatedObject Is Obj Then
                Return item
            End If
        Next
        Return Nothing
    End Function

#End Region
#Region "AppBar"

    Private Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    Private Structure APPBARDATA
        Public cbSize As Integer
        Public hWnd As IntPtr
        Public uCallbackMessage As Integer
        Public uEdge As Integer
        Public rc As RECT
        Public lParam As IntPtr
    End Structure

    Private Enum ABMsg As Integer
        ABM_NEW = 0
        ABM_REMOVE = 1
        ABM_QUERYPOS = 2
        ABM_SETPOS = 3
        ABM_GETSTATE = 4
        ABM_GETTASKBARPOS = 5
        ABM_ACTIVATE = 6
        ABM_GETAUTOHIDEBAR = 7
        ABM_SETAUTOHIDEBAR = 8
        ABM_WINDOWPOSCHANGED = 9
        ABM_SETSTATE = 10
    End Enum

    Private Enum ABNotify As Integer
        ABN_STATECHANGE = 0
        ABN_POSCHANGED
        ABN_FULLSCREENAPP
        ABN_WINDOWARRANGE
    End Enum

    Private Enum ABEdge As Integer
        ABE_LEFT = 0
        ABE_TOP
        ABE_RIGHT
        ABE_BOTTOM
    End Enum

    Private AppbarWorking As Boolean = False

    Private fBarRegistered As Boolean = False

    Private Declare Function SHAppBarMessage Lib "shell32.dll" Alias "SHAppBarMessage" _
    (ByVal dwMessage As Integer, <MarshalAs(UnmanagedType.Struct)> ByRef pData As  _
    APPBARDATA) As Integer

    Private Declare Function MoveWindow Lib "user32" Alias "MoveWindow" (ByVal hwnd As Integer, _
    ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, _
    ByVal bRepaint As Integer) As Integer

    Private Declare Function RegisterWindowMessage Lib "user32" Alias "RegisterWindowMessageA" _
    (ByVal lpString As String) As Integer

    Private uCallBack As Integer

    Private DockSide As ScreenSide
    Private DockScreen As Screen = Nothing
    Private RectBeforeDocked As Rectangle

    Private Sub RegisterBar(Side As ScreenSide, Screen As Screen)

        AppbarWorking = True

        RectBeforeDocked = Me.DesktopBounds

        Dim abd As New APPBARDATA
        abd.cbSize = Marshal.SizeOf(abd)
        abd.hWnd = Me.Handle

        uCallBack = RegisterWindowMessage("AppBarMessage")
        abd.uCallbackMessage = uCallBack

        Dim ret As Integer = SHAppBarMessage(CType(ABMsg.ABM_NEW, Integer), abd)
        fBarRegistered = True

        ABSetPos(Side, Screen)

        DockSide = Side
        DockScreen = Screen

        AppbarWorking = False

    End Sub

    Private Sub UnregisterBar()
        AppbarWorking = True

        If fBarRegistered Then
            Dim abd As New APPBARDATA
            abd.cbSize = Marshal.SizeOf(abd)
            abd.hWnd = Me.Handle

            SHAppBarMessage(CType(ABMsg.ABM_REMOVE, Integer), abd)
            fBarRegistered = False
        End If

        DockSide = ScreenSide.None
        DockScreen = Nothing

        AppbarWorking = False
    End Sub

    Private Sub ABSetPos(Side As ScreenSide, Screen As Screen)
        Dim abd As New APPBARDATA()
        abd.cbSize = Marshal.SizeOf(abd)
        abd.hWnd = Me.Handle

        If Side = ScreenSide.Left Then
            abd.uEdge = CInt(ABEdge.ABE_LEFT)
        ElseIf Side = ScreenSide.Right Then
            abd.uEdge = CInt(ABEdge.ABE_RIGHT)
        End If

        If abd.uEdge = CInt(ABEdge.ABE_LEFT) OrElse abd.uEdge = CInt(ABEdge.ABE_RIGHT) Then
            abd.rc.top = Screen.WorkingArea.Top
            abd.rc.bottom = Screen.WorkingArea.Height
            If abd.uEdge = CInt(ABEdge.ABE_LEFT) Then
                abd.rc.left = Screen.WorkingArea.Left
                abd.rc.right = Me.Width
            Else
                abd.rc.right = Screen.WorkingArea.Width
                abd.rc.left = abd.rc.right - Me.Width

            End If
        Else
            abd.rc.left = Screen.WorkingArea.Left
            abd.rc.right = Screen.WorkingArea.Width
            If abd.uEdge = CInt(ABEdge.ABE_TOP) Then
                abd.rc.top = Screen.WorkingArea.Top
                abd.rc.bottom = Me.Height
            Else
                abd.rc.bottom = Screen.WorkingArea.Height
                abd.rc.top = abd.rc.bottom - Me.Height
            End If
        End If

        ' Query the system for an approved size and position. 
        SHAppBarMessage(CInt(ABMsg.ABM_QUERYPOS), abd)

        ' Adjust the rectangle, depending on the edge to which the 
        ' appbar is anchored. 
        Select Case abd.uEdge
            Case CInt(ABEdge.ABE_LEFT)
                abd.rc.right = abd.rc.left + 420
            Case CInt(ABEdge.ABE_RIGHT)
                abd.rc.left = abd.rc.right - 420
            Case CInt(ABEdge.ABE_TOP)
                abd.rc.bottom = abd.rc.top + 420
            Case CInt(ABEdge.ABE_BOTTOM)
                abd.rc.top = abd.rc.bottom - 420
        End Select

        ' Pass the final bounding rectangle to the system. 
        SHAppBarMessage(CInt(ABMsg.ABM_SETPOS), abd)

        ' Move and size the appbar so that it conforms to the 
        ' bounding rectangle passed to the system. 
        MoveWindow(abd.hWnd, abd.rc.left, abd.rc.top, abd.rc.right - abd.rc.left, abd.rc.bottom - abd.rc.top, True)
    End Sub

    Private Declare Function SHChangeNotify Lib "Shell32.dll" (ByVal eventId As Integer, ByVal flags As Integer, ByVal item1 As IntPtr, ByVal item2 As IntPtr) As Integer

    Public Shared Sub RefreshDesktop()
        SHChangeNotify(134217728, 4096, IntPtr.Zero, IntPtr.Zero)
    End Sub

    Public Enum ScreenSide
        None = 0
        Left = 1
        Right = 2
    End Enum

    Private _Side As ScreenSide
    Private _PrevRect As Rectangle

    Private Sub DockToScreen(Side As ScreenSide, Screen As Screen)
        If fBarRegistered Then
            UnregisterBar()
        End If
        _Side = Side
        _PrevRect = Me.Bounds
        RegisterBar(Side, Screen)
    End Sub

    Private Sub UndockFromScreen()
        If fBarRegistered And Not AppbarWorking Then

            UnregisterBar()
            RefreshDesktop()

            Dim w As Rectangle = Screen.FromControl(Me).WorkingArea
            Dim rect As New Rectangle(w.Left + (w.Width / 2) - (_PrevRect.Width / 2), w.Top + (w.Height / 2) - (_PrevRect.Height / 2), _PrevRect.Width, _PrevRect.Height)

            Me.Bounds = rect

            _Side = ScreenSide.None

        End If
    End Sub

    Private Sub MainWindow_Move() Handles MyBase.Move, MyBase.SizeChanged
        'If fBarRegistered And Not AppbarWorking Then
        '    UndockFromScreen()
        'End If
    End Sub

#End Region

End Class