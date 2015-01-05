<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlaylistLoadErrorDialog
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
        Me.RetryButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.IgnoreButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.DeleteButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OkButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.SuspendLayout()
        '
        'RetryButton
        '
        Me.RetryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RetryButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.RetryButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.RetryButton.FlatAppearance.BorderSize = 0
        Me.RetryButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.RetryButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.RetryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RetryButton.Location = New System.Drawing.Point(451, 208)
        Me.RetryButton.Name = "RetryButton"
        Me.RetryButton.Size = New System.Drawing.Size(110, 30)
        Me.RetryButton.TabIndex = 0
        Me.RetryButton.Text = "Try again"
        Me.ToolTip1.SetToolTip(Me.RetryButton, "Attempt to load it again, will probably not work.")
        Me.RetryButton.UseVisualStyleBackColor = False
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
        Me.IgnoreButton.Location = New System.Drawing.Point(33, 208)
        Me.IgnoreButton.Name = "IgnoreButton"
        Me.IgnoreButton.Size = New System.Drawing.Size(110, 30)
        Me.IgnoreButton.TabIndex = 1
        Me.IgnoreButton.Text = "Ignore it"
        Me.ToolTip1.SetToolTip(Me.IgnoreButton, "Ignores the playlist for now.")
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
        Me.DeleteButton.Location = New System.Drawing.Point(323, 208)
        Me.DeleteButton.Margin = New System.Windows.Forms.Padding(15)
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(110, 30)
        Me.DeleteButton.TabIndex = 2
        Me.DeleteButton.Text = "Delete it!"
        Me.ToolTip1.SetToolTip(Me.DeleteButton, "Delete the playlist, it will be moved to the recycle bin regardless of settings.")
        Me.DeleteButton.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(30, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(534, 163)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "The playlist '<filename>' could not be loaded due to an error." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Generator version" & _
    ": '<generatorversion>', Playlist version: '<playlistversion>'" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<errormessage>"
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.OkButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.OkButton.FlatAppearance.BorderSize = 0
        Me.OkButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.OkButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OkButton.Location = New System.Drawing.Point(451, 208)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(110, 30)
        Me.OkButton.TabIndex = 4
        Me.OkButton.Text = "Ok"
        Me.OkButton.UseVisualStyleBackColor = False
        Me.OkButton.Visible = False
        '
        'PlaylistLoadErrorDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 271)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DeleteButton)
        Me.Controls.Add(Me.IgnoreButton)
        Me.Controls.Add(Me.RetryButton)
        Me.Name = "PlaylistLoadErrorDialog"
        Me.Padding = New System.Windows.Forms.Padding(30)
        Me.Text = "Playlist failed to load"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RetryButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents IgnoreButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents DeleteButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OkButton As Zumwani.CommonLibrary.Controls.MetroButton
End Class
