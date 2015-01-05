Imports System.Drawing.Drawing2D

Public Class ListItem

#Region "Constructors"

    Sub New()
        InitializeComponent()
    End Sub

    Sub New(Playlist As Playlist)
        InitializeComponent()
        Me.AssociatedObject = Playlist
        Refresh()
    End Sub

    Sub New(Video As Video)
        InitializeComponent()
        Me.AssociatedObject = Video
        Refresh()
    End Sub

#End Region
#Region "Properties"

    Private ColorNormal As Color = Color.Transparent
    Private ColorHover As Color = Color.FromArgb(150, 150, 150)
    Private ColorSelected As Color = Color.FromArgb(100, 100, 100)

    Public Event OnSelected(Sender As ListItem)
    Public Event OnDeselected(Sender As ListItem)

    Public Shadows Event Click(Sender As ListItem, e As EventArgs)

    Public Enum SelectMode
        None = 0
        ChangeBackcolor = 1
        Check = 2
    End Enum

    Private _AssociatedObject As Object
    Public Property AssociatedObject As Object
        Get
            Return _AssociatedObject
        End Get
        Set(value As Object)
            _AssociatedObject = value
            Refresh()
        End Set
    End Property

    Private _SelectionMode As SelectMode
    Public Property SelectionMode As SelectMode
        Get
            Return _SelectionMode
        End Get
        Set(value As SelectMode)
            _SelectionMode = value
            Refresh()
        End Set
    End Property

    Private _Selected As Boolean
    Public Property [Selected] As Boolean
        Get
            Return _Selected
        End Get
        Set(value As Boolean)
            If value Then
                [Select]()
            Else
                Deselect()
            End If
        End Set
    End Property

    Public Property Title As String
        Get
            Return TitleLabel.Text
        End Get
        Set(value As String)
            TitleLabel.Text = value
        End Set
    End Property

    Public Property Subtitle As String
        Get
            Return SubtitleLabel.Text
        End Get
        Set(value As String)
            If _ForcedSubtitle = "" Then
                SubtitleLabel.Text = value
            Else
                SubtitleLabel.Text = _ForcedSubtitle
            End If
        End Set
    End Property

    Private _ForcedSubtitle As String
    Public Sub SetSubtitle(Subtitle As String)
        _ForcedSubtitle = Subtitle
        SubtitleLabel.Text = Subtitle
    End Sub

    Public Property AllowDelete As Boolean
    Public Property AllowEdit As Boolean
    Public Property AllowPlay As Boolean
    Public Property AllowOpenLocation As Boolean

    Public Property ShowPlayAsStopIfPlayingAtMainWindow As Boolean

#End Region
#Region "UI"

    Public Overloads Sub Refresh()

        If AssociatedObject Is Nothing Then
            If Not DesignMode Then
                Visible = False
            End If
        Else

            Visible = True

            If TypeOf AssociatedObject Is Video Then

                With CType(AssociatedObject, Video)
                    ThumbnailBox.ImageLocation = .Thumbnail
                    Title = .Title

                    If Not .Length = Nothing Then
                        Subtitle = String.Format(Locale.ListItem_Video, .Creator)
                    Else
                        Subtitle = String.Format(Locale.ListItem_Video_Time, .Creator, .FriendlyLength)
                    End If

                End With

            ElseIf TypeOf AssociatedObject Is Playlist Then

                With CType(AssociatedObject, Playlist)
                    ThumbnailBox.ImageLocation = .Thumbnail
                    Title = .Title
                    If .Videos.Count = 0 Then
                        Subtitle = ""
                    ElseIf .Videos.Count = 1 Then
                        Subtitle = String.Format(Locale.ListItem_Playlist, .FriendlyLength)
                    Else
                        Subtitle = String.Format(Locale.ListItem_Playlist_PluralVideo, .Videos.Count.ToString, .FriendlyLength)
                    End If
                End With

            End If

        End If

        RefreshStatus()

        If RectangleToScreen(Me.ClientRectangle).Contains(MousePosition) Then
            BackColor = ColorHover
        Else
            BackColor = ColorNormal
        End If

        If SelectionMode = SelectMode.None Then

        ElseIf SelectionMode = SelectMode.ChangeBackcolor Then

            If Selected Then
                BackColor = ColorSelected
            End If

        ElseIf SelectionMode = SelectMode.Check Then
            If RectangleToScreen(Me.ClientRectangle).Contains(MousePosition) Then
                BackColor = ColorHover
            Else
                BackColor = ColorNormal
            End If

        End If

    End Sub

    Public Enum Status
        None = 0
        CurrentlyPlaying = 1
        Checked = 2
        ToBeRemoved = 3
    End Enum

    Public Property AutomaticallySetCurrentlyPlayingStatus As Boolean = True

    Public Sub SetStatus(Status As Status)
        Select Case Status
            Case Is = ListItem.Status.None
                StatusBox.Image = Nothing

            Case Is = ListItem.Status.CurrentlyPlaying
                StatusBox.Image = My.Resources.triangle_white

            Case Is = ListItem.Status.Checked
                StatusBox.Image = My.Resources.check_mark_in_white_md

            Case Is = ListItem.Status.ToBeRemoved
                StatusBox.Image = My.Resources.white_x_cross_hi

        End Select
    End Sub

    Private Sub RefreshStatus()
        Dim draw As Boolean = False

        If AssociatedObject IsNot Nothing Then

            If TypeOf AssociatedObject Is Video Then

                If MainWindow.PlaylistManager.CurrentlyPlaying Is AssociatedObject Then
                    draw = True
                End If

            ElseIf TypeOf AssociatedObject Is Playlist Then

                For Each vid In AssociatedObject.Videos
                    If MainWindow.PlaylistManager.CurrentlyPlaying Is vid Then
                        draw = True
                    End If
                Next

            End If

        End If

        If draw And AutomaticallySetCurrentlyPlayingStatus Then
            SetStatus(Status.CurrentlyPlaying)
        End If

    End Sub

#End Region
#Region "UI functionality"

    Private Sub ListItem_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        Refresh()
    End Sub

    Private Sub ListItem_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        Refresh()
    End Sub

    Private Sub Me_Click(sender As Object, e As MouseEventArgs) Handles SubtitleLabel.MouseClick, TitleLabel.MouseClick, ThumbnailBox.MouseClick, MyBase.MouseClick, StatusBox.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            RaiseEvent Click(Me, EventArgs.Empty)
            If Not Selected Then
                [Select]()
            Else
                Deselect()
            End If
        End If
    End Sub

#End Region
#Region "Methods"

    Private Sub ListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ContextMenuStrip1.Renderer = New ContextMenuRenderer
    End Sub

    Public Shadows Sub [Select](Optional SupressEvent As Boolean = False)

        If Enabled Then
            _Selected = True
            Refresh()
            If Not SupressEvent Then
                RaiseEvent OnSelected(Me)
            End If
        End If

    End Sub

    Public Sub Deselect(Optional SupressEvent As Boolean = False)

        If Enabled Then
            _Selected = False
            Refresh()
            If Not SupressEvent Then
                RaiseEvent OnDeselected(Me)
            End If
        End If

    End Sub

    Private Function DetermineServiceUri(Service As String) As String

        Select Case Service

            Case Is = "Local"
                'No image
            Case Is = "YouTube"
                Return "http://www.youtube.com/favicon.ico"
                'Case Is = "NicoNico"
                '    Return NicoNico.Net.Misc.Res.NicoNicoIcon
            Case Is = "SoundCloud"

        End Select

        Return ""

    End Function

    Public RefreshCurrentlyPlayingBox As Boolean = True

    Private Sub _DrawCheckmark(Graphics As Graphics)
        Graphics.DrawString("✔", SubtitleLabel.Font, Brushes.White, StatusBox.ClientRectangle)
    End Sub

    Private Sub _DrawCross(Graphics As Graphics)
        Graphics.DrawString("X", SubtitleLabel.Font, Brushes.White, StatusBox.ClientRectangle)
    End Sub

    Public Sub DrawCheckmark()
        Using G As Graphics = StatusBox.CreateGraphics
            _DrawCheckmark(G)
        End Using
    End Sub

    Public Sub DrawCross()
        Using G As Graphics = StatusBox.CreateGraphics
            _DrawCross(G)
        End Using
    End Sub

#End Region
#Region "Context menu"

    Public Event PlayItemClicked(sender As ListItem, e As EventArgs)
    Public Event EditItemClicked(sender As ListItem, ByRef Handled As Boolean)
    Public Event OpenLocationItemClicked(sender As ListItem, ByRef Handled As Boolean)
    Public Event DeleteItemClicked(sender As ListItem, ByRef Handled As Boolean)

    Private Sub PlayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlayToolStripMenuItem.Click
        Dim handled As Boolean = False
        RaiseEvent PlayItemClicked(Me, EventArgs.Empty)
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim handled As Boolean = False
        RaiseEvent EditItemClicked(Me, handled)
        If Not handled Then
            If TypeOf AssociatedObject Is Video Then
                Dim d As New EditVideoDialog
                d.ShowDialog(MainWindow, AssociatedObject)
                Refresh()
            ElseIf TypeOf AssociatedObject Is Playlist Then
                Dim d As New EditPlaylistDialog
                d.ShowDialog(MainWindow, AssociatedObject)
                Refresh()
            End If
        End If
    End Sub

    Private Sub OpenLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim handled As Boolean = False
        RaiseEvent OpenLocationItemClicked(Me, handled)
        If Not handled Then
            If TypeOf AssociatedObject Is Video Then
                Process.Start(CType(AssociatedObject, Video).Location)
            ElseIf TypeOf AssociatedObject Is Playlist Then
                Process.Start(PlaylistStore.FullName, "-select," + CType(AssociatedObject, Playlist).ID.ToString + ".xml")
            End If
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim handled As Boolean = False
        RaiseEvent DeleteItemClicked(Me, handled)
        If Not handled Then
            If TypeOf AssociatedObject Is Video Then
                MainWindow.PlaylistManager.Find(AssociatedObject).Remove(AssociatedObject)
            ElseIf TypeOf AssociatedObject Is Playlist Then
                MainWindow.PlaylistManager.Remove(AssociatedObject)
            End If
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

        If TypeOf AssociatedObject Is Video And ShowPlayAsStopIfPlayingAtMainWindow Then
            If MainWindow.PlaylistManager.CurrentlyPlaying Is AssociatedObject Then
                PlayToolStripMenuItem.Text = Locale.ListItem_Stop
            End If
        ElseIf TypeOf AssociatedObject Is Playlist Then
            PlayToolStripMenuItem.Text = Locale.ListItem_Open
        End If

        PlayToolStripMenuItem.Visible = AllowPlay
        EditToolStripMenuItem.Visible = AllowEdit
        OpenToolStripMenuItem.Visible = AllowOpenLocation
        DeleteToolStripMenuItem.Visible = AllowDelete
        ToolStripSeparator1.Visible = AllowDelete

        If TypeOf AssociatedObject Is Video Then
            OpenToolStripMenuItem.Text = String.Format(Locale.ListItem_OpenAt, CType(AssociatedObject, Video).Service)
        ElseIf TypeOf AssociatedObject Is Playlist Then
            OpenToolStripMenuItem.Text = String.Format(Locale.ListItem_OpenIn, "explorer")
        End If

        If Not AllowPlay And Not AllowEdit And Not AllowOpenLocation And Not AllowDelete Then
            e.Cancel = True
        End If

    End Sub

#End Region

End Class
