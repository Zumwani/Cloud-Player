Public Class Log

    Public Shared ReadOnly Filename As String = SettingsDirectory.GetFile("Log.txt").FullName

    Public Shared Sub Write(Writer As String, Message As String)
        My.Computer.FileSystem.WriteAllText(Filename, Now.ToString + " " + Writer + ": " + Message + vbNewLine, True)
    End Sub

End Class
