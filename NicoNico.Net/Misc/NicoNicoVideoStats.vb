Namespace Misc

    Public Class NicoNicoVideoStats

        Sub New(ViewCount As String, CommentCount As Integer, MyListCount As Integer)
            Me._ViewCount = ViewCount
            Me._CommentCount = CommentCount
            Me._MyListCount = MyListCount
        End Sub

        Private _ViewCount As Integer
        Public ReadOnly Property ViewCount As Integer
            Get
                Return _ViewCount
            End Get
        End Property

        Private _CommentCount As Integer
        Public ReadOnly Property CommentCount As Integer
            Get
                Return _CommentCount
            End Get
        End Property

        Private _MyListCount As Integer
        Public ReadOnly Property MyListCount As Integer
            Get
                Return _MyListCount
            End Get
        End Property

    End Class

End Namespace