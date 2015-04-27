<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
    Inherits Zumwani.CommonLibrary.Templates.Window

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SettingsButton = New System.Windows.Forms.Button()
        Me.AddButton = New System.Windows.Forms.Button()
        Me.PlaylistsButton = New System.Windows.Forms.Button()
        Me.CurrentlyPlayingButton = New System.Windows.Forms.Button()
        Me.ContentPanel = New System.Windows.Forms.Panel()
        Me.InnerContentPanel = New System.Windows.Forms.Panel()
        Me.PlaylistOptionsShadowPanel = New System.Windows.Forms.Panel()
        Me.PlaylistTitleLabel = New System.Windows.Forms.Label()
        Me.VideoGradientPanel = New System.Windows.Forms.Panel()
        Me.List = New System.Windows.Forms.FlowLayoutPanel()
        Me.MediaPlayer1 = New Zumwani.CloudPlayer.MediaPlayer()
        Me.PlaylistOptionsPanel = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ContentPanel.SuspendLayout()
        Me.InnerContentPanel.SuspendLayout()
        Me.PlaylistOptionsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.White
        '
        'SettingsButton
        '
        Me.SettingsButton.BackgroundImage = Global.Zumwani.CloudPlayer.My.Resources.Resources.SettingsIcon
        resources.ApplyResources(Me.SettingsButton, "SettingsButton")
        Me.SettingsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.SettingsButton.FlatAppearance.BorderSize = 0
        Me.SettingsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.SettingsButton.Name = "SettingsButton"
        Me.ToolTip1.SetToolTip(Me.SettingsButton, resources.GetString("SettingsButton.ToolTip"))
        Me.SettingsButton.UseVisualStyleBackColor = True
        '
        'AddButton
        '
        Me.AddButton.BackgroundImage = Global.Zumwani.CloudPlayer.My.Resources.Resources.AddIcon
        resources.ApplyResources(Me.AddButton, "AddButton")
        Me.AddButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.AddButton.FlatAppearance.BorderSize = 0
        Me.AddButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.AddButton.Name = "AddButton"
        Me.ToolTip1.SetToolTip(Me.AddButton, resources.GetString("AddButton.ToolTip"))
        Me.AddButton.UseVisualStyleBackColor = True
        '
        'PlaylistsButton
        '
        Me.PlaylistsButton.BackgroundImage = Global.Zumwani.CloudPlayer.My.Resources.Resources.PlaylistIcon
        resources.ApplyResources(Me.PlaylistsButton, "PlaylistsButton")
        Me.PlaylistsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.PlaylistsButton.FlatAppearance.BorderSize = 0
        Me.PlaylistsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.PlaylistsButton.Name = "PlaylistsButton"
        Me.ToolTip1.SetToolTip(Me.PlaylistsButton, resources.GetString("PlaylistsButton.ToolTip"))
        Me.PlaylistsButton.UseVisualStyleBackColor = True
        '
        'CurrentlyPlayingButton
        '
        resources.ApplyResources(Me.CurrentlyPlayingButton, "CurrentlyPlayingButton")
        Me.CurrentlyPlayingButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.CurrentlyPlayingButton.FlatAppearance.BorderSize = 0
        Me.CurrentlyPlayingButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.CurrentlyPlayingButton.Name = "CurrentlyPlayingButton"
        Me.ToolTip1.SetToolTip(Me.CurrentlyPlayingButton, resources.GetString("CurrentlyPlayingButton.ToolTip"))
        Me.CurrentlyPlayingButton.UseVisualStyleBackColor = True
        '
        'ContentPanel
        '
        resources.ApplyResources(Me.ContentPanel, "ContentPanel")
        Me.ContentPanel.Controls.Add(Me.InnerContentPanel)
        Me.ContentPanel.Name = "ContentPanel"
        '
        'InnerContentPanel
        '
        Me.InnerContentPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.InnerContentPanel.Controls.Add(Me.PlaylistOptionsShadowPanel)
        Me.InnerContentPanel.Controls.Add(Me.PlaylistTitleLabel)
        Me.InnerContentPanel.Controls.Add(Me.VideoGradientPanel)
        Me.InnerContentPanel.Controls.Add(Me.List)
        Me.InnerContentPanel.Controls.Add(Me.MediaPlayer1)
        resources.ApplyResources(Me.InnerContentPanel, "InnerContentPanel")
        Me.InnerContentPanel.Name = "InnerContentPanel"
        '
        'PlaylistOptionsShadowPanel
        '
        resources.ApplyResources(Me.PlaylistOptionsShadowPanel, "PlaylistOptionsShadowPanel")
        Me.PlaylistOptionsShadowPanel.Name = "PlaylistOptionsShadowPanel"
        '
        'PlaylistTitleLabel
        '
        Me.PlaylistTitleLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        resources.ApplyResources(Me.PlaylistTitleLabel, "PlaylistTitleLabel")
        Me.PlaylistTitleLabel.Name = "PlaylistTitleLabel"
        '
        'VideoGradientPanel
        '
        resources.ApplyResources(Me.VideoGradientPanel, "VideoGradientPanel")
        Me.VideoGradientPanel.Name = "VideoGradientPanel"
        '
        'List
        '
        resources.ApplyResources(Me.List, "List")
        Me.List.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.List.Name = "List"
        '
        'MediaPlayer1
        '
        resources.ApplyResources(Me.MediaPlayer1, "MediaPlayer1")
        Me.MediaPlayer1.Name = "MediaPlayer1"
        '
        'PlaylistOptionsPanel
        '
        resources.ApplyResources(Me.PlaylistOptionsPanel, "PlaylistOptionsPanel")
        Me.PlaylistOptionsPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.PlaylistOptionsPanel.Controls.Add(Me.Button1)
        Me.PlaylistOptionsPanel.Controls.Add(Me.SettingsButton)
        Me.PlaylistOptionsPanel.Controls.Add(Me.Label4)
        Me.PlaylistOptionsPanel.Controls.Add(Me.AddButton)
        Me.PlaylistOptionsPanel.Controls.Add(Me.PlaylistsButton)
        Me.PlaylistOptionsPanel.Controls.Add(Me.Label3)
        Me.PlaylistOptionsPanel.Controls.Add(Me.CurrentlyPlayingButton)
        Me.PlaylistOptionsPanel.Name = "PlaylistOptionsPanel"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        resources.ApplyResources(Me.ToolStripMenuItem3, "ToolStripMenuItem3")
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        resources.ApplyResources(Me.ToolStripMenuItem4, "ToolStripMenuItem4")
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MainWindow
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.Controls.Add(Me.PlaylistOptionsPanel)
        Me.Controls.Add(Me.ContentPanel)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.KeyPreview = True
        Me.Name = "MainWindow"
        Me.ShowResizeTooltips = True
        Me.Tag = ""
        Me.ContentPanel.ResumeLayout(False)
        Me.InnerContentPanel.ResumeLayout(False)
        Me.InnerContentPanel.PerformLayout()
        Me.PlaylistOptionsPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PlaylistOptionsPanel As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ContentPanel As System.Windows.Forms.Panel
    Friend WithEvents CopyLinkToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents List As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents PlaylistTitleLabel As System.Windows.Forms.Label
    Friend WithEvents InnerContentPanel As System.Windows.Forms.Panel
    Friend WithEvents VideoGradientPanel As System.Windows.Forms.Panel
    Friend WithEvents SettingsButton As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents AddButton As System.Windows.Forms.Button
    Friend WithEvents PlaylistsButton As System.Windows.Forms.Button
    Friend WithEvents CurrentlyPlayingButton As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MediaPlayer1 As Zumwani.CloudPlayer.MediaPlayer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PlaylistOptionsShadowPanel As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
