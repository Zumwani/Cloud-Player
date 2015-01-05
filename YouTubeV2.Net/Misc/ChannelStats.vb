Namespace Misc

    ''' <summary>Represents stats for a YouTube channel.</summary>
    Public Class ChannelStats

        ''' <summary>Creates a new ChannelStats instance.</summary>
        Sub New(SubscriberCount As Integer, TotalViewCount As Integer)
            Me._SubscriberCount = SubscriberCount
            Me._TotalViewCount = _TotalViewCount
        End Sub

        Private _SubscriberCount As Integer
        ''' <summary>Gets the total amount of subscriptions to this channel.</summary>
        Public ReadOnly Property SubscriberCount As Integer
            Get
                Return _SubscriberCount
            End Get
        End Property

        Private _TotalViewCount As Integer
        ''' <summary>Gets the total amount of views for all videos on this channel.</summary>
        Public ReadOnly Property TotalViewCount As Integer
            Get
                Return _TotalViewCount
            End Get
        End Property

    End Class

End Namespace


