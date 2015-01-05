<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlaylistDifferentVersionDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlaylistDifferentVersionDialog))
        Me.UpgradeButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.IgnoreButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.DeleteButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'UpgradeButton
        '
        Me.UpgradeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UpgradeButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.UpgradeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.UpgradeButton.FlatAppearance.BorderSize = 0
        Me.UpgradeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.UpgradeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.UpgradeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UpgradeButton.Location = New System.Drawing.Point(456, 208)
        Me.UpgradeButton.Margin = New System.Windows.Forms.Padding(5)
        Me.UpgradeButton.Name = "UpgradeButton"
        Me.UpgradeButton.Size = New System.Drawing.Size(110, 30)
        Me.UpgradeButton.TabIndex = 1
        Me.UpgradeButton.Text = "Upgrade it"
        Me.ToolTip1.SetToolTip(Me.UpgradeButton, "Attempts to upgrade the playlist to the newest version, note that it might not " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & _
        "always work as expected. A backup will be created before the upgrade.")
        Me.UpgradeButton.UseVisualStyleBackColor = False
        '
        'IgnoreButton
        '
        Me.IgnoreButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.IgnoreButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.IgnoreButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.IgnoreButton.FlatAppearance.BorderSize = 0
        Me.IgnoreButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.IgnoreButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.IgnoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IgnoreButton.Location = New System.Drawing.Point(26, 208)
        Me.IgnoreButton.Margin = New System.Windows.Forms.Padding(20)
        Me.IgnoreButton.Name = "IgnoreButton"
        Me.IgnoreButton.Size = New System.Drawing.Size(110, 30)
        Me.IgnoreButton.TabIndex = 2
        Me.IgnoreButton.Text = "Ignore it"
        Me.ToolTip1.SetToolTip(Me.IgnoreButton, "Ignore the playlist for now.")
        Me.IgnoreButton.UseVisualStyleBackColor = False
        '
        'DeleteButton
        '
        Me.DeleteButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeleteButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.DeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.DeleteButton.FlatAppearance.BorderSize = 0
        Me.DeleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.DeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DeleteButton.Location = New System.Drawing.Point(326, 208)
        Me.DeleteButton.Margin = New System.Windows.Forms.Padding(15)
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(110, 30)
        Me.DeleteButton.TabIndex = 3
        Me.DeleteButton.Text = "Delete it!"
        Me.ToolTip1.SetToolTip(Me.DeleteButton, "Delete the playlist, it will be moved to the recycle bin regardless of settings.")
        Me.DeleteButton.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(30, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(534, 170)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.White
        '
        'PlaylistDifferentVersionDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 271)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DeleteButton)
        Me.Controls.Add(Me.IgnoreButton)
        Me.Controls.Add(Me.UpgradeButton)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "PlaylistDifferentVersionDialog"
        Me.Padding = New System.Windows.Forms.Padding(30)
        Me.Text = "Unexpected playlist version"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UpgradeButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents IgnoreButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents DeleteButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
