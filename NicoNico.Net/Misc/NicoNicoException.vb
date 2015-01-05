Namespace Misc

    Public Class NicoNicoException
        Inherits Exception

        Sub New(Message As String)
            MyBase.New(Message)
        End Sub

        Sub New(Message As String, e As Exception)
            MyBase.New(Message, e)
        End Sub

    End Class

End Namespace