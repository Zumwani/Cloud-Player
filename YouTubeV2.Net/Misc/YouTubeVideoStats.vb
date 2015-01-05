Namespace Misc

    ''' <summary>Represents stats on a YouTube video.</summary>
    Public Class YouTubeVideoStats

        ''' <summary>Creates a new YouTubeVideoStats instance</summary>
        Sub New(AmountOfTimesFavorited As Integer, Views As Integer)
            Me._AmountOfTimesFavorited = AmountOfTimesFavorited
            Me._Views = Views
        End Sub

        Private _AmountOfTimesFavorited As Integer
        ''' <summary>Gets the amount of times this YouTube video was favorited.</summary>
        Public ReadOnly Property AmountOfTimesFavorited As Integer
            Get
                Return _AmountOfTimesFavorited
            End Get
        End Property

        Private _Views As Integer
        ''' <summary>Gets the amount of views on this video.</summary>
        Public ReadOnly Property Views As Integer
            Get
                Return _Views
            End Get
        End Property

    End Class

End Namespace