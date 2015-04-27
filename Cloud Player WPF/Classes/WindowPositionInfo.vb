Imports System.Xml.Serialization

<Serializable>
Public Class WindowPositionInfo

    Public Property DisplayRectangle As Rect
    Public Property Maximized As Boolean
    Public Property DockSide As ScreenSide?
    Public Property DockScreen As Integer?

    Public Enum ScreenSide
        Left = 0
        Right = 1
    End Enum

    Public Sub New()
    End Sub

    Private Sub New(DisplayRectangle As Rect, Maximized As Boolean, DockSide As ScreenSide?, DockScreen As Integer?)
        Me.DisplayRectangle = DisplayRectangle
        Me.Maximized = Maximized
        Me.DockSide = DockSide
        Me.DockScreen = DockScreen
    End Sub

    Public Shared Function FromWindow(Window As Window) As WindowPositionInfo

        Dim dr As Rect

        If Window.WindowState = WindowState.Normal Then
            dr = New Rect(Window.Left, Window.Top, Window.Width, Window.Height)
        Else
            With Window.RestoreBounds
                dr = New Rect(.Left, .Top, .Width, .Height)
            End With
        End If

        'TODO: Check if docked
        'If docked then
        'Else
        Return New WindowPositionInfo(dr, (Window.WindowState = WindowState.Maximized), Nothing, Nothing)
        'End If

    End Function

    Public Sub RestoreWindow(Window As Window)

        With Window

            .Left = Me.DisplayRectangle.Left
            .Top = Me.DisplayRectangle.Top
            .Width = Me.DisplayRectangle.Width
            .Height = Me.DisplayRectangle.Height

            If Maximized Then
                .WindowState = WindowState.Maximized
            End If

            'TODO: Fix docking system

        End With

    End Sub

    'This is the size of the window in design mode
    Public Shared ReadOnly DefaultSize As New Size(300, 500)

    Public Shared Sub ResetWindow(Window As Window)

        With Window

            .Width = DefaultSize.Width
            .Height = DefaultSize.Height

            .Left = (System.Windows.SystemParameters.PrimaryScreenWidth / 2) - (Window.ActualWidth / 2)
            .Top = (System.Windows.SystemParameters.PrimaryScreenHeight / 2) - (Window.ActualHeight / 2)

            If Not .WindowState = WindowState.Minimized Then
                .WindowState = WindowState.Normal
            Else
                .WindowState = WindowState.Normal
                .WindowState = WindowState.Minimized
            End If

            'TODO: Reset dock

        End With

    End Sub

End Class