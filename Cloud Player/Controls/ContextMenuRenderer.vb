Public Class ContextMenuRenderer
    Inherits ToolStripProfessionalRenderer

    Protected Overrides Sub OnRenderImageMargin(e As ToolStripRenderEventArgs)
        'Dont draw anything, since it should be blank
    End Sub

    Protected Overrides Sub OnRenderItemCheck(e As ToolStripItemImageRenderEventArgs)
        If CType(e.Item, ToolStripMenuItem).Checked Then
            e.Graphics.DrawImage(Zumwani.CommonLibrary.Resources.check, New Rectangle(4, 2, 24, 24))
        End If
    End Sub

    Protected Overrides Sub OnRenderSeparator(e As ToolStripSeparatorRenderEventArgs)
        e.Graphics.DrawLine(Pens.LightGray, New Point(20, e.Item.Height / 2), New Point(e.Item.Width - 20, e.Item.Height / 2))
    End Sub

    Protected Overrides Sub OnRenderToolStripBackground(e As ToolStripRenderEventArgs)
        Using b As New SolidBrush(Color.FromArgb(28, 28, 28))
            e.Graphics.FillRectangle(b, e.AffectedBounds)
        End Using
    End Sub

    Protected Overrides Sub OnRenderItemText(e As ToolStripItemTextRenderEventArgs)
        e.Graphics.DrawString(e.Text, e.TextFont, Brushes.WhiteSmoke, e.TextRectangle)
    End Sub

    Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
        Using p As New Pen(Color.FromArgb(42, 42, 42))
            e.Graphics.DrawRectangle(p, 0, 0, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1)
        End Using
    End Sub

    Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
        If e.Item.Selected Then
            Using b As New SolidBrush(Color.FromArgb(100, 100, 100))
                e.Graphics.FillRectangle(b, e.Item.ContentRectangle)
            End Using
        End If
    End Sub

End Class
