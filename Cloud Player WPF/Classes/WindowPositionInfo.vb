Public Class WindowPositionInfo

    Public Property DisplayRectangle As Rectangle

    Public Property Maximized As Boolean
    Public Property DockedSide As ScreenSide
    Public Property DockScreen As Integer

    Public Enum ScreenSide
        Left = 0
        Right = 1
    End Enum

End Class