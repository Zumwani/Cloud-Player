Namespace Misc

    Public Class YouTubeException
        Inherits Exception

        Sub New(Message As String)
            MyBase.New(Message)
        End Sub

        Sub New(Message As String, InnerException As Exception)
            MyBase.New(Message, InnerException)
        End Sub

    End Class

End Namespace