<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewVideoDialog
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
        Me.MediaPlayer1 = New Zumwani.CloudPlayer.MediaPlayer()
        Me.SuspendLayout()
        '
        'MediaPlayer1
        '
        Me.MediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MediaPlayer1.Location = New System.Drawing.Point(0, 0)
        Me.MediaPlayer1.Name = "MediaPlayer1"
        Me.MediaPlayer1.Size = New System.Drawing.Size(506, 351)
        Me.MediaPlayer1.TabIndex = 0
        '
        'ViewVideoDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 351)
        Me.CloseOnEscape = True
        Me.Controls.Add(Me.MediaPlayer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.MaximizeBox = True
        Me.MinimizeBox = False
        Me.Name = "ViewVideoDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = ""
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MediaPlayer1 As Zumwani.CloudPlayer.MediaPlayer
End Class
