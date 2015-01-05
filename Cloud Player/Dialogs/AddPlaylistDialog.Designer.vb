<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddPlaylistDialog
    Inherits Zumwani.CommonLibrary.Templates.Dialog

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddPlaylistDialog))
        Me.Header1 = New Zumwani.CommonLibrary.Controls.TabHeader()
        Me.PanoramaTabControl1 = New Zumwani.CommonLibrary.Controls.PanoramaTabControl()
        Me.CreateNewTab = New System.Windows.Forms.TabPage()
        Me.BrowseButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.ThumbnailBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TitleBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Or_ImportFromTab = New System.Windows.Forms.TabPage()
        Me.YouTubeTab = New System.Windows.Forms.TabPage()
        Me.YouTubeSearchResultBox = New System.Windows.Forms.FlowLayoutPanel()
        Me.YouTubeSearchBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SoundCloudTab = New System.Windows.Forms.TabPage()
        Me.SoundCloudPreview = New Zumwani.CloudPlayer.ListItem()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PlaylistPreviewPanel = New System.Windows.Forms.Panel()
        Me.PlaylistPreview = New Zumwani.CloudPlayer.ListItem()
        Me.CancelButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.AddButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.PanoramaTabControl1.SuspendLayout()
        Me.CreateNewTab.SuspendLayout()
        Me.YouTubeTab.SuspendLayout()
        Me.SoundCloudTab.SuspendLayout()
        Me.PlaylistPreviewPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Header1
        '
        resources.ApplyResources(Me.Header1, "Header1")
        Me.Header1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.Header1.ColorHover = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Header1.ColorSelected = System.Drawing.Color.White
        Me.Header1.ColorUnselected = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.Header1.DisabledTabPages = New String() {"...Or import from:"}
        Me.Header1.HiddenTabPages = New String() {"SoundCloud"}
        Me.Header1.Name = "Header1"
        Me.Header1.TabControl = Me.PanoramaTabControl1
        '
        'PanoramaTabControl1
        '
        resources.ApplyResources(Me.PanoramaTabControl1, "PanoramaTabControl1")
        Me.PanoramaTabControl1.AnimationDirection = Zumwani.CommonLibrary.Controls.PanoramaTabControl.AnimationDirections.Horizontal
        Me.PanoramaTabControl1.AnimationType = Zumwani.CommonLibrary.Controls.PanoramaTabControl.AnimationTypes.None
        Me.PanoramaTabControl1.Controls.Add(Me.CreateNewTab)
        Me.PanoramaTabControl1.Controls.Add(Me.Or_ImportFromTab)
        Me.PanoramaTabControl1.Controls.Add(Me.YouTubeTab)
        Me.PanoramaTabControl1.Controls.Add(Me.SoundCloudTab)
        Me.PanoramaTabControl1.DisplayTabs = Zumwani.CommonLibrary.Controls.PanoramaTabControl.DisplayTabsEnum.Never
        Me.PanoramaTabControl1.Name = "PanoramaTabControl1"
        Me.PanoramaTabControl1.SelectedIndex = 0
        Me.PanoramaTabControl1.Speed = 9
        '
        'CreateNewTab
        '
        resources.ApplyResources(Me.CreateNewTab, "CreateNewTab")
        Me.CreateNewTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.CreateNewTab.Controls.Add(Me.BrowseButton)
        Me.CreateNewTab.Controls.Add(Me.ThumbnailBox)
        Me.CreateNewTab.Controls.Add(Me.Label2)
        Me.CreateNewTab.Controls.Add(Me.TitleBox)
        Me.CreateNewTab.Controls.Add(Me.Label1)
        Me.CreateNewTab.Name = "CreateNewTab"
        '
        'BrowseButton
        '
        resources.ApplyResources(Me.BrowseButton, "BrowseButton")
        Me.BrowseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.BrowseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.BrowseButton.FlatAppearance.BorderSize = 0
        Me.BrowseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.BrowseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.BrowseButton.Name = "BrowseButton"
        Me.BrowseButton.UseVisualStyleBackColor = False
        '
        'ThumbnailBox
        '
        resources.ApplyResources(Me.ThumbnailBox, "ThumbnailBox")
        Me.ThumbnailBox.Name = "ThumbnailBox"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'TitleBox
        '
        resources.ApplyResources(Me.TitleBox, "TitleBox")
        Me.TitleBox.Name = "TitleBox"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Or_ImportFromTab
        '
        resources.ApplyResources(Me.Or_ImportFromTab, "Or_ImportFromTab")
        Me.Or_ImportFromTab.Name = "Or_ImportFromTab"
        Me.Or_ImportFromTab.UseVisualStyleBackColor = True
        '
        'YouTubeTab
        '
        resources.ApplyResources(Me.YouTubeTab, "YouTubeTab")
        Me.YouTubeTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.YouTubeTab.Controls.Add(Me.YouTubeSearchResultBox)
        Me.YouTubeTab.Controls.Add(Me.YouTubeSearchBox)
        Me.YouTubeTab.Controls.Add(Me.Label4)
        Me.YouTubeTab.Name = "YouTubeTab"
        '
        'YouTubeSearchResultBox
        '
        resources.ApplyResources(Me.YouTubeSearchResultBox, "YouTubeSearchResultBox")
        Me.YouTubeSearchResultBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.YouTubeSearchResultBox.Name = "YouTubeSearchResultBox"
        '
        'YouTubeSearchBox
        '
        resources.ApplyResources(Me.YouTubeSearchBox, "YouTubeSearchBox")
        Me.YouTubeSearchBox.Name = "YouTubeSearchBox"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'SoundCloudTab
        '
        resources.ApplyResources(Me.SoundCloudTab, "SoundCloudTab")
        Me.SoundCloudTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.SoundCloudTab.Controls.Add(Me.SoundCloudPreview)
        Me.SoundCloudTab.Controls.Add(Me.TextBox1)
        Me.SoundCloudTab.Controls.Add(Me.Label3)
        Me.SoundCloudTab.Name = "SoundCloudTab"
        '
        'SoundCloudPreview
        '
        resources.ApplyResources(Me.SoundCloudPreview, "SoundCloudPreview")
        Me.SoundCloudPreview.AllowDelete = False
        Me.SoundCloudPreview.AllowEdit = False
        Me.SoundCloudPreview.AllowOpenLocation = False
        Me.SoundCloudPreview.AllowPlay = False
        Me.SoundCloudPreview.AssociatedObject = Nothing
        Me.SoundCloudPreview.AutomaticallySetCurrentlyPlayingStatus = True
        Me.SoundCloudPreview.BackColor = System.Drawing.Color.Transparent
        Me.SoundCloudPreview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SoundCloudPreview.ForeColor = System.Drawing.Color.White
        Me.SoundCloudPreview.Name = "SoundCloudPreview"
        Me.SoundCloudPreview.Selected = False
        Me.SoundCloudPreview.SelectionMode = Zumwani.CloudPlayer.ListItem.SelectMode.None
        Me.SoundCloudPreview.ShowPlayAsStopIfPlayingAtMainWindow = False
        Me.SoundCloudPreview.Subtitle = "by [Uploader]"
        Me.SoundCloudPreview.Title = "[Video Title]"
        '
        'TextBox1
        '
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'PlaylistPreviewPanel
        '
        resources.ApplyResources(Me.PlaylistPreviewPanel, "PlaylistPreviewPanel")
        Me.PlaylistPreviewPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PlaylistPreviewPanel.Controls.Add(Me.PlaylistPreview)
        Me.PlaylistPreviewPanel.Name = "PlaylistPreviewPanel"
        '
        'PlaylistPreview
        '
        resources.ApplyResources(Me.PlaylistPreview, "PlaylistPreview")
        Me.PlaylistPreview.AllowDelete = False
        Me.PlaylistPreview.AllowEdit = False
        Me.PlaylistPreview.AllowOpenLocation = False
        Me.PlaylistPreview.AllowPlay = False
        Me.PlaylistPreview.AssociatedObject = Nothing
        Me.PlaylistPreview.AutomaticallySetCurrentlyPlayingStatus = True
        Me.PlaylistPreview.BackColor = System.Drawing.Color.Transparent
        Me.PlaylistPreview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PlaylistPreview.ForeColor = System.Drawing.Color.White
        Me.PlaylistPreview.Name = "PlaylistPreview"
        Me.PlaylistPreview.Selected = False
        Me.PlaylistPreview.SelectionMode = Zumwani.CloudPlayer.ListItem.SelectMode.None
        Me.PlaylistPreview.ShowPlayAsStopIfPlayingAtMainWindow = False
        Me.PlaylistPreview.Subtitle = "by [Uploader]"
        Me.PlaylistPreview.Title = "[Video Title]"
        '
        'CancelButton
        '
        resources.ApplyResources(Me.CancelButton, "CancelButton")
        Me.CancelButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.CancelButton.FlatAppearance.BorderSize = 0
        Me.CancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.UseVisualStyleBackColor = False
        '
        'AddButton
        '
        resources.ApplyResources(Me.AddButton, "AddButton")
        Me.AddButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.AddButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.AddButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.AddButton.FlatAppearance.BorderSize = 0
        Me.AddButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.AddButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.AddButton.Name = "AddButton"
        Me.AddButton.UseVisualStyleBackColor = False
        '
        'AddPlaylistDialog
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.CloseOnEscape = True
        Me.Controls.Add(Me.PlaylistPreviewPanel)
        Me.Controls.Add(Me.AddButton)
        Me.Controls.Add(Me.CancelButton)
        Me.Controls.Add(Me.PanoramaTabControl1)
        Me.Controls.Add(Me.Header1)
        Me.Name = "AddPlaylistDialog"
        Me.PanoramaTabControl1.ResumeLayout(False)
        Me.CreateNewTab.ResumeLayout(False)
        Me.CreateNewTab.PerformLayout()
        Me.YouTubeTab.ResumeLayout(False)
        Me.YouTubeTab.PerformLayout()
        Me.SoundCloudTab.ResumeLayout(False)
        Me.SoundCloudTab.PerformLayout()
        Me.PlaylistPreviewPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Header1 As Zumwani.CommonLibrary.Controls.TabHeader
    Friend WithEvents PanoramaTabControl1 As Zumwani.CommonLibrary.Controls.PanoramaTabControl
    Friend WithEvents CreateNewTab As System.Windows.Forms.TabPage
    Friend WithEvents Or_ImportFromTab As System.Windows.Forms.TabPage
    Friend WithEvents YouTubeTab As System.Windows.Forms.TabPage
    Friend WithEvents TitleBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ThumbnailBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents YouTubeSearchBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend Shadows WithEvents CancelButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents AddButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents PlaylistPreview As Zumwani.CloudPlayer.ListItem
    Friend WithEvents SoundCloudTab As System.Windows.Forms.TabPage
    Friend WithEvents SoundCloudPreview As Zumwani.CloudPlayer.ListItem
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents YouTubeSearchResultBox As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents PlaylistPreviewPanel As System.Windows.Forms.Panel
    Friend WithEvents BrowseButton As Zumwani.CommonLibrary.Controls.MetroButton
End Class
