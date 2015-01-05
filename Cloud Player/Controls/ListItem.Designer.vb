<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListItem
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListItem))
        Me.ThumbnailBox = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PlayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.StatusBox = New System.Windows.Forms.PictureBox()
        Me.SubtitleLabel = New System.Windows.Forms.Label()
        CType(Me.ThumbnailBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.StatusBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ThumbnailBox
        '
        resources.ApplyResources(Me.ThumbnailBox, "ThumbnailBox")
        Me.ThumbnailBox.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ThumbnailBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ThumbnailBox.InitialImage = Global.Zumwani.CloudPlayer.My.Resources.Resources.Spinner1
        Me.ThumbnailBox.Name = "ThumbnailBox"
        Me.ThumbnailBox.TabStop = False
        '
        'ContextMenuStrip1
        '
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        Me.ContextMenuStrip1.BackColor = System.Drawing.Color.White
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlayToolStripMenuItem, Me.EditToolStripMenuItem, Me.OpenToolStripMenuItem, Me.ToolStripSeparator1, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        '
        'PlayToolStripMenuItem
        '
        resources.ApplyResources(Me.PlayToolStripMenuItem, "PlayToolStripMenuItem")
        Me.PlayToolStripMenuItem.Name = "PlayToolStripMenuItem"
        '
        'EditToolStripMenuItem
        '
        resources.ApplyResources(Me.EditToolStripMenuItem, "EditToolStripMenuItem")
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        '
        'OpenToolStripMenuItem
        '
        resources.ApplyResources(Me.OpenToolStripMenuItem, "OpenToolStripMenuItem")
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        '
        'ToolStripSeparator1
        '
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        '
        'DeleteToolStripMenuItem
        '
        resources.ApplyResources(Me.DeleteToolStripMenuItem, "DeleteToolStripMenuItem")
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        '
        'TitleLabel
        '
        resources.ApplyResources(Me.TitleLabel, "TitleLabel")
        Me.TitleLabel.AutoEllipsis = True
        Me.TitleLabel.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TitleLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TitleLabel.Name = "TitleLabel"
        '
        'StatusBox
        '
        resources.ApplyResources(Me.StatusBox, "StatusBox")
        Me.StatusBox.ContextMenuStrip = Me.ContextMenuStrip1
        Me.StatusBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.TabStop = False
        '
        'SubtitleLabel
        '
        resources.ApplyResources(Me.SubtitleLabel, "SubtitleLabel")
        Me.SubtitleLabel.AutoEllipsis = True
        Me.SubtitleLabel.ContextMenuStrip = Me.ContextMenuStrip1
        Me.SubtitleLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SubtitleLabel.ForeColor = System.Drawing.Color.Silver
        Me.SubtitleLabel.Name = "SubtitleLabel"
        '
        'ListItem
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.SubtitleLabel)
        Me.Controls.Add(Me.TitleLabel)
        Me.Controls.Add(Me.StatusBox)
        Me.Controls.Add(Me.ThumbnailBox)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "ListItem"
        CType(Me.ThumbnailBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.StatusBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ThumbnailBox As System.Windows.Forms.PictureBox
    Friend WithEvents TitleLabel As System.Windows.Forms.Label
    Friend WithEvents StatusBox As System.Windows.Forms.PictureBox
    Friend WithEvents SubtitleLabel As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PlayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator

End Class
