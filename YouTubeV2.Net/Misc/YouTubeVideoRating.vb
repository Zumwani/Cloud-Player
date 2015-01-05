Namespace Misc

    ''' <summary>Represents ratings on a YouTube video.</summary>
    Public Class YouTubeVideoRating

        ''' <summary>Creates a new YouTubeRating instance.</summary>
        Sub New(Average As Double, AmountOfRaters As Integer)
            Me._Average = Average
            Me._AmountOfRaters = AmountOfRaters
        End Sub

        ''' <summary>Specifies the minimum value for ratings on YouTube.</summary>
        Public Const Minimum As Integer = 0
        ''' <summary>Specifies the maximum value for ratings on YouTube.</summary>
        Public Const Maximum As Integer = 5

        Private _Average As Double
        ''' <summary>Gets the average rating.</summary>
        Public ReadOnly Property Average As Double
            Get
                Return _Average
            End Get
        End Property

        Private _AmountOfRaters As Integer
        ''' <summary>Gets the amount of people that have rated.</summary>
        Public ReadOnly Property AmountOfRaters As Integer
            Get
                Return _AmountOfRaters
            End Get
        End Property

    End Class

End Namespace