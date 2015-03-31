Public NotInheritable Class Video

#Region "Constructor"

    Public Sub New(Location As Uri, Service As String, Title As String, Creator As String, Length As TimeSpan, Thumbnail As String)
        Me._Location = Location
        Me._Service = Service
        Me._Title = Title
        Me._Creator = Creator
        Me._Length = Length
        Me._Thumbnail = Thumbnail
    End Sub

#End Region
#Region "Properties"

    Public Property Location As Uri
    Public Property Service As String
    Public Property Title As String
    Public Property Creator As String
    Public Property Length As TimeSpan

    Private _Thumbnail As String
    Public Property Thumbnail As String
        Get
            If Not _Thumbnail.Contains("%ThumbnailStore%") Then
                Return _Thumbnail
            Else
                Return _Thumbnail.Replace("%ThumbnailStore", ThumbnailStore.FullName)
            End If
        End Get
        Set(value As String)
            If Not value.Contains(ThumbnailStore.FullName) Then
                _Thumbnail = value
            Else
                _Thumbnail = value.Replace(ThumbnailStore.FullName, "%ThumbnailStore%")
            End If
        End Set
    End Property

#End Region
#Region "Functions"

    Public ReadOnly Property FriendlyLength As String
        Get
            Return GetFriendlyLength(Length)
        End Get
    End Property

    Public Shared Function GetFriendlyLength(TimeSpan As TimeSpan) As String

        'Length is the value in seconds. For some reason doing it this method returns 1 second to much, subtracting 1 second from the timespan fixes that.
        Dim a As String

        Dim h As Integer = TimeSpan.Hours
        Dim m As Integer = TimeSpan.Minutes
        Dim s As Integer = TimeSpan.Seconds

        If Not h = 0 Then

            a = h.ToString + ":"

            If m.ToString.Length = 1 Then
                a += "0" + m.ToString
            Else
                a += m.ToString
            End If

            a += ":"

            If s.ToString.Length = 1 Then
                a += "0" + s.ToString
            Else
                a += s.ToString
            End If

        Else

            a = m.ToString + ":"

            If s.ToString.Length = 1 Then
                a += "0" + s.ToString
            Else
                a += s.ToString
            End If

        End If

        Return a

    End Function

#End Region

End Class
