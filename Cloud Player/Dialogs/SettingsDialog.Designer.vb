<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsDialog
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
        Me.SaveWindowRectangleButton = New System.Windows.Forms.Button()
        Me.RestorePositionAtStartBox = New System.Windows.Forms.CheckBox()
        Me.SavePositionAtCloseBox = New System.Windows.Forms.CheckBox()
        Me.LanguageBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RestartMessageLabel = New System.Windows.Forms.Label()
        Me.RestartNowLink = New System.Windows.Forms.LinkLabel()
        Me.PanoramaTabControl1 = New Zumwani.CommonLibrary.Controls.PanoramaTabControl()
        Me.GeneralTab = New System.Windows.Forms.TabPage()
        Me.PlaylistTab = New System.Windows.Forms.TabPage()
        Me.ObjectListView1 = New BrightIdeasSoftware.ObjectListView()
        Me.TitleColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.VideoCountColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.PathColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ExportButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.ImportButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TabHeader1 = New Zumwani.CommonLibrary.Controls.TabHeader()
        Me.PlaylistContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenLocationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PanoramaTabControl1.SuspendLayout()
        Me.GeneralTab.SuspendLayout()
        Me.PlaylistTab.SuspendLayout()
        CType(Me.ObjectListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PlaylistContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'SaveWindowRectangleButton
        '
        Me.SaveWindowRectangleButton.ForeColor = System.Drawing.Color.Black
        Me.SaveWindowRectangleButton.Location = New System.Drawing.Point(84, 245)
        Me.SaveWindowRectangleButton.Name = "SaveWindowRectangleButton"
        Me.SaveWindowRectangleButton.Size = New System.Drawing.Size(274, 30)
        Me.SaveWindowRectangleButton.TabIndex = 3
        Me.SaveWindowRectangleButton.Text = "Save window position and size now"
        Me.SaveWindowRectangleButton.UseVisualStyleBackColor = True
        '
        'RestorePositionAtStartBox
        '
        Me.RestorePositionAtStartBox.AutoSize = True
        Me.RestorePositionAtStartBox.Location = New System.Drawing.Point(84, 216)
        Me.RestorePositionAtStartBox.Name = "RestorePositionAtStartBox"
        Me.RestorePositionAtStartBox.Size = New System.Drawing.Size(274, 23)
        Me.RestorePositionAtStartBox.TabIndex = 2
        Me.RestorePositionAtStartBox.Text = "Restore window position and size at start"
        Me.RestorePositionAtStartBox.UseVisualStyleBackColor = True
        '
        'SavePositionAtCloseBox
        '
        Me.SavePositionAtCloseBox.AutoSize = True
        Me.SavePositionAtCloseBox.Location = New System.Drawing.Point(84, 190)
        Me.SavePositionAtCloseBox.Name = "SavePositionAtCloseBox"
        Me.SavePositionAtCloseBox.Size = New System.Drawing.Size(261, 23)
        Me.SavePositionAtCloseBox.TabIndex = 1
        Me.SavePositionAtCloseBox.Text = "Save window position and size at close"
        Me.SavePositionAtCloseBox.UseVisualStyleBackColor = True
        '
        'LanguageBox
        '
        Me.LanguageBox.DisplayMember = "DisplayName"
        Me.LanguageBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LanguageBox.FormattingEnabled = True
        Me.LanguageBox.Location = New System.Drawing.Point(54, 66)
        Me.LanguageBox.Name = "LanguageBox"
        Me.LanguageBox.Size = New System.Drawing.Size(200, 25)
        Me.LanguageBox.TabIndex = 6
        Me.LanguageBox.ValueMember = "DisplayName"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(50, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 19)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Language:"
        '
        'RestartMessageLabel
        '
        Me.RestartMessageLabel.AutoSize = True
        Me.RestartMessageLabel.Location = New System.Drawing.Point(50, 94)
        Me.RestartMessageLabel.Name = "RestartMessageLabel"
        Me.RestartMessageLabel.Size = New System.Drawing.Size(316, 19)
        Me.RestartMessageLabel.TabIndex = 8
        Me.RestartMessageLabel.Text = "Cloud player must be restarted to switch language."
        Me.RestartMessageLabel.Visible = False
        '
        'RestartNowLink
        '
        Me.RestartNowLink.AutoSize = True
        Me.RestartNowLink.LinkColor = System.Drawing.Color.Gainsboro
        Me.RestartNowLink.Location = New System.Drawing.Point(361, 94)
        Me.RestartNowLink.Name = "RestartNowLink"
        Me.RestartNowLink.Size = New System.Drawing.Size(82, 19)
        Me.RestartNowLink.TabIndex = 9
        Me.RestartNowLink.TabStop = True
        Me.RestartNowLink.Text = "Restart now."
        Me.RestartNowLink.Visible = False
        '
        'PanoramaTabControl1
        '
        Me.PanoramaTabControl1.AnimationDirection = Zumwani.CommonLibrary.Controls.PanoramaTabControl.AnimationDirections.Horizontal
        Me.PanoramaTabControl1.AnimationType = Zumwani.CommonLibrary.Controls.PanoramaTabControl.AnimationTypes.None
        Me.PanoramaTabControl1.Controls.Add(Me.GeneralTab)
        Me.PanoramaTabControl1.Controls.Add(Me.PlaylistTab)
        Me.PanoramaTabControl1.DisplayTabs = Zumwani.CommonLibrary.Controls.PanoramaTabControl.DisplayTabsEnum.Never
        Me.PanoramaTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanoramaTabControl1.Location = New System.Drawing.Point(0, 40)
        Me.PanoramaTabControl1.Name = "PanoramaTabControl1"
        Me.PanoramaTabControl1.SelectedIndex = 0
        Me.PanoramaTabControl1.Size = New System.Drawing.Size(605, 381)
        Me.PanoramaTabControl1.Speed = 9
        Me.PanoramaTabControl1.TabIndex = 10
        '
        'GeneralTab
        '
        Me.GeneralTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.GeneralTab.Controls.Add(Me.Label1)
        Me.GeneralTab.Controls.Add(Me.RestartNowLink)
        Me.GeneralTab.Controls.Add(Me.SavePositionAtCloseBox)
        Me.GeneralTab.Controls.Add(Me.RestartMessageLabel)
        Me.GeneralTab.Controls.Add(Me.RestorePositionAtStartBox)
        Me.GeneralTab.Controls.Add(Me.SaveWindowRectangleButton)
        Me.GeneralTab.Controls.Add(Me.LanguageBox)
        Me.GeneralTab.Location = New System.Drawing.Point(0, 0)
        Me.GeneralTab.Name = "GeneralTab"
        Me.GeneralTab.Padding = New System.Windows.Forms.Padding(30)
        Me.GeneralTab.Size = New System.Drawing.Size(605, 381)
        Me.GeneralTab.TabIndex = 0
        Me.GeneralTab.Text = "General"
        '
        'PlaylistTab
        '
        Me.PlaylistTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.PlaylistTab.Controls.Add(Me.ObjectListView1)
        Me.PlaylistTab.Controls.Add(Me.ExportButton)
        Me.PlaylistTab.Controls.Add(Me.ImportButton)
        Me.PlaylistTab.Controls.Add(Me.CheckBox1)
        Me.PlaylistTab.Location = New System.Drawing.Point(0, 0)
        Me.PlaylistTab.Name = "PlaylistTab"
        Me.PlaylistTab.Padding = New System.Windows.Forms.Padding(30, 30, 30, 100)
        Me.PlaylistTab.Size = New System.Drawing.Size(605, 381)
        Me.PlaylistTab.TabIndex = 1
        Me.PlaylistTab.Text = "Playlists"
        '
        'ObjectListView1
        '
        Me.ObjectListView1.AllColumns.Add(Me.TitleColumn)
        Me.ObjectListView1.AllColumns.Add(Me.VideoCountColumn)
        Me.ObjectListView1.AllColumns.Add(Me.PathColumn)
        Me.ObjectListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.TitleColumn, Me.VideoCountColumn, Me.PathColumn})
        Me.ObjectListView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ObjectListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ObjectListView1.FullRowSelect = True
        Me.ObjectListView1.Location = New System.Drawing.Point(30, 30)
        Me.ObjectListView1.Name = "ObjectListView1"
        Me.ObjectListView1.OwnerDraw = True
        Me.ObjectListView1.ShowGroups = False
        Me.ObjectListView1.Size = New System.Drawing.Size(545, 251)
        Me.ObjectListView1.TabIndex = 11
        Me.ObjectListView1.UseCompatibleStateImageBehavior = False
        Me.ObjectListView1.UseExplorerTheme = True
        Me.ObjectListView1.UseHotItem = True
        Me.ObjectListView1.UseHyperlinks = True
        Me.ObjectListView1.UseTranslucentHotItem = True
        Me.ObjectListView1.UseTranslucentSelection = True
        Me.ObjectListView1.View = System.Windows.Forms.View.Details
        '
        'TitleColumn
        '
        Me.TitleColumn.AspectName = "Title"
        Me.TitleColumn.Text = "Title:"
        Me.TitleColumn.Width = 200
        '
        'VideoCountColumn
        '
        Me.VideoCountColumn.AspectName = "Videos.Count"
        Me.VideoCountColumn.Text = "Video Count:"
        Me.VideoCountColumn.Width = 85
        '
        'PathColumn
        '
        Me.PathColumn.AspectName = "GetLocation"
        Me.PathColumn.FillsFreeSpace = True
        Me.PathColumn.Hyperlink = True
        Me.PathColumn.Text = "Path:"
        '
        'ExportButton
        '
        Me.ExportButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ExportButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ExportButton.FlatAppearance.BorderSize = 0
        Me.ExportButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ExportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.ExportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExportButton.Location = New System.Drawing.Point(422, 323)
        Me.ExportButton.Name = "ExportButton"
        Me.ExportButton.Size = New System.Drawing.Size(150, 30)
        Me.ExportButton.TabIndex = 7
        Me.ExportButton.Text = "Export playlist"
        Me.ExportButton.UseVisualStyleBackColor = False
        '
        'ImportButton
        '
        Me.ImportButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ImportButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ImportButton.FlatAppearance.BorderSize = 0
        Me.ImportButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ImportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.ImportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ImportButton.Location = New System.Drawing.Point(422, 287)
        Me.ImportButton.Name = "ImportButton"
        Me.ImportButton.Size = New System.Drawing.Size(150, 30)
        Me.ImportButton.TabIndex = 6
        Me.ImportButton.Text = "Import playlist"
        Me.ImportButton.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(30, 287)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(197, 23)
        Me.CheckBox1.TabIndex = 5
        Me.CheckBox1.Text = "Delete playlists permanently"
        Me.ToolTip1.SetToolTip(Me.CheckBox1, "Delete the playlist file rather than move it to the recycle bin when removing pla" & _
        "ylists.")
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TabHeader1
        '
        Me.TabHeader1.ColorHover = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.TabHeader1.ColorSelected = System.Drawing.Color.White
        Me.TabHeader1.ColorUnselected = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.TabHeader1.DisabledTabPages = New String(-1) {}
        Me.TabHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabHeader1.Font = New System.Drawing.Font("Segoe UI Semilight", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TabHeader1.HiddenTabPages = New String(-1) {}
        Me.TabHeader1.Location = New System.Drawing.Point(0, 0)
        Me.TabHeader1.Name = "TabHeader1"
        Me.TabHeader1.Size = New System.Drawing.Size(605, 40)
        Me.TabHeader1.TabControl = Me.PanoramaTabControl1
        Me.TabHeader1.TabIndex = 11
        '
        'PlaylistContextMenu
        '
        Me.PlaylistContextMenu.BackColor = System.Drawing.Color.White
        Me.PlaylistContextMenu.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.PlaylistContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.OpenLocationToolStripMenuItem, Me.ExportToolStripMenuItem, Me.ToolStripSeparator1, Me.DeleteToolStripMenuItem})
        Me.PlaylistContextMenu.Name = "PlaylistContextMenu"
        Me.PlaylistContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.PlaylistContextMenu.Size = New System.Drawing.Size(165, 106)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(164, 24)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'OpenLocationToolStripMenuItem
        '
        Me.OpenLocationToolStripMenuItem.Name = "OpenLocationToolStripMenuItem"
        Me.OpenLocationToolStripMenuItem.Size = New System.Drawing.Size(164, 24)
        Me.OpenLocationToolStripMenuItem.Text = "Open location"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(164, 24)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(161, 6)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(164, 24)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.White
        '
        'SettingsDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 421)
        Me.CloseOnEscape = True
        Me.Controls.Add(Me.PanoramaTabControl1)
        Me.Controls.Add(Me.TabHeader1)
        Me.Name = "SettingsDialog"
        Me.Text = "Settings"
        Me.PanoramaTabControl1.ResumeLayout(False)
        Me.GeneralTab.ResumeLayout(False)
        Me.GeneralTab.PerformLayout()
        Me.PlaylistTab.ResumeLayout(False)
        Me.PlaylistTab.PerformLayout()
        CType(Me.ObjectListView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PlaylistContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SavePositionAtCloseBox As System.Windows.Forms.CheckBox
    Friend WithEvents RestorePositionAtStartBox As System.Windows.Forms.CheckBox
    Friend WithEvents SaveWindowRectangleButton As System.Windows.Forms.Button
    Friend WithEvents LanguageBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RestartMessageLabel As System.Windows.Forms.Label
    Friend WithEvents RestartNowLink As System.Windows.Forms.LinkLabel
    Friend WithEvents PanoramaTabControl1 As Zumwani.CommonLibrary.Controls.PanoramaTabControl
    Friend WithEvents GeneralTab As System.Windows.Forms.TabPage
    Friend WithEvents PlaylistTab As System.Windows.Forms.TabPage
    Friend WithEvents TabHeader1 As Zumwani.CommonLibrary.Controls.TabHeader
    Friend WithEvents ExportButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents ImportButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ObjectListView1 As BrightIdeasSoftware.ObjectListView
    Friend WithEvents TitleColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents VideoCountColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents PathColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents PlaylistContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenLocationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
