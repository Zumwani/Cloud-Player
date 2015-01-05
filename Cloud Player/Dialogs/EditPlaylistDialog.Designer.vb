<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditPlaylistDialog
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
        Me.ThumbnailBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TitleBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ThumbnailPreviewBox = New System.Windows.Forms.PictureBox()
        Me.AddButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.CancelButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.IDLabel = New System.Windows.Forms.Label()
        Me.RegenerateIDLink = New System.Windows.Forms.LinkLabel()
        Me.List = New System.Windows.Forms.FlowLayoutPanel()
        Me.IDInUseLabel = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MoveUpButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.MoveDownButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.AutoThumbnailBox = New System.Windows.Forms.CheckBox()
        CType(Me.ThumbnailPreviewBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ThumbnailBox
        '
        Me.ThumbnailBox.Location = New System.Drawing.Point(33, 165)
        Me.ThumbnailBox.Margin = New System.Windows.Forms.Padding(3, 3, 30, 3)
        Me.ThumbnailBox.Name = "ThumbnailBox"
        Me.ThumbnailBox.Size = New System.Drawing.Size(402, 25)
        Me.ThumbnailBox.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 95)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 15, 0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(294, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Filename or url to an thumbnail for this playlist:"
        '
        'TitleBox
        '
        Me.TitleBox.Location = New System.Drawing.Point(34, 52)
        Me.TitleBox.Name = "TitleBox"
        Me.TitleBox.Size = New System.Drawing.Size(402, 25)
        Me.TitleBox.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Title of playlist:"
        '
        'ThumbnailPreviewBox
        '
        Me.ThumbnailPreviewBox.BackgroundImage = Global.Zumwani.CloudPlayer.My.Resources.Resources.VideoIcon
        Me.ThumbnailPreviewBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ThumbnailPreviewBox.ErrorImage = Nothing
        Me.ThumbnailPreviewBox.Location = New System.Drawing.Point(33, 117)
        Me.ThumbnailPreviewBox.Name = "ThumbnailPreviewBox"
        Me.ThumbnailPreviewBox.Size = New System.Drawing.Size(72, 42)
        Me.ThumbnailPreviewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ThumbnailPreviewBox.TabIndex = 7
        Me.ThumbnailPreviewBox.TabStop = False
        '
        'AddButton
        '
        Me.AddButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AddButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.AddButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.AddButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.AddButton.FlatAppearance.BorderSize = 0
        Me.AddButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.AddButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddButton.Location = New System.Drawing.Point(839, 408)
        Me.AddButton.Margin = New System.Windows.Forms.Padding(10)
        Me.AddButton.Name = "AddButton"
        Me.AddButton.Size = New System.Drawing.Size(75, 30)
        Me.AddButton.TabIndex = 11
        Me.AddButton.Text = "Add"
        Me.AddButton.UseVisualStyleBackColor = False
        '
        'CancelButton
        '
        Me.CancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CancelButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.CancelButton.FlatAppearance.BorderSize = 0
        Me.CancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CancelButton.Location = New System.Drawing.Point(40, 408)
        Me.CancelButton.Margin = New System.Windows.Forms.Padding(10)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(75, 30)
        Me.CancelButton.TabIndex = 10
        Me.CancelButton.Text = "Cancel"
        Me.CancelButton.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 237)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 15, 0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 19)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Playlist ID:"
        '
        'IDLabel
        '
        Me.IDLabel.AutoSize = True
        Me.IDLabel.ForeColor = System.Drawing.Color.DarkGray
        Me.IDLabel.Location = New System.Drawing.Point(30, 256)
        Me.IDLabel.Name = "IDLabel"
        Me.IDLabel.Size = New System.Drawing.Size(265, 19)
        Me.IDLabel.TabIndex = 14
        Me.IDLabel.Text = "{00000000-0000-0000-0000-000000000000}"
        '
        'RegenerateIDLink
        '
        Me.RegenerateIDLink.AutoSize = True
        Me.RegenerateIDLink.LinkColor = System.Drawing.Color.White
        Me.RegenerateIDLink.Location = New System.Drawing.Point(30, 275)
        Me.RegenerateIDLink.Name = "RegenerateIDLink"
        Me.RegenerateIDLink.Size = New System.Drawing.Size(77, 19)
        Me.RegenerateIDLink.TabIndex = 15
        Me.RegenerateIDLink.TabStop = True
        Me.RegenerateIDLink.Text = "Regenerate"
        '
        'List
        '
        Me.List.AllowDrop = True
        Me.List.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.List.AutoScroll = True
        Me.List.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.List.Location = New System.Drawing.Point(499, 74)
        Me.List.Margin = New System.Windows.Forms.Padding(3, 3, 3, 30)
        Me.List.Name = "List"
        Me.List.Size = New System.Drawing.Size(415, 294)
        Me.List.TabIndex = 16
        '
        'IDInUseLabel
        '
        Me.IDInUseLabel.AutoSize = True
        Me.IDInUseLabel.Font = New System.Drawing.Font("Segoe UI Semilight", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.IDInUseLabel.ForeColor = System.Drawing.Color.Red
        Me.IDInUseLabel.Location = New System.Drawing.Point(122, 275)
        Me.IDInUseLabel.Name = "IDInUseLabel"
        Me.IDInUseLabel.Size = New System.Drawing.Size(173, 13)
        Me.IDInUseLabel.TabIndex = 17
        Me.IDInUseLabel.Text = "ID already in use by another playlist"
        Me.IDInUseLabel.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(495, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 19)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Videos:"
        '
        'MoveUpButton
        '
        Me.MoveUpButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.MoveUpButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.MoveUpButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.MoveUpButton.FlatAppearance.BorderSize = 0
        Me.MoveUpButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.MoveUpButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.MoveUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MoveUpButton.Location = New System.Drawing.Point(460, 74)
        Me.MoveUpButton.Margin = New System.Windows.Forms.Padding(10)
        Me.MoveUpButton.Name = "MoveUpButton"
        Me.MoveUpButton.Size = New System.Drawing.Size(32, 26)
        Me.MoveUpButton.TabIndex = 19
        Me.MoveUpButton.Text = "^"
        Me.MoveUpButton.UseVisualStyleBackColor = False
        '
        'MoveDownButton
        '
        Me.MoveDownButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.MoveDownButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.MoveDownButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.MoveDownButton.FlatAppearance.BorderSize = 0
        Me.MoveDownButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.MoveDownButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.MoveDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MoveDownButton.Location = New System.Drawing.Point(460, 100)
        Me.MoveDownButton.Margin = New System.Windows.Forms.Padding(10)
        Me.MoveDownButton.Name = "MoveDownButton"
        Me.MoveDownButton.Size = New System.Drawing.Size(32, 26)
        Me.MoveDownButton.TabIndex = 20
        Me.MoveDownButton.Text = "v"
        Me.MoveDownButton.UseVisualStyleBackColor = False
        '
        'AutoThumbnailBox
        '
        Me.AutoThumbnailBox.AutoSize = True
        Me.AutoThumbnailBox.Location = New System.Drawing.Point(34, 196)
        Me.AutoThumbnailBox.Name = "AutoThumbnailBox"
        Me.AutoThumbnailBox.Size = New System.Drawing.Size(206, 23)
        Me.AutoThumbnailBox.TabIndex = 21
        Me.AutoThumbnailBox.Text = "Use topmost video thumbnail"
        Me.AutoThumbnailBox.UseVisualStyleBackColor = True
        '
        'EditPlaylistDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(954, 478)
        Me.CloseOnEscape = True
        Me.Controls.Add(Me.AutoThumbnailBox)
        Me.Controls.Add(Me.MoveDownButton)
        Me.Controls.Add(Me.MoveUpButton)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.IDInUseLabel)
        Me.Controls.Add(Me.List)
        Me.Controls.Add(Me.RegenerateIDLink)
        Me.Controls.Add(Me.IDLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.AddButton)
        Me.Controls.Add(Me.CancelButton)
        Me.Controls.Add(Me.ThumbnailBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ThumbnailPreviewBox)
        Me.Controls.Add(Me.TitleBox)
        Me.Controls.Add(Me.Label1)
        Me.Name = "EditPlaylistDialog"
        Me.Padding = New System.Windows.Forms.Padding(30)
        Me.Text = "Edit playlist..."
        CType(Me.ThumbnailPreviewBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ThumbnailBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ThumbnailPreviewBox As System.Windows.Forms.PictureBox
    Friend WithEvents TitleBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AddButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend Shadows WithEvents CancelButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents IDLabel As System.Windows.Forms.Label
    Friend WithEvents RegenerateIDLink As System.Windows.Forms.LinkLabel
    Friend WithEvents List As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents IDInUseLabel As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MoveUpButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents MoveDownButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents AutoThumbnailBox As System.Windows.Forms.CheckBox
End Class
