<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddVideoDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddVideoDialog))
        Me.PanoramaTabControl1 = New Zumwani.CommonLibrary.Controls.PanoramaTabControl()
        Me.AddFromTab = New System.Windows.Forms.TabPage()
        Me.DiskTab = New System.Windows.Forms.TabPage()
        Me.DiskAddButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.DiskPreviewBox = New Zumwani.CloudPlayer.ListItem()
        Me.BrowseButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.LocalPathBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.YouTubeTab = New System.Windows.Forms.TabPage()
        Me.YouTubeSearchResultBox = New System.Windows.Forms.FlowLayoutPanel()
        Me.YouTubeSearchBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NicoNicoTab = New System.Windows.Forms.TabPage()
        Me.NicoNicoResultsBox = New System.Windows.Forms.FlowLayoutPanel()
        Me.NicoNicoSearchBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SoundCloudTab = New System.Windows.Forms.TabPage()
        Me.SoundCloudResultsBox = New System.Windows.Forms.FlowLayoutPanel()
        Me.SoundCloudSearchBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AddedVideosList = New System.Windows.Forms.FlowLayoutPanel()
        Me.Header1 = New Zumwani.CommonLibrary.Controls.TabHeader()
        Me.AddButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.CancelButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.PanoramaTabControl1.SuspendLayout()
        Me.DiskTab.SuspendLayout()
        Me.YouTubeTab.SuspendLayout()
        Me.NicoNicoTab.SuspendLayout()
        Me.SoundCloudTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanoramaTabControl1
        '
        Me.PanoramaTabControl1.AnimationDirection = Zumwani.CommonLibrary.Controls.PanoramaTabControl.AnimationDirections.Horizontal
        Me.PanoramaTabControl1.AnimationType = Zumwani.CommonLibrary.Controls.PanoramaTabControl.AnimationTypes.None
        Me.PanoramaTabControl1.Controls.Add(Me.AddFromTab)
        Me.PanoramaTabControl1.Controls.Add(Me.DiskTab)
        Me.PanoramaTabControl1.Controls.Add(Me.YouTubeTab)
        Me.PanoramaTabControl1.Controls.Add(Me.NicoNicoTab)
        Me.PanoramaTabControl1.Controls.Add(Me.SoundCloudTab)
        Me.PanoramaTabControl1.DisplayTabs = Zumwani.CommonLibrary.Controls.PanoramaTabControl.DisplayTabsEnum.Never
        resources.ApplyResources(Me.PanoramaTabControl1, "PanoramaTabControl1")
        Me.PanoramaTabControl1.Name = "PanoramaTabControl1"
        Me.PanoramaTabControl1.SelectedIndex = 0
        Me.PanoramaTabControl1.Speed = 9
        '
        'AddFromTab
        '
        resources.ApplyResources(Me.AddFromTab, "AddFromTab")
        Me.AddFromTab.Name = "AddFromTab"
        Me.AddFromTab.UseVisualStyleBackColor = True
        '
        'DiskTab
        '
        Me.DiskTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DiskTab.Controls.Add(Me.DiskAddButton)
        Me.DiskTab.Controls.Add(Me.DiskPreviewBox)
        Me.DiskTab.Controls.Add(Me.BrowseButton)
        Me.DiskTab.Controls.Add(Me.LocalPathBox)
        Me.DiskTab.Controls.Add(Me.Label4)
        resources.ApplyResources(Me.DiskTab, "DiskTab")
        Me.DiskTab.Name = "DiskTab"
        '
        'DiskAddButton
        '
        Me.DiskAddButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.DiskAddButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.DiskAddButton.FlatAppearance.BorderSize = 0
        Me.DiskAddButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.DiskAddButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        resources.ApplyResources(Me.DiskAddButton, "DiskAddButton")
        Me.DiskAddButton.Name = "DiskAddButton"
        Me.DiskAddButton.UseVisualStyleBackColor = False
        '
        'DiskPreviewBox
        '
        Me.DiskPreviewBox.AllowDelete = False
        Me.DiskPreviewBox.AllowEdit = False
        Me.DiskPreviewBox.AllowOpenLocation = False
        Me.DiskPreviewBox.AllowPlay = False
        Me.DiskPreviewBox.AssociatedObject = Nothing
        Me.DiskPreviewBox.AutomaticallySetCurrentlyPlayingStatus = True
        Me.DiskPreviewBox.BackColor = System.Drawing.Color.Transparent
        Me.DiskPreviewBox.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.DiskPreviewBox, "DiskPreviewBox")
        Me.DiskPreviewBox.ForeColor = System.Drawing.Color.White
        Me.DiskPreviewBox.Name = "DiskPreviewBox"
        Me.DiskPreviewBox.Selected = False
        Me.DiskPreviewBox.SelectionMode = Zumwani.CloudPlayer.ListItem.SelectMode.None
        Me.DiskPreviewBox.ShowPlayAsStopIfPlayingAtMainWindow = False
        Me.DiskPreviewBox.Subtitle = "by {0}"
        Me.DiskPreviewBox.Title = "{0}"
        '
        'BrowseButton
        '
        Me.BrowseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.BrowseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.BrowseButton.FlatAppearance.BorderSize = 0
        Me.BrowseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.BrowseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        resources.ApplyResources(Me.BrowseButton, "BrowseButton")
        Me.BrowseButton.Name = "BrowseButton"
        Me.BrowseButton.UseVisualStyleBackColor = False
        '
        'LocalPathBox
        '
        resources.ApplyResources(Me.LocalPathBox, "LocalPathBox")
        Me.LocalPathBox.Name = "LocalPathBox"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'YouTubeTab
        '
        Me.YouTubeTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.YouTubeTab.Controls.Add(Me.YouTubeSearchResultBox)
        Me.YouTubeTab.Controls.Add(Me.YouTubeSearchBox)
        Me.YouTubeTab.Controls.Add(Me.Label3)
        resources.ApplyResources(Me.YouTubeTab, "YouTubeTab")
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
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'NicoNicoTab
        '
        Me.NicoNicoTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.NicoNicoTab.Controls.Add(Me.NicoNicoResultsBox)
        Me.NicoNicoTab.Controls.Add(Me.NicoNicoSearchBox)
        Me.NicoNicoTab.Controls.Add(Me.Label2)
        resources.ApplyResources(Me.NicoNicoTab, "NicoNicoTab")
        Me.NicoNicoTab.Name = "NicoNicoTab"
        '
        'NicoNicoResultsBox
        '
        resources.ApplyResources(Me.NicoNicoResultsBox, "NicoNicoResultsBox")
        Me.NicoNicoResultsBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NicoNicoResultsBox.Name = "NicoNicoResultsBox"
        '
        'NicoNicoSearchBox
        '
        resources.ApplyResources(Me.NicoNicoSearchBox, "NicoNicoSearchBox")
        Me.NicoNicoSearchBox.Name = "NicoNicoSearchBox"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'SoundCloudTab
        '
        Me.SoundCloudTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.SoundCloudTab.Controls.Add(Me.SoundCloudResultsBox)
        Me.SoundCloudTab.Controls.Add(Me.SoundCloudSearchBox)
        Me.SoundCloudTab.Controls.Add(Me.Label1)
        resources.ApplyResources(Me.SoundCloudTab, "SoundCloudTab")
        Me.SoundCloudTab.Name = "SoundCloudTab"
        '
        'SoundCloudResultsBox
        '
        resources.ApplyResources(Me.SoundCloudResultsBox, "SoundCloudResultsBox")
        Me.SoundCloudResultsBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SoundCloudResultsBox.Name = "SoundCloudResultsBox"
        '
        'SoundCloudSearchBox
        '
        resources.ApplyResources(Me.SoundCloudSearchBox, "SoundCloudSearchBox")
        Me.SoundCloudSearchBox.Name = "SoundCloudSearchBox"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'AddedVideosList
        '
        resources.ApplyResources(Me.AddedVideosList, "AddedVideosList")
        Me.AddedVideosList.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.AddedVideosList.Name = "AddedVideosList"
        '
        'Header1
        '
        Me.Header1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.Header1.ColorHover = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Header1.ColorSelected = System.Drawing.Color.White
        Me.Header1.ColorUnselected = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.Header1.DisabledTabPages = New String() {"Add from:", "TabPage3"}
        resources.ApplyResources(Me.Header1, "Header1")
        Me.Header1.HiddenTabPages = New String() {"Nico Nico"}
        Me.Header1.Name = "Header1"
        Me.Header1.TabControl = Me.PanoramaTabControl1
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
        'AddVideoDialog
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.CloseOnEscape = True
        Me.Controls.Add(Me.AddButton)
        Me.Controls.Add(Me.CancelButton)
        Me.Controls.Add(Me.PanoramaTabControl1)
        Me.Controls.Add(Me.AddedVideosList)
        Me.Controls.Add(Me.Header1)
        Me.Name = "AddVideoDialog"
        Me.PanoramaTabControl1.ResumeLayout(False)
        Me.DiskTab.ResumeLayout(False)
        Me.DiskTab.PerformLayout()
        Me.YouTubeTab.ResumeLayout(False)
        Me.YouTubeTab.PerformLayout()
        Me.NicoNicoTab.ResumeLayout(False)
        Me.NicoNicoTab.PerformLayout()
        Me.SoundCloudTab.ResumeLayout(False)
        Me.SoundCloudTab.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanoramaTabControl1 As Zumwani.CommonLibrary.Controls.PanoramaTabControl
    Friend WithEvents AddFromTab As System.Windows.Forms.TabPage
    Friend WithEvents Header1 As Zumwani.CommonLibrary.Controls.TabHeader
    Friend WithEvents SoundCloudTab As System.Windows.Forms.TabPage
    Friend WithEvents AddButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend Shadows WithEvents CancelButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents YouTubeTab As System.Windows.Forms.TabPage
    Friend WithEvents YouTubeSearchBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents YouTubeSearchResultBox As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents AddedVideosList As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents DiskTab As System.Windows.Forms.TabPage
    Friend WithEvents BrowseButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents LocalPathBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DiskPreviewBox As Zumwani.CloudPlayer.ListItem
    Friend WithEvents DiskAddButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents SoundCloudResultsBox As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents SoundCloudSearchBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NicoNicoTab As System.Windows.Forms.TabPage
    Friend WithEvents NicoNicoResultsBox As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents NicoNicoSearchBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
