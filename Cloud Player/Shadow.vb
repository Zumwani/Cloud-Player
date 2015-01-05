Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class Shadow
    Inherits Panel

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint + ControlStyles.ResizeRedraw + ControlStyles.SupportsTransparentBackColor, True)
    End Sub

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        'MsgBox("")
        'MyBase.OnPaintBackground(e)
        'With e.Graphics
        '    .SmoothingMode = SmoothingMode.HighQuality
        '    .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        '    .CompositingQuality = CompositingQuality.HighQuality
        'End With
        'Dim brGlass As New SolidBrush(Color.FromArgb(0, 0, 0, 0))
        'Dim gpath As New GraphicsPath
        'gpath.AddRectangle(Me.ClientRectangle)
        'e.Graphics.FillPath(brGlass, gpath)
        Using b As New SolidBrush(Color.FromArgb(0, Color.White))
            e.Graphics.FillRectangle(b, e.ClipRectangle)
        End Using

    End Sub

    <Browsable(False)> _
    ReadOnly Property EffectiveBounds() As RectangleF
        Get
            Return New RectangleF(ClientRectangle.X + 2, ClientRectangle.Y + 2, ClientRectangle.Width - 4, ClientRectangle.Height - 4)
        End Get
    End Property

    'Sub s() Handles Me.AutoSizeChanged

    'End Sub

    Private Sub Shadow_Click(sender As Object, e As EventArgs) Handles Me.Click
        Me.Invalidate()
    End Sub
End Class
